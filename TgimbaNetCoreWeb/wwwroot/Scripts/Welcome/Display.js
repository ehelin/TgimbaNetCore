var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
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
		
Display.LoadView = function(view, htmlContent) { 
    var contentDiv = Display.GetContentDiv();  
    CommonServerCalls.GetView(view, contentDiv, htmlContent);
};

Display.GetContentDiv = function() {      
    var contentDiv = document.getElementById(WELCOME_CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'Display.js', 'contentDiv');

    return contentDiv;
};
