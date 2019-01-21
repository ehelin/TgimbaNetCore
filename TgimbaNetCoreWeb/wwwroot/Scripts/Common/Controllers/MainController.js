var MainController = Object.create(BaseController);

MainController.Index = function (bucketListItems) {
	var params = [];
	
	params.push(SessionGetUsername(SESSION_USERNAME));
	params.push(SessionGetToken(SESSION_TOKEN));	  

	ServerCalls.GetBucketListItems(BUCKET_LIST_PROCESS_GET, params);
};

MainController.ShowMenu = function () {
	MenuController.Index();
};