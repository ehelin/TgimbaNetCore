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
    return HtmlVanillaJsServerCalls.IsMobile(window.navigator.userAgent)
        .then(
            function (response) {
                var cssFileName = null;
                isNullUndefined(response);

                if (response === true || response === "true") {
                    SessionSetIsMobile(SESSION_CLIENT_IS_MOBILE, true);
                    cssFileName = CSS_FILE_MOBILE;
                } else {
                    SessionSetIsMobile(SESSION_CLIENT_IS_MOBILE, false);
                    cssFileName = CSS_FILE_DESKTOP;
                }

                var fileref = document.createElement("link");
                fileref.rel = "stylesheet";
                fileref.type = "text/css";
                fileref.href = cssFileName;
                document.getElementsByTagName("head")[0].appendChild(fileref)
            }
        );
};
