function GetHost() { 
	var host = window.location.protocol + "//"
		+ window.location.hostname + ':' + window.location.port;

	return host;		   
};