var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent, srchView) {	
	contentDiv.innerHTML = loadedView;
	
    if (view === VIEW_MAIN_ADD) {
	    MainController.SetAddViewDate();
	}

	if (htmlContent) {
		if (view === VIEW_MAIN_EDIT) {
			Display.BindEditView(htmlContent);
		}
		// load bucket list item view
		else
		{
			Display.HtmlContent = htmlContent;
			LoadMainPage();

			// srch results	cancel			
			var cancelSrchResultsContainer = document.getElementById('cancelSrchResults');
			isNullUndefined(cancelSrchResultsContainer, 'Display.js', 'cancelSrchResults does not exist');
			var isSearch = SessionGetIsSearch(SESSION_IS_SRCH_VIEW);
			var mainHeaderDiv = document.getElementById("tgimbaMainHeader");

			if (isSearch && isSearch === 'true') {
			    cancelSrchResultsContainer.classList.add('tgimbaMainheadercenterdisplay');
			    cancelSrchResultsContainer.classList.remove('tgimbaMainheadercenterhidden');
			} else {
			    cancelSrchResultsContainer.classList.add('tgimbaMainheadercenterhidden');
			    cancelSrchResultsContainer.classList.remove('tgimbaMainheadercenterdisplay');
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
		
Display.LoadView = function(view, htmlContent) { 
    var contentDiv = Display.GetContentDiv();  
    ServerCalls.GetView(view, contentDiv, htmlContent);
};

Display.SetTitle = function(divName, title) {	
	var titleHolder = document.getElementById(divName);
	titleHolder.innerHTML = title;	 
}

Display.GetContentDiv = function() {      
    var contentDiv = document.getElementById(CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'Display.js', 'contentDiv');

    return contentDiv;
};
