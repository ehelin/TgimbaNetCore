var MenuController = Object.create(BaseController);

MenuController.Index = function () {
	Display.LoadView(VIEW_MENU, null);
};

MenuController.AddBucketListItem = function () {
	Display.LoadView(VIEW_MAIN_ADD, null);
};

MenuController.SortBucketListItem = function () {
	alert('SortBucketListItem() clicked');
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
