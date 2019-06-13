var Display = {};

Display.HtmlContent = {};

Display.SetView = function (view, contentDiv, loadedView, htmlContent) {	
	contentDiv.innerHTML = loadedView;
	
	var systemStatsDiv = document.getElementById('systemStatistics');
	if (systemStatsDiv) {
	    systemStatsDiv.innerHTML = "Loading...";
	    ServerCalls.GetAjaxView(VIEW_PARTIAL_SYSTEM_STATISTICS, systemStatsDiv, null);
	}
};

Display.SetAjaxView = function (view, contentDiv, loadedView, htmlContent) {
    contentDiv.innerHTML = loadedView;
    //setTimeout(Display.Refresh, 1000);
};

Display.Refresh = function () {
    var horizontalCells = document.getElementsByClassName('horizontalLineOff');
    var verticalCells = document.getElementsByClassName('verticalLineOff');
    var verticalCellCssClassName = 'verticalLineOn';
    var horizontalCellCssClassName = 'horizontalLineOn';

    if (horizontalCells.length === 0) {
        horizontalCells = document.getElementsByClassName('horizontalLineOn');
        verticalCells = document.getElementsByClassName('verticalLineOn');

        verticalCellCssClassName = 'verticalLineOff';
        horizontalCellCssClassName = 'horizontalLineOff';
    }

    while (horizontalCells.length > 0) {
        horizontalCells[0].className = horizontalCellCssClassName;
    }

    while (verticalCells.length > 0) {
        verticalCells[0].className = verticalCellCssClassName;
    }
    
    setTimeout(Display.Refresh, 1000);
};
		
Display.LoadView = function(view, htmlContent) { 
    var contentDiv = Display.GetContentDiv();  
    ServerCalls.GetView(view, contentDiv, htmlContent);
};

Display.GetContentDiv = function() {      
    var contentDiv = document.getElementById(WELCOME_CONTENT_DIV);
    
    isNullUndefined(contentDiv, 'Display.js', 'contentDiv');

    return contentDiv;
};
