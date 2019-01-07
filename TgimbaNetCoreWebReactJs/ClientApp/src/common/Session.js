var Session = {	
	SessonStorage: new Map(),

	SessionSetToken: function(key, value) {
		sessionStorage.setItem(key, value);
	},

	SessionGetToken: function(key) {
		var val = sessionStorage.getItem(key);
		return val;
	},
																	  
	SessionClearStorage: function () {
		sessionStorage.clear();
	}
}			  

module.exports.Session = Session;	   