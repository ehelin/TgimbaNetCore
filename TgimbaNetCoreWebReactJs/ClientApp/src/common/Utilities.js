var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

var Utilities = {
	GetHost: function () {
		var host = window.location.protocol + "//"
			+ window.location.hostname + ':' + window.location.port;

		return host;	
	},

	IsLoggedIn: function () {		 		
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);

		var token = session.SessionGetToken(constants.SESSION_TOKEN);					  

		if (token !== undefined && token !== null && token.length > 0) {
			return true;
		}
		else {
			return false;
		}
	},

	GetDefaultTableStyle: function () {
		return {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};
	}
};

module.exports.Utilities = Utilities;