function submitListButtonClick() {
    ClearAlert();
    SetupDisplayList();
    BuildTermDisplay();
}

function createListButtonClick() {
    ClearAlert()
    BuildCreateEditListDisplay(TRUE);
}

function mnuButtonClick() {
    ClearAlert();
    BuildMnuButtons();
}

function createListButtonCancelClick() {
    Load();
    ClearAlert();
}

function listSelectIndexChange() {
    ClearAlert();
    BuildMnuButton();
    ClearTermDisplay();

    var selectedList = GetSelectedList();

    if (selectedList == 'VerbsAR'
        || selectedList == 'VerbsER'
        || selectedList == 'VerbsIR'
            || selectedList == 'Verbs2')
        LanguageChange(true);
    else
        LanguageChange(false);
}

function cancelListItemButtonClick() {
    Load();
    ClearAlert();
}

function deleteListItemButtonClick() {
    if (IsUserListSelected() == true) {
        DeleteListItem();
        Load();
        ClearAlert();
    }
    else
        Alert(LISTNAME_IS_NOT_USER_LIST);
}

function submitNewListItemButtonClick() {
    AddListItem();
    ResetPage();
    ClearAlert();
}

function submitNewListButtonClick() {
    AddListName();
    Load();
    ClearAlert();
}

function addListItemButtonClick() {
    if (IsUserListSelected() == true) {
        ClearAlert();
        BuildCreateEditListDisplay(FALSE);
        //Load();
    }
    else
        Alert(LISTNAME_IS_NOT_USER_LIST);
}

function nextTargetClick() {
    BuildTermDisplay();
}

function showConjuncationButton(clickedConjuncation) {
    showSelectedConjuncation(clickedConjuncation);
}

function showAnswerClick() {
    var answer = $(JQUERY_CTL_ANSWER_DIV);
    var masterSpanish = $(JQUERY_CTL_SPANISH_CONJUNCATION_MASTER);

    answer.removeClass(CSS_ANSWER_HIDE);
    answer.addClass(CSS_ANSWER_SHOW);
    masterSpanish.removeClass(CSS_MASTER_CONJUNCTION_HIDE);
    masterSpanish.addClass(CSS_MASTER_CONJUNCTION_SHOW);
}