var RegistrationController = Object.create(BaseController);

RegistrationController.ParameterNames = [
	"REGISTRATION_USERNAME",  
	"REGISTRATION_EMAIL", 
	"REGISTRATION_PASSWORD", 
	"REGISTRATION_CONFIRM_PASSWORD"
];

RegistrationController.Index = function() {
	Display.LoadView(VIEW_REGISTRATION, null);
}

RegistrationController.Cancel = function() {
	Display.LoadView(VIEW_LOGIN, null);
};

RegistrationController.Register = function() {
	var params = BaseController.SetParameters(
									RegistrationController.ParameterNames,
									"RegistrationController.js"
								);

	HtmlVanillaJsServerCalls.ProcessRegistration(REGISTRATION_PROCESS_REGISTRATION, params);
};