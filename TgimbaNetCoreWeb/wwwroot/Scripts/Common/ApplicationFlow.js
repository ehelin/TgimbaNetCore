// TODO if view is set, just pass on (i.e. LoadView(view))?
var ApplicationFlow = {}; 

ApplicationFlow.SetView = function(view) { 	   	   	   						
    if (LoginController.IsLoggedIn() === true) {   
        Display.LoadView(VIEW_MAIN);
    }	   
    else {          
        return LoginController.Index();
    }
};
