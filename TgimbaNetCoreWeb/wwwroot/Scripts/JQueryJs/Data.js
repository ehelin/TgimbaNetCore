function GetBucketList(userName, sessionSortDirectionKey, sessionSortOperation, token, isMobile) {
    var desc = SessionGetSortDesc(sessionSortDirectionKey);
    var sortOperation = SessionGetSortType(sessionSortOperation);
    var sortString = '';

    if (sortOperation != null && sortOperation != 'null' && sortOperation != '')
        sortString = ' order by ' + sortOperation;

    if (desc != null && desc != 'null' && desc != '' && (desc == true || desc == 'true'))
        sortString = sortString + ' desc';

    var base64UserName = btoa( IfNullGetEmptyString(userName));
    var base64SortString = btoa(IfNullGetEmptyString(sortString));
    var base64Token = btoa(IfNullGetEmptyString(token));
    
    var result = CallService('/Services/BucketListServices.svc/GetBucketListItemsV2',
                            'post',
                             'application/json; charset=utf-8',
                             JSON.stringify({
                                 encodedUserName: base64UserName,
                                 encodedSortString: base64SortString,
                                 encodedToken: base64Token
                             }));
    if (IsLoginNeeded(isMobile, result))
        result = null;

    return result;
}
function GetDashboard() {
    var results = CallService('/Services/BucketListServices.svc/GetDashboard',
                            'post',
                             'application/json; charset=utf-8',
                             JSON.stringify({
                                 test: 'test'
                             }));

    return results;
}
function GlobalLogout() {
    SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_UserName, '');
    SetLocalStorageBucketList(MOBILE_LOCAL_STORAGE_Token, '');
    SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName, '');
    SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token, '');
}
function UpsertBucketListItem(bucketListItems, userName, token, isMobile) {
    var goodDbAction = false;
    var base64Token = btoa(token);
    var base64UserName = btoa(userName);
    var base64BucketListItems = btoa(bucketListItems);

    var result = CallService('/Services/BucketListServices.svc/UpsertBucketListItemV2',
                            'post',
                                'application/json; charset=utf-8',
                                JSON.stringify({
                                    encodedBucketListItems: base64BucketListItems,
                                    encodedUser: base64UserName,
                                    encodedToken: base64Token
                                }));

    if (IsLoginNeeded(isMobile, result))
        result = null;

    return result;
}
function DeleteBucketListItem(dbId, userName, token, isMobile) {
    var base64UserName = btoa(userName);
    var base64Token = btoa(token);

    var result = CallService('/Services/BucketListServices.svc/DeleteBucketListItem',
                        'post',
                         'application/json; charset=utf-8',
                         JSON.stringify({
                             bucketListDbId: dbId,
                             encodedUser: base64UserName,
                             encodedToken: base64Token
                         }));

    if (IsLoginNeeded(isMobile, result))
        result = null;

    return result;
}
function IsLoginNeeded(isMobile, result) {
    var loginIsNeeded = false;

    if (RedirectToLogin(result)) {
        if (isMobile)
            DisplayMobileLogin();
        else
            DisplayDesktopLogin();

        loginIsNeeded = true;
    }
   
    return loginIsNeeded;
}
function ProcessLogin(userName, passWord) {
    var token = Login(userName, passWord);

    return token;
}
function FilterInput(input) {
    if (input != null && input.length > 0) {
        input = input.replace(",", " ");
    }

    return input;
}
function GetBucketListInput(dbId, userName) {
    var input = '';
    var itemNameCtrl = $("#BIItemName");
    var itemDateTimeCtrl = $("#BLIDateTime");
    var itemRankingCtrl = $("#rankingItemSelect");
    var itemAchievedCtrl = $("#biAchievedcb");
    var recordId = $("#BucketListRecordId");
    var itemLatitudeCtrl = $("#BILatitude");
    var itemLongitudeCtrl = $("#BILongitude");

    if ((itemNameCtrl == null || itemNameCtrl.val() == null || itemNameCtrl.val() == '')
        || (itemDateTimeCtrl == null || itemDateTimeCtrl.val() == null || itemDateTimeCtrl.val() == '')
            || (itemRankingCtrl == null || itemRankingCtrl.val() == null || itemRankingCtrl.val() == '')
                || (itemAchievedCtrl == null || itemAchievedCtrl.val() == null || itemAchievedCtrl.val() == '')
                || (itemLatitudeCtrl == null || itemLatitudeCtrl.val() == null || itemLatitudeCtrl.val() == '')
                || (itemLongitudeCtrl == null || itemLongitudeCtrl.val() == null || itemLongitudeCtrl.val() == ''))
    {
        alert('Please enter data before submitting');
        input = null;
    }
    else {
        input = FilterInput(itemNameCtrl.val());
        input = input + "," + itemDateTimeCtrl.val();
        input = input + "," + itemRankingCtrl.val();

        if (itemAchievedCtrl.is(":checked"))
            input = input + ",1";
        else
            input = input + ",0";

        input = input + "," + itemLatitudeCtrl.val();
        input = input + "," + itemLongitudeCtrl.val();
        input = input + "," + recordId.val();

        input = "," + input + "," + userName + "," + ";";
    }

    return input;
}
function GetBucketListItem(data, index) {
    var item = null;

    for (var ctr = 0; ctr < (data.length) ; ctr++) {
        var row = data[ctr].split(',');
        var curId = row[7];

        if (curId == index) {
            item = data[ctr];
            break;
        }
    }

    return item;
}
function GetRankingOptions() {
    var data = new Array();
    data[0] = '';

    //list item, date entered, rank, achieved
    data[1] = 'Hot';
    data[2] = 'Warm';
    data[3] = 'Cool';

    return data;
}
function GetTestBucketListData() {
    var data = new Array();
    data[0] = '';

    //list item, date entered, rank, achieved, id
    data[1] = 'Climb Mt Everest,1/1/1995,Hot,1,1;';
    data[2] = 'Run with the bulls in spain,12/15/1998,Warm,0,2;';
    data[3] = 'Sky Diver,8/5/2001,Cool,1,3;';
    data[4] = 'Drive race car,9/10/2003,Hot,0,4;';
    data[5] = 'Drive motorcycle race,7/11/2005,Warm,0,5;';
    data[6] = '1,Mon 7/11/2005,Cool,1,6;';
    data[7] = '2,Mon 7/11/2005,Hot,0,7;';

    return data;
}
function GetDateTime() {
    var date = new Date();

    var month = date.getMonth() + ONE;  //zero based
    var day = date.getDate();
    var year = date.getFullYear();

    var dateStr = month + '/' + day + '/' + year;

    return dateStr;
}
function GetSortDescAscValue(sessionKey) {
    var descValue = null;
    var cb = $("#biSortDesccb");

    if (cb == null)
        throw ERROR_0001

    if (cb.is(":checked"))
        descValue = true;
    else
        descValue = false;

    return descValue;
}
