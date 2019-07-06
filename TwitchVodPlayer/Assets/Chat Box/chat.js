loadingDisplay = "Loading Chat...";
	
var maxChatLinesDisplayed = 20;

var currentLineNumber = 0;

//

var chatBoxDiv = document.getElementById('chatBox');

hideScrollbars();

//

function setChatBackgroundColor (newColor){
	document.body.style.backgroundColor = newColor;
}

function addChatLine (chatLine, willScroll) {
	var chatLineDiv = document.createElement('div');
	chatLineDiv.id = 'chatLine' + currentLineNumber;
	chatBoxDiv.appendChild(chatLineDiv);
	
	document.getElementById('chatLine' + currentLineNumber).innerHTML = chatLine;
	
	currentLineNumber++;
	
	if(currentLineNumber > 20000){
		clearChatBox();
	}else if(currentLineNumber > maxChatLinesDisplayed){
		var topChatLine = document.getElementById('chatLine' + (currentLineNumber-maxChatLinesDisplayed-1));
		chatBoxDiv.removeChild(topChatLine);
	}
	
	if(willScroll){
		scrollToBottom();
	}
}

function clearChatBox () {
	chatBoxDiv.innerHTML = "";
	currentLineNumber = 0;
}

function showLoadingDisplay () {
	clearChatBox();
	addChatLine(loadingDisplay, true);
}

function scrollToBottom(){
	window.scrollTo(0, document.querySelector("#chatBox").scrollHeight);
}

function showScrollbars (){
	document.body.style.overflow = "visible";
}
function hideScrollbars (){
	document.body.style.overflow = "hidden";
}

function imgError(image) {
    image.onerror = "";
    image.src = "./placeholder.png";
    return true;
}