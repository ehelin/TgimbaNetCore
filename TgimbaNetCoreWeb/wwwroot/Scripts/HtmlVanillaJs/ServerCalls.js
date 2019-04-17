var ServerCalls = {};

ServerCalls.IsMobile = function (userAgent) {
    try {
        return ServerCall.Get(BUCKET_LIST_ISMOBILE + userAgent)
                .then(
                function (response) {
                    return response;
                });
    } catch (ex) {
        return Error_Handler('ServerCalls.IsMobile(arg) - Error: ' + ex);
    }
};

ServerCalls.GetView = function(viewUrl, contentDiv, htmlContent) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
				Display.SetView(viewUrl, contentDiv, response, htmlContent);
            });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetView(3 args) - ' + view + ' - Error: ' + ex);
    }
};
	  
ServerCalls.GetBucketListItems = function(url, params, sortColumn) {
	var formData = new FormData();
	var userName = params[0];	 
	var token = params[1];
	var sortColumn = sortColumn && sortColumn.length > 0 ? sortColumn : '';
	var srchTerm = params[2] && params[2].length > 0 ? params[2] : '';
										
	var queryUrl = BUCKET_LIST_PROCESS_GET
				+ "?encodedUserName=" + btoa(userName)
						+ "&encoderedSortString=" + btoa(sortColumn)
							+ "&encodedToken=" + btoa(token)
								+ "&encodedSrchTerm=" + btoa(srchTerm);

	return ServerCall.Get(queryUrl)
			.then(
				function(response) {
					// TODO - check for no response?										 
					isNullUndefined(response); 
					var bucketListItems = JSON.parse(response);
					Display.LoadView(VIEW_MAIN, bucketListItems);
				});
};

ServerCalls.EditBucketListItem = function (url, params) {
	var formData = new FormData();
	var user = SessionGetUsername(SESSION_USERNAME);

	formData.append("Name", params[0]);
	formData.append("DateCreated", params[1]);
	formData.append("BucketListItemType", params[2]);
	formData.append("Completed", params[3]);
	formData.append("Latitude", params[4]);
	formData.append("Longitude", params[5]);
	formData.append("DatabaseId", params[6]);
	formData.append("UserName", params[7]);
	formData.append("encodedUser", btoa(user));
	formData.append("encodedToken", btoa(SessionGetToken(SESSION_TOKEN)));

	return ServerCall.Post(url, formData)
		.then(
			function (response) {
				// TODO - convert response to boolean
				if (response && response === "true") {
					MainController.Index();
				} else {
					// TODO - handle error
					alert('Add failed');
				}
			});
};

ServerCalls.AddBucketListItem = function (url, params) {
	var formData = new FormData();	 
	var user = SessionGetUsername(SESSION_USERNAME);

	formData.append("Name", params[0]);
	formData.append("DateCreated", params[1]);	
	formData.append("BucketListItemType", params[2]);
	formData.append("Completed", params[3]);
	formData.append("Latitude", params[4]);
	formData.append("Longitude", params[5]);
	formData.append("DatabaseId", '');		
	formData.append("UserName", user);	  
	formData.append("encodedUser", btoa(user)); 
	formData.append("encodedToken", btoa(SessionGetToken(SESSION_TOKEN)));			  

	return ServerCall.Post(url, formData)
		.then(
			function (response) {
				// TODO - convert response to boolean
				if (response && response === "true") {	  
					MainController.Index();		           
				} else {
					// TODO - handle error
					alert('Add failed');
				}
			});
};

ServerCalls.DeleteBucketListItem = function (url, dbId) {
	var formData = new FormData();
	var user = SessionGetUsername(SESSION_USERNAME);
													 
	formData.append("dbId", dbId);
	formData.append("encodedUser", btoa(user));
	formData.append("encodedToken", btoa(SessionGetToken(SESSION_TOKEN)));

	return ServerCall.Delete(url, formData)
		.then(
			function (response) {
				// TODO - convert response to boolean
				if (response && response === "true") {
					MainController.Index();
				} else {
					// TODO - handle error
					alert('Add failed');
				}
			});
};

ServerCalls.ProcessLogin = function(view, params) {
	var formData = new FormData();
	var userName = params[0];	 
	var passWord = params[1];

	formData.append("user", btoa(userName));
	formData.append("pass", btoa(passWord));

    return ServerCall.Post(view, formData)
        .then(
        function (token) {
            if (token !== null && token !== undefined && token.length > 0) {
				SessionSetToken(SESSION_TOKEN, token);
				SessionSetUsername(SESSION_USERNAME, userName);
				MainController.Index();		           
            } else {
                // TODO - reset user and pass text boxes to empty
                alert('Username and/or password is incorrect');                
            }
        });
};
						  
ServerCalls.ProcessRegistration = function (view, params) {
	var formData = new FormData();

	formData.append("user", btoa(params[0]));
	formData.append("email", btoa(params[1]));
	formData.append("pass", btoa(params[2]));

	return ServerCall.Post(view, formData)
		.then(
			function (goodRegistration) {
				if (goodRegistration !== null
					&& goodRegistration !== undefined
					&& goodRegistration !== ''
					&& goodRegistration === 'true')  // TODO - convert boolean from string
				{
					Display.LoadView(VIEW_LOGIN, null);
				} else {
					alert('User is not registered');
				}
			});
};

