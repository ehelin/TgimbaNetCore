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
    sessionStorage.clear();
}