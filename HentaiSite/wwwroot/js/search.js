function onTagClick(tag)
{
	console.log(tag);
	if(tag.className == "tag-active")
	{
		tag.className = "";
	}
	else
	{
		tag.className = "tag-active";
	}
}


var tags = document.getElementsByClassName("tag-cloud-search")[0].getElementsByTagName("li");

for (var i = 0; i < tags.length; i++)
{
	tags[i].onclick = function() { onTagClick(this) };
}