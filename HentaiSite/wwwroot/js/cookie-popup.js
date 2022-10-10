$(document).ready(function(){   
    setTimeout(cookieFadeIn, 500);
    $(".cookieConsentOK").click(cookieOkClick); 
    $("#closeCookieConsent").click(cookieCloseCick);
}); 

function cookieFadeIn() {

	cookie = getCookie("cookieAccept");

	if(cookie == null || cookie != 'true')
	{
		$("#cookieConsent").fadeIn(200);
	}
}

function cookieOkClick()
{
	setCookie("cookieAccept", true, 365)
	$("#cookieConsent").fadeOut(200);
}

function cookieCloseCick()
{
	$("#cookieConsent").fadeOut(200);
}

function setCookie(name,value,days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days*24*60*60*1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "")  + expires + "; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
    }
    return null;
}