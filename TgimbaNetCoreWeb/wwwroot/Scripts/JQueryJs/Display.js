var Display = {};
			
Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
	contentDiv.html(loadedView);	
	Display.SetTitleLogic(view);	

	if (htmlContent) {
		if (view === VIEW_MAIN_EDIT) {
			Display.BindEditView(htmlContent);
		}
		// load bucket list item view
		else {
			Display.HtmlContent = htmlContent;
			LoadMainPage();

			// srch results	cancel			
			var cancelSrchResultsContainer = document.getElementById('cancelSrchResults');
			isNullUndefined(cancelSrchResultsContainer, 'Display.js', 'cancelSrchResults does not exist');
			var isSearch = SessionGetIsSearch(SESSION_IS_SRCH_VIEW);
			if (isSearch && isSearch === 'true') {
				cancelSrchResultsContainer.style.display = "block";
			} else {
				cancelSrchResultsContainer.style.display = "none";
			}
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
		$('#' + ADD_VIEW_DIV).html(JQUERY_ADD_TITLE);
		MainController.SetAddViewDate();
	}
	else if (view === VIEW_MAIN_EDIT) {
		$('#' + EDIT_VIEW_DIV).html(JQUERY_EDIT_TITLE);
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

