$(document).ready(function () {
    Initialize();
});

function Initialize() {		
	SessionSetToken(SESSION_CLIENT, SESSION_CLIENT_JQUERY);
	ApplicationFlow.SetView();
}