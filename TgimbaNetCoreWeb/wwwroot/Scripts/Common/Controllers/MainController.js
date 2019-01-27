var MainController = Object.create(BaseController);

MainController.Add_ParameterNames = [
	"ADD_ITEM_NAME",
	"ADD_DATE_CREATED",
	"ADD_ITEM_CATEGORY",
	"ADD_COMPLETED",
	"ADD_LATITUDE",
	"ADD_LONGITUDE",
];
	 
MainController.Index = function (bucketListItems) {
	var params = [];
	
	params.push(SessionGetUsername(SESSION_USERNAME));
	params.push(SessionGetToken(SESSION_TOKEN));	  

	ServerCalls.GetBucketListItems(BUCKET_LIST_PROCESS_GET, params);
};

MainController.ShowMenu = function () {
	MenuController.Index();
};

MainController.SetAddViewDate = function () {
	var addViewDateInput = document.getElementById('USER_CONTROL_ADD_DATE_CREATED');
	var today = new Date();
	addViewDateInput.value = today.toLocaleDateString('en-US');
};

MainController.Add = function () {
	var params = BaseController.SetParameters(
		MainController.Add_ParameterNames,
		"MainController.js"
	);

	if (IsJQueryClient()) {
		alert('implement jquery add');
		// TODO - implement
	} else {
		ServerCalls.AddBucketListItem(BUCKET_LIST_PROCESS_ADD, params);
	}  
};