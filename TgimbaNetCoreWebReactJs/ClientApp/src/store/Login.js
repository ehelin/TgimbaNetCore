var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_LOGIN = 'LOGIN';

const initialState = {
	username: null,
	password: null,
	loggedIn: false
};
							 
export const actionCreators = {						   
	login: (username, password, history) => async (dispatch, getState) => {  
		var utils = Object.create(utilsRef.Utilities); 
		var host = utils.GetHost();
								
		const url = host + '/Login/Login?encodedUser=' + btoa(username)
					+ '&encodedPass=' + btoa(password);

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
				session.SessionSet(constants.SESSION_USERNAME, username);
															
				dispatch({ type: ACTION_TYPE_LOGIN }); 	
			} else {
				alert('User is not logged in!');
			}
		};
		xhr.send();
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_LOGIN) {	
		return {
            ...state,
			loggedIn: true
		};   							  

	}	   

	return state;
};