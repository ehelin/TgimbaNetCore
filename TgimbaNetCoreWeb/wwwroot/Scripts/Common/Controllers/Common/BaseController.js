var BaseController = {};

BaseController.Token = 'notSet';

BaseController.SetParameters = function(parameterNames, file) {
    var paramValues = [];

	for(var i=0; i<parameterNames.length; i++) {
		var value = BaseController.GetParameter("USER_CONTROL_" + parameterNames[i], 
												"VALUE_TYPE_" + parameterNames[i], 
												file);	
		paramValues.push(value);		
	}

	return paramValues;
}

BaseController.GetParameter = function(ctrl, type, file) {
	if (!HasValue(ctrl, type, file))
    {
        return;
    }       

    var value = document.getElementById(ctrl).value;

	return value;
}