var videoSource = document.getElementById("video-src");
var video = document.getElementById("video-player");

function changeSeries(sender)
{

	let seriesNumber = sender.getAttribute("seriesvalue");

	video.setAttribute("poster", "/vid/thumbnail/" + postID + "-" + seriesNumber + ".jpg");


	var source = document.createElement('source');

	source.setAttribute("src", "/vid/" + postID + "-" + seriesNumber + ".mp4");
	source.setAttribute('type', 'video/mp4');

	videoSource.remove();

	video.appendChild(source);

	videoSource = source;

	video.load();
}