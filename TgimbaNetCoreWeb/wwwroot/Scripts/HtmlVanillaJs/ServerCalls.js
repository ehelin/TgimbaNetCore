var ServerCalls = {};

ServerCalls.GetView = function(viewUrl, contentDiv, htmlContent) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
				Display.SetView(viewUrl, contentDiv, response, htmlContent);
            });
    }
    catch (ex) {
        return Error_Handler('LoadView(view) - ' + view + ' - Error: ' + ex);
    }
};
	  
ServerCalls.GetBucketListItems = function(url, params) {
	var formData = new FormData();
	var userName = params[0];	 
	var token = params[1];

	var queryUrl = BUCKET_LIST_PROCESS_GET + "?encodedUserName=" + btoa(userName) + "&encoderedSortString=" + btoa("") + "&encodedToken=" + btoa(token);

	return ServerCall.Get(queryUrl)
			.then(
				function(response) {
					// TODO - check for no response?										 
					isNullUndefined(response); 
					var bucketListItems = JSON.parse(response);
					Display.LoadView(VIEW_MAIN, bucketListItems);
				});
};

ServerCalls.AddBucketListItem = function (url, params) {
	alert('ServerCalls.AddBucketListItem() -> Implement');
	// TODO convert params (use process login as example) and post.
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
				// TODO - remove alert 
                alert('Username is logged in');   

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
					alert('User is registered');
					Display.LoadView(VIEW_LOGIN, null);
				} else {
					alert('User is not registered');
				}
			});
};

