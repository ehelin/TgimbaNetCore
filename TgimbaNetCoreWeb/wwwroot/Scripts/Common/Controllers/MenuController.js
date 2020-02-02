var MenuController = Object.create(BaseController);

MenuController.Index = function () {
	Display.LoadView(VIEW_MENU, null);			
};

MenuController.AddBucketListItem = function () {
	Display.LoadView(VIEW_MAIN_ADD, null);
};

MenuController.RunAlgorithm = function () {
	alert('RunAlgorithm() clicked');
};

MenuController.LogOut = function () {
	SessionClearStorage();	 
	ApplicationFlow.SetView();
};

MenuController.Cancel = function () {
	ApplicationFlow.SetView();
};

MenuController.SortBucketListItem = function () {
	Display.LoadView(VIEW_SORT, null);
};

MenuController.Sort = function (sortColumnParam) {
	// TODO - consolidate this code? it exists in maincontroller.index
	var params = [];
	var sortColumn = 'order by ' + sortColumnParam;

    var sortingAlgorithmsCtrl = document.getElementById('hvJsSortAvailableSortAlgorithmsSelect');
    var sortAlgorithm = sortingAlgorithmsCtrl.options[sortingAlgorithmsCtrl.selectedIndex].value;

	params.push(SessionGetUsername(SESSION_USERNAME));
	params.push(SessionGetToken(SESSION_TOKEN));

	var descCb = document.getElementById('hvJsDescCheckbox');
	if (descCb && descCb.checked) {
		sortColumn = sortColumn + ' DESC';
	}

	HtmlVanillaJsServerCalls.GetBucketListItems(BUCKET_LIST_PROCESS_GET, params, sortColumn, sortAlgorithm);
};
