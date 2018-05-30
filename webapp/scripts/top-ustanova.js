$('document').ready(function(){

});

function loadUstanovaType(str)
{
    $('#ustanove-tipovi').hide();
    $('#ustanove-same-name').hide();
    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp=new XMLHttpRequest();
    } 
    else {  // code for IE6, IE5
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange=function() {
        if (this.readyState==4 && this.status==200) {
          document.getElementById("top-ustanove").innerHTML=this.responseText;
        }
    }
    xmlhttp.open("GET","api/get-top-ustanova.php?tip="+str);
    xmlhttp.send();
}

function loadUstanovaName(str)
{
    $('#top-ustanove').hide();
    $('#ustanove-same-name').show();

    if (window.XMLHttpRequest) {
        // code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp=new XMLHttpRequest();
    } 
    else {  // code for IE6, IE5
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange=function() {
        if (this.readyState==4 && this.status==200) {
          document.getElementById("ustanove-same-name").innerHTML=this.responseText;
        }
    }
    xmlhttp.open("GET","api/get-ustanova-name-list.php?naziv="+str);
    xmlhttp.send();
}