var textArea = document.getElementById("commentTextArea");
var authorName = document.getElementById("commentAuthorName");
var submitButton = document.getElementById("commentSubmitButton");
var commentBlock = document.getElementById("comment-block");
var commentPosts = document.getElementById("commentPosts");
var commentErrorMessage = document.getElementById("commentErrorMessage");



submitButton.onclick = function()
{
	var currentRequest = $.ajax({
		url: "/action/CreateComment",
		method: "get",
		cache: false,
		data: {
			commentText: textArea.value,
			commentAuthor: authorName.value,
			postID: postID
		},

		success: function(html){

			var newPost = commentPosts.getElementsByClassName("post")[0].cloneNode(true);

			newPost.getElementsByClassName("post-name")[0].innerHTML = authorName.value;
			newPost.getElementsByClassName("post-text")[0].innerHTML = textArea.value;
			newPost.getElementsByClassName("post-time")[0].innerHTML = "Только что";

			commentPosts.prepend(newPost);

		},
		error: function(XMLHttpRequest, textStatus, errorThrown) { 
		    commentErrorMessage.style = "display: block;"
		} 
	});
}
