var WelcomeController = Object.create(BaseController);

WelcomeController.Index = function () {
    WelcomeServerCalls.LoadWelcomePage();
};

WelcomeController.VanillaJSLogin = function () {
    var base_url = GetHost();
    var url = base_url + VANILLA_JS_LOGIN;
    window.location = url;
};

WelcomeController.AngularTypeScript = function () {
    alert('angular typescript login');
};

WelcomeController.ReactReduxJSLogin = function () {
    alert('react js login');
}

