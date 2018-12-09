var Display = {};

Display.LoadView = function(view) { 	
    var contentDiv = Display.GetContentDiv();

    GetView(view, contentDiv);

	// TODO - best place for this?
	//ApplyEventHandlers();
}

Display.GetContentDiv = function() {   
	var contentDiv = $('#csHtmlContentDiv');
    
    isNullUndefined(contentDiv, 'JQuery->Display.js', 'contentDiv');

    return contentDiv;
}	 

