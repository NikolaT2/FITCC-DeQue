using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Media;
using ZXing;
using ZXing.Aztec;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FIT_DQ
{
    public partial class Form1 : Form
    {
        private int TRENUTNOSTANJE;
        private int poslednjiUzeti;
        private int procitaniBrojSaKoda;
        private int trenutnoStanje;
        private String ID = "1";
        private Prikaz formaPrikaz;
        private int brojSlika = 0;


        private Bitmap QRmapa=null;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private Stopwatch stopWatch = null;
        private SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
            formaPrikaz = new Prikaz();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer(Properties.Resources.Beep);
            formaPrikaz.Show();

            try
            {
                videoSource = new VideoCaptureDevice(initCamera(videoDevices).MonikerString);
                OpenVideoSource(videoSource);

            }
            catch (Exception)
            {
                MessageBox.Show("Greska sa kamerom!!!!");
            }
        }

        private void CloseCurrentVideoSource()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!videoSourcePlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.Stop();
                }

                videoSourcePlayer.VideoSource = null;
            }
        }

        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            // stop current video source
            CloseCurrentVideoSource();

            // start new video source
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();

            // reset stop watch
            stopWatch = null;

            // start timer
            timer.Start();

            this.Cursor = Cursors.Default;
        }

        private FilterInfo initCamera(FilterInfoCollection videoDevices)
        {
            VideoCaptureDevice videoSource;

            return videoDevices[0];
            /*foreach (FilterInfo device in videoDevices)
            {
                MessageBox.Show(device.Name);
                if (device.Name == "USB2.0 Camera")
                {
                    return device;
                }
        }
            return null;*/
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            getTrenutnoStanje();
            if (formaPrikaz.vrijemeBlinkanja>30 && poslednjiUzeti+3> trenutnoStanje)
            {
                formaPrikaz.vrijemeBlinkanja = 0;
                setTrenutnoStanje();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentVideoSource();
        }


        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            QRmapa = new Bitmap(image);
            brojSlika++;
            if (brojSlika>15)
            {
                brojSlika = 0;
                qrReader(QRmapa);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getTrenutnoStanje();
            setTrenutnoStanje();
        }
        private void setTrenutnoStanje()
        {
            if (trenutnoStanje < poslednjiUzeti+3)
            {
                TRENUTNOSTANJE = trenutnoStanje;
                formaPrikaz.labela.Text = trenutnoStanje.ToString();
                formaPrikaz.upaliBlinkanje = true;
                formaPrikaz.vrijemeBlinkanja = 0;
                updateTrenutniBroj((trenutnoStanje+1));
            }
        }
        public void getTrenutnoStanje()
        {
            String URL = "http://paviljondedinje.com/kmet/api/get-ustanova-stanje.php?id_ustanove="+ID;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                isparsirajJSON(response);
                responseReader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska API");
                formaPrikaz.labela.Text = "--";
                formaPrikaz.upaliBlinkanje = false;
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }
        public void updateTrenutniBroj(int trenutnoStanje)
        {
            String URL = "http://paviljondedinje.com/kmet/api/update-stanje-trenutno.php?id_ustanove="+ID+"&trenutno_stanje="+trenutnoStanje;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska API!!!");
            }
        }
        public void isparsirajJSON(String response)
        {
            //MessageBox.Show(response);
            var objekat = JObject.Parse("{\"objekat\":" + response + "}");
            this.trenutnoStanje = Convert.ToInt32(objekat["objekat"][0]["TRENUTNO_STANJE"].ToString());
            this.poslednjiUzeti=Convert.ToInt32(objekat["objekat"][0]["POSLEDNJI_UZETI"].ToString());
            /*MessageBox.Show(objekat["objekat"][0]["NAZIV"].ToString());
            MessageBox.Show(Convert.ToInt32(objekat["objekat"][0]["TRENUTNO_STANJE"].ToString()).ToString());
            MessageBox.Show(Convert.ToInt32(objekat["objekat"][0]["POSLEDNJI_UZETI"].ToString()).ToString());
            MessageBox.Show(objekat["objekat"][0]["ADRESA"].ToString());*/

            //MessageBox.Show(objekat["objekat"][0]["POSLEDNJI_UZETI"].ToString());
        }

        private int parsirajQR(string data) {

            string broj = "";
            for (int i = data.Length - 5; i < data.Length; i++)
            {
                if (data[i]>='0' && data[i]<='9')
                {
                    broj += data[i];
                }
            }
            return Convert.ToInt32(broj);
        }
        private void qrReader(Bitmap QRMapa) {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode(QRmapa);
            try
            {
                string decoded = result.ToString().Trim();
                if (decoded != "")
                {
                    player.Play();
                    procitaniBrojSaKoda = parsirajQR(decoded);
                    if (TRENUTNOSTANJE== procitaniBrojSaKoda)
                    {
                        formaPrikaz.upaliBlinkanje = false;
                    }             
                    else
                        MessageBox.Show("Nije red na njega!!!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Greska!!!");
            }
        }

        private void updateVrijeme() {
            /*String URL = "http://paviljondedinje.com/kmet/api/update-stanje-trenutno.php?id_ustanove=" + ID + "&trenutno_stanje=" + trenutnoStanje;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
            }
            catch (Exception e)
            {
                MessageBox.Show("Greska API!!!");
            }*/
        }
    }
}
