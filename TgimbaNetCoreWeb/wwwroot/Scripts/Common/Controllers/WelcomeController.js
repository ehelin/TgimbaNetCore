var WelcomeController = Object.create(BaseController);

WelcomeController.Index = function () {
    ServerCalls.LoadWelcomePage();
}