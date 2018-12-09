var ServerCalls = {};

ServerCalls.GetView = function(viewUrl, contentDiv) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
				Display.SetView(viewUrl, contentDiv, response);
            });
    }
    catch (ex) {
        return Error_Handler('LoadView(view) - ' + view + ' - Error: ' + ex);
    }
};

ServerCalls.ProcessRegistration = function(view, params) {
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
				Display.LoadView(VIEW_LOGIN);
            } else {
                alert('User is not registered');                
            }

			// TODO - figure out set view for multiple views
            //SetView();
        });
};

ServerCalls.ProcessLogin = function(view, params) {
	var formData = new FormData();

	formData.append("user", btoa(params[0]));
	formData.append("pass", btoa(params[1]));

    return ServerCall.Post(view, formData)
        .then(
        function (token) {
            if (token !== null && token !== undefined && token.length > 0) {
                //SessionSetToken(SESSION_TOKEN, token);	   
                alert('Username is logged in');     
            } else {
                // TODO - reset user and pass text boxes to empty
                alert('Username and/or password is incorrect');                
            }
									 
			// TODO - figure out set view for multiple views
            //SetView();
        });
};

