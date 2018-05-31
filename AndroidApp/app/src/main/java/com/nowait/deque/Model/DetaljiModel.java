package com.nowait.deque.Model;

/**
 * Created by user on 31.5.2018..
 */

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class DetaljiModel {

    @SerializedName("ID_STANJA")
    @Expose
    private String iDSTANJA;
    @SerializedName("ID_USTANOVE")
    @Expose
    private String iDUSTANOVE;
    @SerializedName("TRENUTNO_STANJE")
    @Expose
    private String tRENUTNOSTANJE;
    @SerializedName("POSLEDNJI_UZETI")
    @Expose
    private String pOSLEDNJIUZETI;
    @SerializedName("DATUM")
    @Expose
    private String dATUM;
    @SerializedName("NAZIV")
    @Expose
    private String nAZIV;
    @SerializedName("LON")
    @Expose
    private String lON;
    @SerializedName("LAT")
    @Expose
    private String lAT;
    @SerializedName("BROJ_SALTERA")
    @Expose
    private String bROJSALTERA;
    @SerializedName("ADRESA")
    @Expose
    private String aDRESA;
    @SerializedName("LOGO")
    @Expose
    private Object lOGO;
    @SerializedName("RV_OD")
    @Expose
    private String rVOD;
    @SerializedName("RV_DO")
    @Expose
    private String rVDO;
    @SerializedName("TIP")
    @Expose
    private String tIP;

    public String getIDSTANJA() {
        return iDSTANJA;
    }

    public void setIDSTANJA(String iDSTANJA) {
        this.iDSTANJA = iDSTANJA;
    }

    public String getIDUSTANOVE() {
        return iDUSTANOVE;
    }

    public void setIDUSTANOVE(String iDUSTANOVE) {
        this.iDUSTANOVE = iDUSTANOVE;
    }

    public String getTRENUTNOSTANJE() {
        return tRENUTNOSTANJE;
    }

    public void setTRENUTNOSTANJE(String tRENUTNOSTANJE) {
        this.tRENUTNOSTANJE = tRENUTNOSTANJE;
    }

    public String getPOSLEDNJIUZETI() {
        return pOSLEDNJIUZETI;
    }

    public void setPOSLEDNJIUZETI(String pOSLEDNJIUZETI) {
        this.pOSLEDNJIUZETI = pOSLEDNJIUZETI;
    }

    public String getDATUM() {
        return dATUM;
    }

    public void setDATUM(String dATUM) {
        this.dATUM = dATUM;
    }

    public String getNAZIV() {
        return nAZIV;
    }

    public void setNAZIV(String nAZIV) {
        this.nAZIV = nAZIV;
    }

    public String getLON() {
        return lON;
    }

    public void setLON(String lON) {
        this.lON = lON;
    }

    public String getLAT() {
        return lAT;
    }

    public void setLAT(String lAT) {
        this.lAT = lAT;
    }

    public String getBROJSALTERA() {
        return bROJSALTERA;
    }

    public void setBROJSALTERA(String bROJSALTERA) {
        this.bROJSALTERA = bROJSALTERA;
    }

    public String getADRESA() {
        return aDRESA;
    }

    public void setADRESA(String aDRESA) {
        this.aDRESA = aDRESA;
    }

    public Object getLOGO() {
        return lOGO;
    }

    public void setLOGO(Object lOGO) {
        this.lOGO = lOGO;
    }

    public String getRVOD() {
        return rVOD;
    }

    public void setRVOD(String rVOD) {
        this.rVOD = rVOD;
    }

    public String getRVDO() {
        return rVDO;
    }

    public void setRVDO(String rVDO) {
        this.rVDO = rVDO;
    }

    public String getTIP() {
        return tIP;
    }

    public void setTIP(String tIP) {
        this.tIP = tIP;
    }

}
