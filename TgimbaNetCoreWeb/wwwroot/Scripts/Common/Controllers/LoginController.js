var LoginController = Object.create(BaseController);

LoginController.ParameterNames = [
	"LOGIN_USERNAME", 
	"LOGIN_PASSWORD"
];

LoginController.Index = function () {
	Display.LoadView(VIEW_LOGIN);
};
						   
LoginController.Login = function() {
  	var params = BaseController.SetParameters(
									LoginController.ParameterNames,
									"LoginController.js"
								);
	
	if (IsJQueryClient()) {
		ServerCalls.JQueryLogin(params);
	} else {
		ServerCalls.ProcessLogin(LOGIN_PROCESS_USER, params);
	}   
};

LoginController.IsLoggedIn = function() {	
    var token = SessionGetToken(SESSION_TOKEN);
   
    if (token !== undefined && token !== null && token.length > 0)
    {													  
        return true;
    }
    else
    {					   
        return false;
    }
};
