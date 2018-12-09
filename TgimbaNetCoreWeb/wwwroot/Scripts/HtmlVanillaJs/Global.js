function Init() {
	SessionClearStorage();	  
	SessionSetToken(SESSION_CLIENT, SESSION_CLIENT_VANILLA_JS);
    
	ApplicationFlow.SetView();
}

//function Initialize() {		
//	SessionClearStorage();
//	SetView();
//}