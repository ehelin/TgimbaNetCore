function ApplyEventHandlers() {		
    //login
    $("#loginSubmitClick").unbind("click").bind("click", LoginButtonSubmitClick); 
    $("#loginCancelClick").unbind("click").bind("click", LoginButtonCancelClick);

    //$("#registerDesktopClick").unbind("click").bind("click", registerDesktopClick);
    //$("#registerDesktopSubmitClick").unbind("click").bind("click", registerDesktopSubmitClick);
    //$("#registerDesktopCancel").unbind("click").bind("click", registerDesktopCancel);

    //menu screen events
    //$("#MenuRequest").unbind("click").bind("click", ShowMenuClick);
    //$("#CancelMenuDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    //$("#AddBucketListItem").unbind("click").bind("click", AddBucketListItemClick);
    //$("#SortBucketListItem").unbind("click").bind("click", SortBucketListItemClick);
    //$("#LogOut").unbind("click").bind("click", LogoutItemClick);
    //$("#TravelingSalesman").unbind("click").bind("click", TravelingSalesmanClick);

    //algorithm
    //$("#CancelAlgorithmDisplay").unbind("click").bind("click", GlobalCancelEventClick);

    //add bi screen events
    //$("#CancelAddItemDisplay").unbind("click").bind("click", GlobalCancelEventClick);

    //edit screen events
    //$("#EditBIButtonSubmit").unbind("click").bind("click", EditBIButtonSubmitClick);

    //search events
    //$("#searchButtonRequest").unbind("click").bind("click", SearchButtonRequestClick);
    //$("#CancelSearchResultsDisplay").unbind("click").bind("click", GlobalCancelEventClick);
    //$("#searchButtonSubmit").unbind("click").bind("click", SearchButtonSubmitClick);
}

//Login Events ---------------------------------------
function LoginButtonCancelClick() {
	alert('LoginButtonCancelClick');
}

function LoginButtonSubmitClick() {			
	alert('LoginButtonSubmitClick');
    //var userName = $("#loginDesktopUserName").val();
    //var passWord = $("#loginDesktopPassWord").val();

    //if (userName == null || userName == '' || passWord == null || passWord == '') {
    //    alert("Please enter a username and password");
    //}
    //else {
    //    var token = ProcessLogin(userName, passWord);

    //    if (token != null && token.length > 0) {
    //        var listItems = GetBucketList(userName, DESKTOP_SESSION_clsSortDesc, DESKTOP_SESSION_clsSortTypeKey, token, false);

    //        SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_UserName, userName);
    //        SetLocalStorageBucketList(DESKTOP_LOCAL_STORAGE_Token, token);

    //        ResetPageDivs();
    //        if (listItems != null && listItems[0] != 'No Items')
    //            DisplayBucketList(listItems);
    //    }
    //    else {
    //        $("#loginDesktopPassWord").val('');
    //        alert('Error: Username/Password are not found or are not correct');
    //    }
    //}

    //ApplyEventHandlers();
}