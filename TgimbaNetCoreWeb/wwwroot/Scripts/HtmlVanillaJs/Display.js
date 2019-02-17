var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
	contentDiv.innerHTML = loadedView;
	Display.SetTitleLogic(view);	

	if (htmlContent) {
		if (view === VIEW_MAIN_EDIT) {
			Display.BindEditView(htmlContent);
		}
		// load bucket list item view
		else {
			Display.HtmlContent = htmlContent;
			LoadMainPage();
		}
	}
};

Display.BindEditView = function (htmlContent) {	  
	SetElementValue('USER_CONTROL_EDIT_ITEM_NAME', htmlContent[0]);		
	SetElementValue('USER_CONTROL_EDIT_DATE_CREATED', htmlContent[1]);
	SetElementValue('USER_CONTROL_EDIT_ITEM_CATEGORY', htmlContent[2]);
	SetElementValue('USER_CONTROL_EDIT_COMPLETED', htmlContent[3]);
	SetElementValue('USER_CONTROL_EDIT_LATITUDE', htmlContent[4]);
	SetElementValue('USER_CONTROL_EDIT_LONGITUDE', htmlContent[5]);
	SetElementValue('USER_CONTROL_EDIT_DBID', htmlContent[6]);
	SetElementValue('USER_CONTROL_EDIT_USERNAME', htmlContent[7]);	
}
		
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
	else if (view === VIEW_MAIN_ADD) {
		Display.SetTitle(ADD_VIEW_DIV, VANILLA_JAVASCRIPT_MAIN_ADD_TITLE);
		MainController.SetAddViewDate();
	}
	else if (view === VIEW_MAIN_EDIT) {
		Display.SetTitle(EDIT_VIEW_DIV, VANILLA_JAVASCRIPT_MAIN_EDIT_TITLE);	
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
