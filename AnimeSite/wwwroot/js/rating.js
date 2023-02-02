var plusBtn = document.getElementById("plusButton");
var minusBtn = document.getElementById("minusButton");
var postRating = document.getElementById("postRating");

plusBtn.onclick = function() { Rate(true); }

minusBtn.onclick = function() { Rate(false); } 

function Rate(isPositiveRate)
{
	var currentRequest = $.ajax({
		url: "/action/Rate",
		method: "get",
		cache: false,
		data: {
			postID: postID,
			isPositiveRate: isPositiveRate
		},

		success: function(newPostRating){

			postRating.textContent = "Rating " + newPostRating;

		},
		error: function(XMLHttpRequest, textStatus, errorThrown) { 
		    // TODO commentErrorMessage.style = "display: block;"
		} 
	});
}