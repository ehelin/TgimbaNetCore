function LocalStorageSupported() {
    var supported = null;

    try {
        var localStorage = window[LOCAL_STORAGE];

        if (localStorage != null)
            supported = TRUE;
        else
            supported = FALSE;
    }
    catch (e) {
        supported = FALSE;
    }

    return supported;
}
function SetLocalStorageBucketList(key, value) {
    window[LOCAL_STORAGE].setItem(key, value);
}
function GetLocalStorageBucketList(key) {
    var result = window[LOCAL_STORAGE].getItem(key);

    return result;
}
function ClearLocalStorage(key) {
    window[LOCAL_STORAGE].setItem(key, null);
}