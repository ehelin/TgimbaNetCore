function PerformSearch(sortSessionDescKey, sortSessionTypeKey, srchTrmSession, userName, token, isMobile)
{
    var srchTrm = GetCoordinatedSearchTerm(srchTrmSession);
    srchTrm = srchTrm.toLowerCase();
    var results = null;

    var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, isMobile);

    if (listItems != null) {
        results = Search(srchTrmSession, listItems, srchTrm);
    }
    
    return results;
}
function Search(srchTrmSession, data, srchTrm) {
    var results = '';

    for (var ctr = 0; ctr < data.length; ctr++) {
        var curLine = data[ctr];
        var curLineArr = curLine.split(',');

        if (curLine.toLowerCase().indexOf(srchTrm) != -1) {
            results = results + curLineArr[1] + ',' + curLineArr[7] + ';';
        }
    }

    return results;
}
function GetCoordinatedSearchTerm(srchTrmSession) {
    var srchTrm = null;
    var srchTrmFromField = $("#SearchTerm").val();
    var noUsrSchTrm = null;
    var noSessionSchTrm = null;

    if (srchTrmFromField == null
            || srchTrmFromField == 'undefined'
                || srchTrmFromField == '')
        noUsrSchTrm = 'true';

    if (srchTrmSession == null
            || srchTrmSession == 'undefined'
                || srchTrmSession == '')
        noSessionSchTrm = 'true';

    if (noUsrSchTrm == 'true' && noSessionSchTrm == 'true')
        alert('Please enter search term');

    else if (noUsrSchTrm != 'true')
        srchTrm = srchTrmFromField;

    else if (noUsrSchTrm == 'true' && noSessionSchTrm != 'true')
        srchTrm = srchTrmSession;

    return srchTrm;
}
