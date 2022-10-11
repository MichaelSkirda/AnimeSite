const headerSearch = document.getElementById("header-search");
const searchBtn = document.getElementById("search-btn");

searchBtn.onclick = function()
{
	if(headerSearch.className.includes('visible'))
	{
		headerSearch.className = "header-search-wrap";
	}
	else
	{
		headerSearch.className = "header-search-wrap visible";
	}
};