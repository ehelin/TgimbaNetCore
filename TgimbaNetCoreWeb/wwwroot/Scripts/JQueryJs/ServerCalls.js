var ServerCalls = {};

ServerCalls.GetView = function(view, contentDiv) {
    var loadedView = null;

    loadedView = CallService(view, 'get');	
	contentDiv.html(loadedView);

	if (view === VIEW_LOGIN)  {				   
		$('#' + LOGIN_VIEW_DIV).html(JQUERY_LOGIN_TITLE);
	}	
	else if (view === VIEW_REGISTRATION) {
		$('#' + REGISTRATION_VIEW_DIV).html(JQUERY_REGISTRATION_TITLE);
	}	 
	else if (view === VIEW_MENU) {									  
		$('#' + MENU_VIEW_DIV).html(JQUERY_MENU_TITLE);	
	}
	else if (view === VIEW_MAIN) {										
		$('#' + MAIN_VIEW_DIV).html(JQUERY_MAIN_TITLE);
	}
	else {
		Error('Unknown view');
	}
};

ServerCalls.JQueryLogin = function(params) {	  
    var token = false;
    var base64UserName = btoa(params[0]);
    var base64PassWord = btoa(params[1]);
   
    var jsonData = JSON.stringify
	({ 
		Username:base64UserName,
		Password:base64PassWord
	});	               

    token = CallService('/Home/JQueryLogin',
						'post',
						'application/json; charset=utf-8',
						jsonData);

	if (token && token.length > 0){
		alert('JQuery logged in!');

		SessionSetToken(SESSION_TOKEN, token);
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

    var goodRegistration = CallService('/Home/JQueryRegistration',
						'post',
						'application/json; charset=utf-8',
						jsonData);

	if (goodRegistration === true){
		alert('JQuery registration is good!');
		Display.LoadView(VIEW_LOGIN);
	} else {				 
		alert('JQuery registration failed!');
	}					 
};