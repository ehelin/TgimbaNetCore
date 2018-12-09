function CallService(subUrl, type, contentType, data) {
    var resultVal = null;			   
	var baseUrl = GetHost();
	var url = baseUrl + subUrl;

    $.ajax({
        url: url,
        type: type,
        contentType: contentType,
        data: data,
        async: false,
        success: function (result) {
            resultVal = result;
        },
        error: function (error) {
            alert("Error: " + error);
        }
    });

    return resultVal;
}