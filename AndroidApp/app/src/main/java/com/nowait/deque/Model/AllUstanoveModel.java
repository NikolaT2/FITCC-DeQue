package com.nowait.deque.Model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/**
 * Created by user on 31.5.2018..
 */


public class AllUstanoveModel {

    @SerializedName("ID_USTANOVE")
    @Expose
    private String iDUSTANOVE;
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
    private Object aDRESA;
    @SerializedName("LOGO")
    @Expose
    private Object lOGO;
    @SerializedName("RV_OD")
    @Expose
    private Object rVOD;
    @SerializedName("RV_DO")
    @Expose
    private Object rVDO;
    @SerializedName("TIP")
    @Expose
    private String tIP;

    public String getIDUSTANOVE() {
        return iDUSTANOVE;
    }

    public void setIDUSTANOVE(String iDUSTANOVE) {
        this.iDUSTANOVE = iDUSTANOVE;
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

    public Object getADRESA() {
        return aDRESA;
    }

    public void setADRESA(Object aDRESA) {
        this.aDRESA = aDRESA;
    }

    public Object getLOGO() {
        return lOGO;
    }

    public void setLOGO(Object lOGO) {
        this.lOGO = lOGO;
    }

    public Object getRVOD() {
        return rVOD;
    }

    public void setRVOD(Object rVOD) {
        this.rVOD = rVOD;
    }

    public Object getRVDO() {
        return rVDO;
    }

    public void setRVDO(Object rVDO) {
        this.rVDO = rVDO;
    }

    public String getTIP() {
        return tIP;
    }

    public void setTIP(String tIP) {
        this.tIP = tIP;
    }

}