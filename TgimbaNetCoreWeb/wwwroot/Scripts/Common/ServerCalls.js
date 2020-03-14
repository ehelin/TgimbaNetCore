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

ServerCalls.GetJson = function (url, listDisplay) {
    try {
        return ServerCall.Get(url)
            .then(
                function (jsonResponse) {
                    var jsonParsed = JSON.parse(jsonResponse);
                    SetJson(jsonParsed, listDisplay);
                });
    }
    catch (ex) {
        return Error_Handler('ServerCalls.GetJson(3 args) - ' + view + ' - Error: ' + ex);
    }
};