$(document).ready(function () {
    Initialize();
});

function Initialize() {		
	SessionClearStorage();
	SessionSetToken(SESSION_CLIENT, SESSION_CLIENT_JQUERY);
	ApplicationFlow.SetView();
}