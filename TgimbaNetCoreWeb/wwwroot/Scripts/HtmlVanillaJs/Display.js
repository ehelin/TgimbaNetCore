var Display = {};

Display.SetView = function(view, contentDiv, loadedView) {
	contentDiv.innerHTML = loadedView;	

	if (view === VIEW_LOGIN) 
	{			
		Display.SetTitle(LOGIN_VIEW_DIV, VANILLA_JAVASCRIPT_LOGIN_TITLE);
	} 
	else if (view === VIEW_REGISTRATION) 
	{										   
		Display.SetTitle(REGISTRATION_VIEW_DIV, VANILLA_JAVASCRIPT_REGISTRATION_TITLE);
	} 
	else {
		Error('Unknown view');
	}
};

Display.SetTitle = function(divName, title) {	
	var titleHolder = document.getElementById(divName);
	titleHolder.innerHTML = title;	 
}

Display.LoadView = function(view) { 
    var contentDiv = Display.GetContentDiv();  
    ServerCalls.GetView(view, contentDiv);
};

Display.GetContentDiv = function() {      
    var contentDiv = document.getElementById(CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'Display.js', 'contentDiv');

    return contentDiv;
};
