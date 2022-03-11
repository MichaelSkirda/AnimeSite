var videoSource = document.getElementById("video-src");
var video = document.getElementById("video-player");
var seriesBtns = document.getElementById("series-btns").children;
var seriesNumber = 1;

function changeSeries(sender)
{

	seriesBtns[seriesNumber - 1].className = "";

	seriesNumber = sender.getAttribute("seriesvalue");

	seriesBtns[seriesNumber - 1].className = "series-active";

	video.setAttribute("poster", "/vid/thumbnail/" + postID + "-" + seriesNumber + ".jpg");


	var source = document.createElement('source');

	source.setAttribute("src", "/vid/" + postID + "-" + seriesNumber + ".mp4");
	source.setAttribute('type', 'video/mp4');

	videoSource.remove();

	video.appendChild(source);

	videoSource = source;

	video.load();
}