//token ------------------------------------------------------------------
function SessionSetToken(clsSortDescKey, value) {	
    sessionStorage.setItem(key, value);
}
function SessionGetToken(clsSortDescKey) {
    var val = sessionStorage.getItem(clsSortDescKey);
    return val;
}

//misc --------------------------------------------------------
function SessionClearStorage() {
    sessionStorage.clear();
}