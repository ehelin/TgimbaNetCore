function GetListItemById() {
    var listItem = null;
    var id = GetLocalStorageCurrentItemId();
    var list = GetLocalStorageList();

    list = list.split(";");

    for (var i = 0; i < list.length; i++) {
        var curListItem = list[i].split(",");
        var curListItemId = curListItem[0];

        if (curListItemId == id) {
            listItem = curListItem;
            SetLocalStorageCurrentItemId(parseInt(curListItemId) + 1);
            break;
        }
    }

    return listItem;
}

function IsListEditable() {
    var curDynamicListName = $("#listOptionsHtml").val();
    var curDynamicLists = GetLocalDynamicStorageLists();

    if (curDynamicLists.indexOf(curDynamicListName) != -1) {
        var list = GetLocalStorageLists();

        if (list.indexOf(curDynamicListName) > 0) {
            list = list.replace(curDynamicListName + ',', '');
            list = list.replace(curDynamicListName, '');

            SetLocalStorageLists(list);

            Load();

            return;
        }
    }

    if (curDynamicLists == null || curDynamicLists == 'null') {
        Alert(LISTNAME_IS_NOT_USER_LIST);
        return;
    }

    var curDynamicListsArr = curDynamicLists.split(":");
    var newDynamicList = '';
    var targetList = null;

    for (var i = 0; i < curDynamicListsArr.length; i++) {
        var curList = curDynamicListsArr[i];

        if (curList.indexOf(curDynamicListName) < 0) {
            newDynamicList = newDynamicList + curList;
        }
    }

    SetLocalDynamicStorageLists(newDynamicList);

    ResetPage();
    ClearAlert();
}

function IsUserListSelected() {
    var curDynamicListName = $("#listOptionsHtml").val();
    var curDynamicLists = GetLocalDynamicStorageLists();
    var list = GetLocalStorageLists();

    if (curDynamicLists.indexOf(curDynamicListName) != -1)
        return true;
    else
        return false;
}

function DeleteListItem() {
    var curDynamicListName = $("#listOptionsHtml").val();
    var curDynamicLists = GetLocalDynamicStorageLists();

    if (curDynamicLists.indexOf(curDynamicListName) != -1) {
        var list = GetLocalStorageLists();

        if (list.indexOf(curDynamicListName) > 0) {
            list = list.replace(curDynamicListName + ',', '');
            list = list.replace(curDynamicListName, '');

            SetLocalStorageLists(list);

            //remove from dynamic storage list as well
            var newDynamicLists = '';
            var curDynamicListsArr = curDynamicLists.split(":");

            for (var i = 0; i < curDynamicListsArr.length; i++) {
                var curList = curDynamicListsArr[i];

                if (curList == null || curList == '')
                    break;

                var pos = curList.indexOf("]");
                var curListName = '';
                if (pos < 1)
                    curListName = curList;
                else
                    curListName = curList.substring(0, pos);

                if (curListName != curDynamicListName)
                    newDynamicLists = newDynamicLists + curList + COLON;
            }

            SetLocalDynamicStorageLists(newDynamicLists);

            Load();

            return;
        }
    }

    if (curDynamicLists == null || curDynamicLists == 'null') {
        Alert(LISTNAME_IS_NOT_USER_LIST);
        return;
    }

    var curDynamicListsArr = curDynamicLists.split(":");
    var newDynamicList = '';
    var targetList = null;

    for (var i = 0; i < curDynamicListsArr.length; i++) {
        var curList = curDynamicListsArr[i];

        if (curList.indexOf(curDynamicListName) < 0) {
            newDynamicList = newDynamicList + curList;
        }
    }

    SetLocalDynamicStorageLists(newDynamicList);

    ResetPage();
    ClearAlert();
}

function AddListItem() {
    var newListItemEnglish = $("#listItemEnglish").val();
    var newListItemSpanish = $("#listItemSpanish").val();
    var curDynamicListName = $("#listOptionsHtml").val();
    var targetList = GetTargetList(curDynamicListName);

    if (targetList == null || targetList == "null")
        throw new Exception("target List is null");

    var targetListItemIndex = GetTargetListIndex(targetList);

    var posLastColon = targetList.indexOf(COLON);
    if (posLastColon > 1)
        targetList = targetList.substring(0, posLastColon);

    var posLastRightBracket = targetList.indexOf(RIGHT_BRACKET);
    if (posLastRightBracket < 0)
        targetList = targetList + RIGHT_BRACKET;

    targetList = targetList + targetListItemIndex + ',' + newListItemEnglish + ',' + newListItemSpanish + SEMI_COLON + COLON;

    //put target list back into master list
    var newDynamicLists = '';
    var curDynamicLists = GetLocalDynamicStorageLists();
    var curDynamicListsArr = curDynamicLists.split(":");

    for (var i = 0; i < curDynamicListsArr.length; i++) {
        var curList = curDynamicListsArr[i];

        if (curList == null || curList == '')
            break;

        var pos = curList.indexOf("]");
        var curListName = '';
        if (pos < 1)
            curListName = curList;
        else
            curListName = curList.substring(0, pos);

        if (curListName == curDynamicListName)
            newDynamicLists = newDynamicLists + targetList;
        else
            newDynamicLists = newDynamicLists + curList + COLON;
    }

    SetLocalDynamicStorageLists(newDynamicLists);
}

function GetTargetListIndex(targetList) {
    var targetIndex = "";
    var targetIndexNum = 0;
    var posLastComma = targetList.lastIndexOf(",");

    //new list
    if (posLastComma == -1)
        return ONE;

    targetList = targetList.substring(0, posLastComma);
    posLastComma = targetList.lastIndexOf(",");
    targetList = targetList.substring(0, posLastComma);

    var posLastSemiColon = targetList.lastIndexOf(SEMI_COLON);
    if (posLastSemiColon == -1)
        posLastSemiColon = targetList.lastIndexOf(RIGHT_BRACKET)

    targetIndex = targetList.substring(posLastSemiColon + 1);

    targetIndexNum = parseInt(targetIndex);
    targetIndexNum = targetIndexNum + 1;

    return targetIndexNum;
}

function GetTargetList(curDynamicListName) {
    var curDynamicLists = GetLocalDynamicStorageLists();
    var curDynamicListsArr = curDynamicLists.split(":");
    var targetList = null;

    for (var i = 0; i < curDynamicListsArr.length; i++) {
        var curList = curDynamicListsArr[i];

        if (curList.indexOf(curDynamicListName) >= 0) {
            targetList = curList;
            break;
        }
    }

    return targetList;
}

function AddListName() {
    var newListName = $("#listName").val();
    var list = GetLocalStorageLists();

    if (list.indexOf(newListName) > 0) {
        Alert(LISTNAME_ALREADY_EXISTS);
        return;
    }

    //set list name with global list
    list = list + ',' + newListName;
    SetLocalStorageLists(list);

    //add list so it can be used
    var curDynamicLists = GetLocalDynamicStorageLists();

    if (curDynamicLists == null || curDynamicLists == "null")
        curDynamicLists = '';

    var newList = newListName + ':';
    curDynamicLists = curDynamicLists + newList;

    SetLocalDynamicStorageLists(curDynamicLists);
}
