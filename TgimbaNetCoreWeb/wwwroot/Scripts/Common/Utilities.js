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

function SetElementValue(ctrlName, value) {
	ctrlObj = document.getElementById(ctrlName);

	if (ctrlObj.type === 'checkbox') {
		if (value === 'true' || value === true) {
			ctrlObj.checked = true;
		} else {
			ctrlObj.checked = false;
		}
	} else if (ctrlObj.type === 'select-one') {
		ctrlObj.selectedIndex = value-1;
	} else {
		ctrlObj.value = value;
	}

	return value;
}

function GetElementValue(ctrlName) {
	var ctrlObj = GetElement(ctrlName);

	if (ctrlObj.type === 'checkbox') {
		value = ctrlObj.checked;
	} else if (ctrlObj.type === 'select-one') {
		value = ctrlObj.options[ctrlObj.selectedIndex].value;
	} else {
		value = ctrlObj.value;
	}

	return value;  
}

function GetElement(ctrlName) {
	var ctrlObj = document.getElementById(ctrlName);

	isNullUndefined(ctrlObj, 'Utilities.js', 'ctrl exists');

	return ctrlObj
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