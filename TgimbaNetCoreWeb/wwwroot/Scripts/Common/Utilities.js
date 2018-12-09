function isNullUndefined(object, location, expectedObj) {   
    if (object === undefined) {   
        Error(expectedObj + ' is undefined at ' + location);
    }

    if (object === null) {           
        Error(expectedObj + ' is null  at ' + location);
    }                     
}
          
function HasValue(ctrlId, type, file) {
    var ctrl = document.getElementById(ctrlId);
   
    isNullUndefined(ctrl, file, 'ctrl-HasValue');
    
    var value = ctrl.value;

    if (value === null || value === undefined || value.length < 1) {
        return alert('Please enter a value for ' + type);
    }

    return true;
}

function GetHost() {
    var host = window.location.origin;

    return host;
}

// TODO - add unit test for this method
function IsJQueryClient() {
	var sessionClient = SessionGetToken(SESSION_CLIENT);

	if (sessionClient && sessionClient === SESSION_CLIENT_JQUERY) {
		return true;
	}
	
	return false;
}