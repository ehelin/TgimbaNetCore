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
    setTimeout(Display.Refresh, 1000);
};

Display.Refresh = function () {
    var line1 = document.getElementById("statusLine1");
    var line2 = document.getElementById("statusLine2");
    var line3 = document.getElementById("statusLine3");

    if (line1 && line2 && line3)
    {
        if (line1.style.cssText === WELCOME_STATUS_LINE_GREEN_ANGLE)
        {
            line1.style.cssText = WELCOME_STATUS_LINE_BLACK_ANGLE;
            line2.style.cssText = WELCOME_STATUS_LINE_BLACK_ANGLE;
            line3.style.cssText = WELCOME_STATUS_LINE_BLACK_HORIZ;
        } else {
            line1.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
            line2.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
            line3.style.cssText = WELCOME_STATUS_LINE_GREEN_HORIZ;
        }
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
