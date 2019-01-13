$(document).ready(function () {
    //start test code -------------
    ClearLocalStorage();
    //end test code ---------------

    Load();
});

//$(document).ready(function () {
//    Initialize();
//});

function Load() {
    ResetPage();
    BuildMnuButton();
    //BuildMnuButtons();
    BuildListDisplay(GetAvailableList());
}

//Constants
var SPANISH_MOBILE_LOCAL_STORAGE_clsCurrentItemId = "SpanishFlashCards_0001_Mobile_clsCurrentItemId";
var SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishList = "SpanishFlashCards_0001_Mobile_clsSpanishList";
var SPANISH_MOBILE_LOCAL_STORAGE_clsSpanishLists = "SpanishFlashCards_0001_Mobile_clsSpanishLists";
var SPANISH_MOBILE_LOCAL_STORAGE_clsDynamicSpanishLists = "SpanishFlashCards_0001_Mobile_clsDynamicSpanishLists";
var LOCAL_STORAGE = "localStorage";

var TOTAL_SPANISH_CONJUNCATIONS = 4;

var LANGUAGE_ENGLISH = "English";
var LANGUAGE_SPANISH = "Spanish";

var JQUERY_CTL_CONJUNCTION = "#Conjuncation";
var JQUERY_CTL_ANSWER_DIV = "#answerDiv";
var JQUERY_CTL_SPANISH_CONJUNCATION_MASTER = "#SpanishContentsMaster";

var CSS_CONJUNCTION_HIDE = "conjuncationHide";
var CSS_CONJUNCTION_SHOW = "conjuncationShow";
var CSS_ANSWER_HIDE = "answerHide";
var CSS_ANSWER_SHOW = "answerShow";
var CSS_MASTER_CONJUNCTION_HIDE = "masterConjuncationHide";
var CSS_MASTER_CONJUNCTION_SHOW = "masterConjuncationShow";

var TRUE = 'true';
var FALSE = 'false';

var RIGHT_BRACKET = "]";
var COLON = ":";
var SEMI_COLON = ";";

var ONE = 1;

//window.external.notify("Hello " + name);
//alerts
var LISTNAME_ALREADY_EXISTS = "This list name already exists";
var LISTNAME_IS_NOT_USER_LIST = "This list is not user created and cannot be modified";
var NO_MORE_ITEMS = "This list has no more items";