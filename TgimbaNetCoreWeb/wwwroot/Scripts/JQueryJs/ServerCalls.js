function GetView(view, contentDiv) {
    var loadedView = null;

    loadedView = CallService(view, 'get');	
	contentDiv.html(loadedView);

	// TODO - handle specific titles
	if (view === VIEW_LOGIN)  {				   
		$('#' + LOGIN_VIEW_DIV).html(JQUERY_LOGIN_TITLE);
	} else {						
		$('#' + REGISTRATION_VIEW_DIV).html(JQUERY_REGISTRATION_TITLE);
	}
}

function JQueryLogin(params) {	  
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
		Display.LoadView(VIEW_MAIN);  
	} else {				 
		alert('JQuery not logged in!');
	}					 
}

function JQueryRegistration(params) {	  						  
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
}