var WelcomeServerCalls = {};

WelcomeServerCalls.LoadWelcomePage = function () {
    return Display.LoadView(VIEW_WELCOME, null);
};

WelcomeServerCalls.GetSystemStatistics = function (contentDiv) {
    var url = WELCOME_GET_SYSTEM_STATISTICS;

    return ServerCall.Get(url)
			.then(
				function (response) {
				    isNullUndefined(response);
				    var systemStatistics = JSON.parse(response);
				    Display.SetSystemStatistics(systemStatistics);
				});
};