var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent, srchView) {	
	contentDiv.innerHTML = loadedView;
	
    if (view === VIEW_MAIN_ADD) {
	    MainController.SetAddViewDate();
	}
    else if (view === VIEW_SORT) {
        Display.BindSortView();  
    }

	if (htmlContent) {
		if (view === VIEW_MAIN_EDIT) {
			Display.BindEditView(htmlContent);
		}
		// load bucket list item view
		else {
            Display.BindMainView(htmlContent);
            Display.BindSearchView(); 
        }
	}
};

Display.BindSearchView = function() 
{	  
    var availableSearchingAlgorithms = SessionGet(SESSION_AVAILABLE_SEARCHING_ALGORITHMS);
    var searchingAlgorithmsCtrl = document.getElementById('hvJsSearchAvailableSearchAlgorithmsSelect');

    isNullUndefined(searchingAlgorithmsCtrl, 'Display.js', 'searchingAlgorithmsCtrl');

    availableSearchingAlgorithms = availableSearchingAlgorithms.split(",")

    for(var i=0; i<availableSearchingAlgorithms.length; i++)
    {
        var searchCtrlLength = searchingAlgorithmsCtrl.options.length;
        var currentOption = availableSearchingAlgorithms[i];
        searchingAlgorithmsCtrl.options[searchCtrlLength] = new Option(currentOption, currentOption);
    }	
}

Display.BindSortView = function() 
{	  
    var availableSortingAlgorithms = SessionGet(SESSION_AVAILABLE_SORTING_ALGORITHMS);
    var sortingAlgorithmsCtrl = document.getElementById('hvJsSortAvailableSortAlgorithmsSelect');

    isNullUndefined(sortingAlgorithmsCtrl, 'Display.js', 'sortingAlgorithmsCtrl');

    availableSortingAlgorithms = availableSortingAlgorithms.split(",")

    for(var i=0; i<availableSortingAlgorithms.length; i++)
    {
        var sortingCtrlLength = sortingAlgorithmsCtrl.options.length;
        var currentOption = availableSortingAlgorithms[i];
        sortingAlgorithmsCtrl.options[sortingCtrlLength] = new Option(currentOption, currentOption);
    }	
}

Display.BindMainView = function(htmlContent) 
{
	Display.HtmlContent = htmlContent;
	LoadMainPage();

	// srch results	cancel			
    var cancelSrchResultsContainer = document.getElementById('cancelSrchResults');
    var srchTermTypeLabel = document.getElementById('USER_CONTROL_SRCH_TERM_TYPE_LABEL'); 
	isNullUndefined(cancelSrchResultsContainer, 'Display.js', 'cancelSrchResults does not exist');
    var isSearch = SessionGet(SESSION_IS_SRCH_VIEW);
	var mainHeaderDiv = document.getElementById("tgimbaMainHeader");

	if (isSearch && isSearch === 'true') {
		cancelSrchResultsContainer.classList.add('tgimbaMainheadercenterdisplay');
        cancelSrchResultsContainer.classList.remove('tgimbaMainheadercenterhidden');
        srchTermTypeLabel.innerHTML = MainController.GetSearchTermAndType();
	} else {
		cancelSrchResultsContainer.classList.add('tgimbaMainheadercenterhidden');
        cancelSrchResultsContainer.classList.remove('tgimbaMainheadercenterdisplay');
        srchTermTypeLabel.innerHTML = '';
	}
};

Display.BindEditView = function(htmlContent) 
{	  
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
