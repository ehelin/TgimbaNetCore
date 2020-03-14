var ServerCalls = {};

ServerCalls.GetView = function (viewUrl, contentDiv, htmlContent) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
				Display.SetView(viewUrl, contentDiv, response, htmlContent);
            });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetView(3 args) - ' + view + ' - Error: ' + ex);
    }
};
	 
ServerCalls.GetAjaxView = function (viewUrl, contentDiv, htmlContent) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
                Display.SetAjaxView(viewUrl, contentDiv, response, htmlContent);
            });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetView(3 args) - ' + view + ' - Error: ' + ex);
    }
};

ServerCalls.GetJson = function (url) {
    try {
        return ServerCall.Get(url)
            .then(
                function (json) {
                    var test = 1;
                    SetJson(json);
                    //Display.SetView(viewUrl, contentDiv, response, htmlContent);
                });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetView(3 args) - ' + view + ' - Error: ' + ex);
    }
};