//------------------------------------------------------
function SetLocalStorageCurrentItemId(value) {
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsCurrentItemId, value);
}
function GetLocalStorageCurrentItemId() {
    var val = window[LOCAL_STORAGE].getItem(SPANISH_MOBILE_LOCAL_STORAGE_clsCurrentItemId);
    return val;
}

//------------------------------------------------------
function SetLocalStorageLists(value) {
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishLists, value);
}
function GetLocalStorageLists() {
    var val = window[LOCAL_STORAGE].getItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishLists);
    return val;
}

//------------------------------------------------------
function SetLocalStorageList(value) {
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishList, value);
}
function GetLocalStorageList() {
    var val = window[LOCAL_STORAGE].getItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishList);
    return val;
}

//------------------------------------------------------
function SetLocalDynamicStorageLists(value) {
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsDynamicSpanishLists, value);
}
function GetLocalDynamicStorageLists() {
    var val = window[LOCAL_STORAGE].getItem(SPANISH_MOBILE_LOCAL_STORAGE_clsDynamicSpanishLists);
    return val;
}

//-------------------------------------------------------
function ClearLocalStorage() {
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishList, null);
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishLists, null);
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsCurrentItemId, null);
    window[LOCAL_STORAGE].setItem(SPANISH_MOBILE_LOCAL_STORAGE_clsDynamicSpanishLists, null);
}