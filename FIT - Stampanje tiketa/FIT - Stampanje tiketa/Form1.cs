using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeepAutomation.Barcode;
using KeepAutomation.Barcode.Bean;
using KeepAutomation.Barcode.Windows;
using System.Drawing.Imaging;
using System.Threading;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FIT___Stampanje_tiketa
{
    public partial class Form1 : Form
    {
        Bitmap QRcode = null;
        String naziv = "";
        String adresa = "";
        int redniBroj = 0;
        public Form1()
        {
            InitializeComponent();
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            getDataFromDatabase();
            serialPort1.Open();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            NacrtajTiket(e.Graphics, this.naziv, this.adresa, this.redniBroj, Convert.ToInt32(idUstanoveTextBox.Text));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.redniBroj++;
            this.printDocument1.Print();
            //MessageBox.Show(this.redniBroj.ToString());
            updateDatabase();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            NacrtajTiket(e.Graphics, this.naziv, this.adresa, this.redniBroj, 6);
        }

        public void NacrtajTiket(Graphics g, String institucija, String adresa, int redniBroj, int idInstitucije)
        {
            Point pocetak = new Point(0, 0);
            Size velicina = new Size(270, 580);

            Pen olovka = new Pen(Color.Black, 1f);
            olovka.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Rectangle rect = new Rectangle(pocetak, velicina);
            //g.DrawRectangle(olovka, rect);

            velicina = new Size(270, 100);
            Rectangle okvirSlike = new Rectangle(pocetak, velicina);
            g.DrawImage(Properties.Resources.logo, okvirSlike);

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            velicina = new Size(270, 35);
            pocetak = new Point(0, 100);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Rectangle okvirNazivaInstitucije = new Rectangle(pocetak, velicina);
            g.DrawString(institucija, font, new SolidBrush(Color.Black), okvirNazivaInstitucije, format);

            velicina = new Size(270, 35);
            pocetak = new Point(0, 135);
            Rectangle okvirAdrese = new Rectangle(pocetak, velicina);
            Font font2 = new Font("Arial", 12);
            g.DrawString(adresa, font2, new SolidBrush(Color.Black), okvirAdrese, format);

            velicina = new Size(270, 110);
            pocetak = new Point(0, 200);
            Rectangle okvirRednogBroja = new Rectangle(pocetak, velicina);
            Font font3 = new Font("Arial", 80, FontStyle.Bold);
            g.DrawString(redniBroj.ToString(), font3, new SolidBrush(Color.Black), okvirRednogBroja, format);

            generisiQRKod("{\"insID\":\""+idInstitucije+"\", \"redniBroj\": \""+redniBroj+"\"}");
            //MessageBox.Show("{\"insID\":\"" + idInstitucije + "\", \"redniBroj\": \"" + redniBroj + "\"}");

            velicina = new Size(200, 200);
            pocetak = new Point(40, 330);
            Rectangle okvirQRkoda = new Rectangle(pocetak, velicina);
            g.DrawImage(this.QRcode, okvirQRkoda, new Rectangle(11,11,113,113), GraphicsUnit.Pixel);

            DateTime dateTime = DateTime.Now;
            String vrijeme = (dateTime.Hour > 9 ? dateTime.Hour.ToString() : "0" + dateTime.Hour.ToString()) + ":" + (dateTime.Minute > 9 ? dateTime.Minute.ToString() : "0" + dateTime.Minute.ToString()) + ":" + (dateTime.Second > 9 ? dateTime.Second.ToString() : "0" + dateTime.Second.ToString());
            String datum = (dateTime.Day > 9 ? dateTime.Day.ToString() : "0" + dateTime.Day.ToString()) + "/" + (dateTime.Month > 9 ? dateTime.Month.ToString() : "0" + dateTime.Month.ToString()) + "/" + (dateTime.Year > 9 ? dateTime.Year.ToString() : "0" + dateTime.Year.ToString());
            velicina = new Size(270, 35);
            pocetak = new Point(0, 540);
            Rectangle okvirDatuma = new Rectangle(pocetak, velicina);
            g.DrawString(datum + " " + vrijeme, font2, new SolidBrush(Color.Black), okvirDatuma, format);

            pocetak = new Point(0, 640);
            g.DrawRectangle(olovka, new Rectangle(pocetak, new Size(1, 1)));

            
        }

        public void generisiQRKod(String tekst)
        {
            BarCode qrcode = new BarCode();
            qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;

            //Select a QR Code supported data mode according to your code:
            //AlphaNumeric: for 0 - 9, upper case letters A - Z, and nine punctuation characters space, $ % * + - . / :
            //Byte data: for (ISO/IEC 8859-1) encoding characters at 8 bits per character
            //Kanji Characters (JIS)
            //Numeric: for digits 0 - 9
            qrcode.QRCodeDataMode = QRCodeDataMode.Auto;

            //Input your QR Code encoding data:
            qrcode.CodeToEncode = tekst;

            // Unit of measure, pixel, cm and inch supported.
            qrcode.BarcodeUnit = BarcodeUnit.Pixel;
            // QR Code image resolution in dpi
            qrcode.DPI = 72;
            // QR Code bar module width (X dimention)
            qrcode.X = 3;
            // QR Code bar module height (Y dimention), Y=X
            qrcode.Y = 3;

            // QR Code image left margin size, the minimum value is 4X.
            qrcode.LeftMargin = 12;
            // Image right margin size, minimum value is 4X.
            qrcode.RightMargin = 12;
            // Image top margin size, minimum value is 4X.
            qrcode.TopMargin = 12;
            // Image bottom margin size, minimum value is 4X.
            qrcode.BottomMargin = 12;

            // QR Code orientation, 90, 180, 270 degrees supported.
            qrcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0;

            
            // QR Code barcode version, valid from V1-V40
            qrcode.QRCodeVersion = QRCodeVersion.V5;

            // QR Code barcode Error Correction Lever, supporting H, L, M, Q.
            qrcode.QRCodeECL = QRCodeECL.H;

            // QR Code image formats, supporting Png, Jpeg, Gif, Tiff, Bmp, etc.
            qrcode.ImageFormat = ImageFormat.Png;

            // Generate QR Code barcodes in image format GIF
            //qrcode.generateBarcodeToImageFile("qrcode.png");
            this.QRcode = qrcode.generateBarcodeToBitmap();
        }

        public void getDataFromDatabase()
        {
            String idUstanove = idUstanoveTextBox.Text;
            //MessageBox.Show(idUstanove);

            String URL = "http://paviljondedinje.com/kmet/api/get-ustanova-stanje.php?id_ustanove="+idUstanove;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";

             try {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();

                isparsirajJSON(response);
                
                responseReader.Close();
            } catch (Exception e) {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }

        public void updateDatabase()
        {
            String idUstanove = idUstanoveTextBox.Text;
            //MessageBox.Show(idUstanove);

            String URL = "http://paviljondedinje.com/kmet/api/update-stanje-poslednji.php?id_ustanove=" + idUstanove + "&poslednji_uzeti=" + this.redniBroj.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }

        public void isparsirajJSON(String response)
        {
            //MessageBox.Show(response);
            var objekat = JObject.Parse("{\"objekat\":"+response+"}");

            this.naziv = objekat["objekat"][0]["NAZIV"].ToString();
            this.redniBroj = Convert.ToInt32(objekat["objekat"][0]["POSLEDNJI_UZETI"].ToString());
            this.adresa = objekat["objekat"][0]["ADRESA"].ToString();
            //MessageBox.Show(objekat["objekat"][0]["POSLEDNJI_UZETI"].ToString());
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String s = serialPort1.ReadLine();

                this.redniBroj++;
                this.printDocument1.Print();
                //MessageBox.Show(this.redniBroj.ToString());
                updateDatabase();
        }
    }

}

