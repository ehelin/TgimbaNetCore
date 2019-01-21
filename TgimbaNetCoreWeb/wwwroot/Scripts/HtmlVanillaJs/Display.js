var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
	contentDiv.innerHTML = loadedView;
	Display.SetTitleLogic(view);	

	if (htmlContent) {
		Display.HtmlContent = htmlContent;
		// TODO - load view w/Content
	}
};
		
Display.LoadView = function(view, htmlContent) { 
    var contentDiv = Display.GetContentDiv();  
    ServerCalls.GetView(view, contentDiv, htmlContent);
};

Display.SetTitleLogic = function(view) {			   
	if (view === VIEW_LOGIN) {
		Display.SetTitle(LOGIN_VIEW_DIV, VANILLA_JAVASCRIPT_LOGIN_TITLE);
	}
	else if (view === VIEW_REGISTRATION) {
		Display.SetTitle(REGISTRATION_VIEW_DIV, VANILLA_JAVASCRIPT_REGISTRATION_TITLE);
	}
	else if (view === VIEW_MENU) {
		Display.SetTitle(MENU_VIEW_DIV, VANILLA_JAVASCRIPT_MENU_TITLE);		
	}
	else if (view === VIEW_MAIN) {
		Display.SetTitle(MAIN_VIEW_DIV, VANILLA_JAVASCRIPT_MAIN_TITLE);
	}
	else {
		Error('Unknown view');
	}
}

Display.SetTitle = function(divName, title) {	
	var titleHolder = document.getElementById(divName);
	titleHolder.innerHTML = title;	 
}

Display.GetContentDiv = function() {      
    var contentDiv = document.getElementById(CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'Display.js', 'contentDiv');

    return contentDiv;
};
