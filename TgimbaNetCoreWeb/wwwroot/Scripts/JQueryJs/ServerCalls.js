var ServerCalls = {};

ServerCalls.GetView = function(viewUrl, contentDiv, htmlContent) {
    var loadedView = CallService(viewUrl, 'get');
	Display.SetView(viewUrl, contentDiv, loadedView, htmlContent);
};

ServerCalls.GetBucketListItems = function(url, params) {
	var formData = new FormData();
	var userName = params[0];	 
	var token = params[1];

	var queryUrl = BUCKET_LIST_PROCESS_GET + "?encodedUserName=" + btoa(userName) + "&encoderedSortString=" + btoa("") + "&encodedToken=" + btoa(token);
	
	var response = CallService(queryUrl, 'get');

	isNullUndefined(response); 							
	Display.LoadView(VIEW_MAIN, response);
};

ServerCalls.AddBucketListItem = function (url, params) {
	var user = SessionGetUsername(SESSION_USERNAME);
    var jsonData = JSON.stringify
	({ 
		Name: params[0],  
		DateCreated: params[1],
		BucketListItemType: params[2],
		Completed: params[3],
		Latitude: params[4],
		Longitude: params[5],  
		DatabaseId: '',
		UserName: user,
		encodedUser: btoa(user),
		encodedToken: btoa(SessionGetToken(SESSION_TOKEN))
	});			  

	response = CallService('/BucketListItem/AddBucketListItemJQuery',
						'post',
						'application/json; charset=utf-8',
						jsonData);
	if (response && response === true) {	  
		MainController.Index();		           
	} else {
		// TODO - handle error
		alert('Add failed');
	}
};
						   
ServerCalls.EditBucketListItem = function (url, params) {
	var user = SessionGetUsername(SESSION_USERNAME);
	var jsonData = JSON.stringify
		({
			Name: params[0],
			DateCreated: params[1],
			BucketListItemType: params[2],
			Completed: params[3],
			Latitude: params[4],
			Longitude: params[5],
			DatabaseId: params[6],
			UserName: params[7],
			encodedUser: btoa(user),
			encodedToken: btoa(SessionGetToken(SESSION_TOKEN))
		});

	response = CallService('/BucketListItem/EditBucketListItemJQuery',
		'post',
		'application/json; charset=utf-8',
		jsonData);
	if (response && response === true) {
		MainController.Index();
	} else {
		// TODO - handle error
		alert('Add failed');
	}
};

ServerCalls.DeleteBucketListItem = function (url, dbId) {	  
	var jsonData = JSON.stringify
		({
			DbId: dbId,
			Username: btoa(SessionGetUsername(SESSION_USERNAME)),
			Token: btoa(SessionGetToken(SESSION_TOKEN))
		});

	var goodRegistration = CallService('/BucketListItem/JQueryDeleteBucketListItem',
		'delete',
		'application/json; charset=utf-8',
		jsonData);

	if (goodRegistration === true) {
		MainController.Index();
	} else {
		alert('JQuery delete failed!');
	}	
};

ServerCalls.JQueryLogin = function(params) {	  
    var token = false;		
	var userName = params[0];	 
	var passWord = params[1];
    var base64UserName = btoa(userName);
    var base64PassWord = btoa(passWord);
   
    var jsonData = JSON.stringify
	({ 
		Username:base64UserName,
		Password:base64PassWord
	});	               

    token = CallService('/Login/JQueryLogin',
						'post',
						'application/json; charset=utf-8',
						jsonData);

	if (token && token.length > 0){			
		SessionSetToken(SESSION_TOKEN, token);
		SessionSetUsername(SESSION_USERNAME, userName);
		MainController.Index();		
	} else {				 
		alert('JQuery not logged in!');
	}					 
};

ServerCalls.JQueryRegistration = function(params) {	  						  
    var goodRegistration = false;
    var base64UserName = btoa(params[0]);  
    var base64Email = btoa(params[1]);
    var base64PassWord = btoa(params[2]);
   
    var jsonData = JSON.stringify
	({ 
		Username: base64UserName,
		Password: base64PassWord,
		Email: base64Email
	});	               

    var goodRegistration = CallService('/Registration/JQueryRegistration',
						'post',
						'application/json; charset=utf-8',
						jsonData);

	if (goodRegistration === true){
		Display.LoadView(VIEW_LOGIN);
	} else {				 
		alert('JQuery registration failed!');
	}					 
};