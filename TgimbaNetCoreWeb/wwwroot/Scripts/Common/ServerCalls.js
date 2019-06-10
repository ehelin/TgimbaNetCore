var CommonServerCalls = {};

CommonServerCalls.GetView = function (viewUrl, contentDiv, htmlContent) {
    try {
        return ServerCall.Get(viewUrl)
            .then(
            function (response) {
				Display.SetView(viewUrl, contentDiv, response, htmlContent);
            });
    }
    catch (ex) {
        return Error_Handler('CommonServerCalls.GetView(3 args) - ' + view + ' - Error: ' + ex);
    }
};
	 