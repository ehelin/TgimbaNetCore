// TODO = condense sets/gets to one generic
function SessionSetToken(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetToken(key) {			  
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetIsMobile(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetIsMobile(key) {
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetSystemWebSiteAzureFunctionIsUp(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetSystemWebSiteAzureFunctionIsUp(key) {
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetSystemDbAzureFunctionIsUp(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetSystemDbAzureFunctionIsUp(key) {
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetSystemDbWebsiteIsUp(key, value) {
    sessionStorage.setItem(key, value);
}
function SessionGetSystemDbWebsiteIsUp(key) {
    var val = sessionStorage.getItem(key);
    return val;
}

function SessionSetIsSearch(key, value) {
	sessionStorage.setItem(key, value);
}
function SessionGetIsSearch(key) {
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

function SessionSet(key, value) {
    sessionStorage.setItem(key, value);
}

function SessionGet(key) {			  
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