var Display = {};
			
Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
	contentDiv.html(loadedView);	
	Display.SetTitleLogic(view);	

	if (htmlContent) {
		Display.HtmlContent = htmlContent;
		LoadMainPage();
	}
};

Display.SetTitleLogic = function(view) {			   
	if (view === VIEW_LOGIN)  {				   
		$('#' + LOGIN_VIEW_DIV).html(JQUERY_LOGIN_TITLE);
	}	
	else if (view === VIEW_REGISTRATION) {
		$('#' + REGISTRATION_VIEW_DIV).html(JQUERY_REGISTRATION_TITLE);
	}	 
	else if (view === VIEW_MENU) {									  
		$('#' + MENU_VIEW_DIV).html(JQUERY_MENU_TITLE);	
	}
	else if (view === VIEW_MAIN) {										
		$('#' + MAIN_VIEW_DIV).html(JQUERY_MAIN_TITLE);
	}
	// TODO - implement this one
	else if (view === VIEW_MAIN_ADD) {
		Display.SetTitle(ADD_VIEW_DIV, VANILLA_JAVASCRIPT_MAIN_ADD_TITLE);
		MainController.SetAddViewDate();
	}
	else {
		Error('Unknown view');
	}
}

Display.SetTitle = function(divName, title) {	
	var titleHolder = document.getElementById(divName);
	titleHolder.innerHTML = title;	 
}		

Display.LoadView = function(view, htmlContent) { 	
    var contentDiv = Display.GetContentDiv();

    ServerCalls.GetView(view, contentDiv, htmlContent);
}

Display.GetContentDiv = function() {   
	var contentDiv = $('#' + CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'JQuery->Display.js', 'contentDiv');

    return contentDiv;
}	 

