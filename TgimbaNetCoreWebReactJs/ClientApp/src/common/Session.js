var Session = {	
	SessonStorage: new Map(),

	SessionSet: function(key, value) {
		sessionStorage.setItem(key, value);
	},

	SessionGet: function(key) {
		var val = sessionStorage.getItem(key);
		return val;
	},
																	  
	SessionClearStorage: function () {
		sessionStorage.clear();
	}
}			  

module.exports.Session = Session;	   