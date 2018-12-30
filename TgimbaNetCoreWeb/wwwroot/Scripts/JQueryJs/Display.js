var Display = {};

Display.LoadView = function(view) { 	
    var contentDiv = Display.GetContentDiv();

    ServerCalls.GetView(view, contentDiv);
}

Display.GetContentDiv = function() {   
	var contentDiv = $('#' + CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'JQuery->Display.js', 'contentDiv');

    return contentDiv;
}	 

