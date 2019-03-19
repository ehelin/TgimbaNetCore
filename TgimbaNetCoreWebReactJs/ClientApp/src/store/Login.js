var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_LOGIN = 'LOGIN';

const initialState = {
	username: null,
	password: null
};
							 
export const actionCreators = {						   
	login: (username, password) => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_LOGIN, username, password }); 
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_LOGIN) {	   							  
		var utils = Object.create(utilsRef.Utilities); 
		var host = utils.GetHost();
								
		const url = host + '/Login/Login?encodedUser=' + btoa(action.username)
					+ '&encodedPass=' + btoa(action.password);

		const xhr = new XMLHttpRequest();
		xhr.open('post', url, true);
		xhr.onload = (data) => {
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0)
			{									   
				var token = data.currentTarget.response; 				  
				var constants = Object.create(constantsRef.Constants); 
				var session = Object.create(sessionRef.Session); 
													  
				session.SessionSet(constants.SESSION_TOKEN, token);
				session.SessionSet(constants.SESSION_USERNAME, action.username);
				 
				window.location = host + '/main'; 		
			} else {
				alert('User is not logged in!');
			}
		};
		xhr.send();
	}	   

	return state;
};