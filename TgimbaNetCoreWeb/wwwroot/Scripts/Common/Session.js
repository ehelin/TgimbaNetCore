//token -------------------------------------------------------
function SessionSetToken(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetToken(key) {			  
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetUsername(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetUsername(key) {			  
    var val = sessionStorage.getItem(key);
    return val;
}
													 
//misc --------------------------------------------------------
function SessionClearStorage() {
	var sessionClient = SessionGetToken(SESSION_CLIENT);

	sessionStorage.clear();

	//preserve client type once set
	sessionStorage.setItem(SESSION_CLIENT, sessionClient);
	
}