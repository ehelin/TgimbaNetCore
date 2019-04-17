var ApplicationFlow = {}; 

ApplicationFlow.SetView = function(view) { 	
    return ApplicationFlow.SetLayout()
    .then(
        function () {
            if (LoginController.IsLoggedIn() === true) {
                MainController.Index();
            }
            else {
                return LoginController.Index();
            }
        }
    )
};

ApplicationFlow.SetLayout = function () {
    return ServerCalls.IsMobile(window.navigator.userAgent)
        .then(
            function (response) {
                isNullUndefined(response);

                if (response === true) {
                    SessionSetIsMobile(SESSION_CLIENT_IS_MOBILE, true);
                    // TODO - set mobile css
                } else {
                    SessionSetIsMobile(SESSION_CLIENT_IS_MOBILE, false);
                    // TODO - set desktop css
                }
            }
        );
};
