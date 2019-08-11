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
    WelcomeServerCalls.GetSystemStatistics();
};

Display.SetSystemStatistics = function (systemStatistics) {
    Display.SetSystemStats(systemStatistics.systemStats);
    Display.SetDiagramConnectionLines(systemStatistics.systemStats);
    Display.SetSystemBuildStats(systemStatistics.systemBuildStats);
    setTimeout(Display.Refresh, 1000);
}

Display.SetSystemBuildStats = function (systemBuildStatistics) {
    var systemBuildStatisticData = document.getElementById('systemBuildStatisticsData');

    if (systemBuildStatisticData) {
        var tbl = Display.BuildSystemBuildStatsTableHeader();
        for (var i = 0; i < systemBuildStatistics.length; i++) {
            tbl += '<tr>';

            tbl += '<td>' + systemBuildStatistics[i].start + '</td>';
            tbl += '<td>' + systemBuildStatistics[i].end + '</td>';
            tbl += '<td>' + systemBuildStatistics[i].buildNumber + '</td>';
            tbl += '<td>' + systemBuildStatistics[i].status + '</td>';

            tbl += '</tr>';
        }
        tbl += '</table>';

        systemBuildStatisticData.innerHTML = tbl;
    }
}

Display.BuildSystemBuildStatsTableHeader = function () {
    var tblHdr = '<table><tr><td colspan="4">System Builds</td></tr><tr>';

    tblHdr += '<td class="hdrCol">Start</td>';
    tblHdr += '<td class="hdrCol">End</td>';
    tblHdr += '<td class="hdrCol">Build</td>';
    tblHdr += '<td class="hdrCol">Status</td>';

    tblHdr += '</tr>';

    return tblHdr;
}

// TODO - collapsed this and the display refresh message
Display.SetDiagramConnectionLines = function (systemStatistics) {
    var line1 = document.getElementById("statusLine1");
    var line2 = document.getElementById("statusLine2");
    var line3 = document.getElementById("statusLine3");

    if (line1 && line2 && line3)
    {
        if (systemStatistics[0].webSiteIsUp === true
             && systemStatistics[0].azureFunctionIsUp === true) {
            SessionSetSystemWebSiteAzureFunctionIsUp(SESSION_CLIENT_WEB_AZURE_IS_UP, true);
            line1.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
        } else {
            SessionSetSystemWebSiteAzureFunctionIsUp(SESSION_CLIENT_WEB_AZURE_IS_UP, false);
            line1.style.cssText = WELCOME_STATUS_LINE_RED_ANGLE;
        }

        if (systemStatistics[0].databaseIsUp === true
            && systemStatistics[0].azureFunctionIsUp === true) {
            SessionSetSystemDbAzureFunctionIsUp(SESSION_CLIENT_DB_AZURE_IS_UP, true);
            line2.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
        } else {
            SessionSetSystemDbAzureFunctionIsUp(SESSION_CLIENT_DB_AZURE_IS_UP, false);
            line2.style.cssText = WELCOME_STATUS_LINE_RED_ANGLE;
        }

        if (systemStatistics[0].webSiteIsUp === true
                && systemStatistics[0].databaseIsUp === true) {
            SessionSetSystemDbWebsiteIsUp(SESSION_CLIENT_DB_WEB_IS_UP, true);
            line3.style.cssText = WELCOME_STATUS_LINE_GREEN_HORIZ;
        } else {
            SessionSetSystemDbWebsiteIsUp(SESSION_CLIENT_DB_WEB_IS_UP, false);
            line3.style.cssText = WELCOME_STATUS_LINE_RED_HORIZ;
        }
    }
}

Display.SetSystemStats = function (systemStatistics) {
    var systemStatisticData = document.getElementById('systemStatisticsData');

    if (systemStatisticData) {
        var tbl = Display.BuildSystemStatsTableHeader();
        for (var i = 0; i < systemStatistics.length; i++) {
            tbl += '<tr>';

            if (systemStatistics[i].webSiteIsUp === true) {
                tbl += '<td class="circleGreen"></td>';
            } else {
                tbl += '<td class="circleRed"></td>';
            }

            if (systemStatistics[i].databaseIsUp === true) {
                tbl += '<td class="circleGreen"></td>';
            } else {
                tbl += '<td class="circleRed"></td>';
            }

            if (systemStatistics[i].azureFunctionIsUp === true) {
                tbl += '<td class="circleGreen"></td>';
            } else {
                tbl += '<td class="circleRed"></td>';
            }
            tbl += '<td>' + systemStatistics[i].created + '</td>';

            tbl += '</tr>';
        }
        tbl += '</table>';

        systemStatisticData.innerHTML = tbl;
    }
}

Display.BuildSystemStatsTableHeader = function () {
    var tblHdr = '<table><tr><td colspan="4">System Status Checks</td></tr><tr>';

    tblHdr += '<td class="hdrCol">Site</td>';
    tblHdr += '<td class="hdrCol">Db</td>';
    tblHdr += '<td class="hdrCol">Azure</td>';
    tblHdr += '<td class="hdrCol">Check Time</td>';

    tblHdr += '</tr>';

    return tblHdr;
}

// TODO - fix refresh to accurately show failed or up state
Display.Refresh = function () {
    var line1 = document.getElementById("statusLine1");
    var line2 = document.getElementById("statusLine2");
    var line3 = document.getElementById("statusLine3");
    var webAzureFuncIsUp = SessionGetSystemWebSiteAzureFunctionIsUp(SESSION_CLIENT_WEB_AZURE_IS_UP);
    var dbAzureFuncIsUp = SessionGetSystemDbAzureFunctionIsUp(SESSION_CLIENT_DB_AZURE_IS_UP);
    var dbWebIsUp = SessionGetSystemDbWebsiteIsUp(SESSION_CLIENT_DB_WEB_IS_UP);

    if (line1 && line2 && line3)
    {
        if (line1.style.cssText === WELCOME_STATUS_LINE_GREEN_ANGLE 
            || line1.style.cssText === WELCOME_STATUS_LINE_RED_ANGLE)
        {
            line1.style.cssText = WELCOME_STATUS_LINE_BLACK_ANGLE;
            line2.style.cssText = WELCOME_STATUS_LINE_BLACK_ANGLE;
            line3.style.cssText = WELCOME_STATUS_LINE_BLACK_HORIZ;
        } else {
            if (webAzureFuncIsUp && JSON.parse(webAzureFuncIsUp) === true) {
                line1.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
            } else {
                line1.style.cssText = WELCOME_STATUS_LINE_RED_ANGLE;
            }

            if (dbAzureFuncIsUp && JSON.parse(dbAzureFuncIsUp) === true) {
                line2.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
            } else {
                line2.style.cssText = WELCOME_STATUS_LINE_RED_ANGLE;
            }

            if (dbWebIsUp && JSON.parse(dbWebIsUp) === true) {
                line3.style.cssText = WELCOME_STATUS_LINE_GREEN_ANGLE;
            } else {
                line3.style.cssText = WELCOME_STATUS_LINE_RED_ANGLE;
            }
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
