var MenuController = Object.create(BaseController);

MenuController.Index = function () {
	Display.LoadView(VIEW_MENU);
};

MenuController.AddBucketListItem = function () {
	alert('AddBucketListItem() clicked');
};

MenuController.SortBucketListItem = function () {
	alert('SortBucketListItem() clicked');
};

MenuController.RunAlgorithm = function () {
	alert('RunAlgorithm() clicked');
};

MenuController.LogOut = function () {
	alert('LogOut() clicked');	   
	SessionClearStorage();	 
	ApplicationFlow.SetView();
};

MenuController.Cancel = function () {
	alert('Cancel() clicked');
};
