var utilsRef = require('../common/Utilities');

const ACTION_TYPE_REGISTRATION = 'REGISTRATION';

const initialState = {
	username: null,
	email: null,
	password: null,
	confirmPassword: null,
	isRegistered: false
};

export const actionCreators = {
	register: (username, email, password, confirmPassword, history) => async (dispatch, getState) => {			
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();

		const url = host + '/Registration/Registration?'
			+ 'encodedUser=' + btoa(username)
			+ '&encodedPass=' + btoa(password)
			+ '&encodedEmail=' + btoa(email);

		const xhr = new XMLHttpRequest();
		xhr.open('post', url, true);
		xhr.onload = (data) => {							   
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0
				&& data.currentTarget.response !== false
			) {	
				dispatch({ type: ACTION_TYPE_REGISTRATION });		
			} else {
				alert('Registration failed!');
			}
		};
		xhr.send();
	}
};

export const reducer = (state, action) => {
	state = state || initialState;		

	if (action.type === ACTION_TYPE_REGISTRATION) {
		return {
			...state,
			isRegistered: true
		}
	}

	return state;
};