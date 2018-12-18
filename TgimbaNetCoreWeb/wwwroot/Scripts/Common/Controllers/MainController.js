var MainController = Object.create(BaseController);

MainController.Index = function () {
	Display.LoadView(VIEW_MAIN);
};

MainController.ShowMenu = function () {
	MenuController.Index();
};