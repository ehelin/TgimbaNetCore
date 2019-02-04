var utilsRef = require('../common/Utilities');

const ACTION_TYPE_REGISTRATION = 'REGISTRATION';
const ACTION_TYPE_CANCEL = 'CANCEL';
const initialState = {
	username: null,
	email: null,
	password: null,
	confirmPassword: null
};

export const actionCreators = {
	register: (username, email, password, confirmPassword) => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_REGISTRATION, username, email, password, confirmPassword });
	},
	cancel: () => ({ type: ACTION_TYPE_CANCEL })
};

export const reducer = (state, action) => {
	state = state || initialState;				

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_REGISTRATION) {
		const url = host + '/Registration/Registration?'
			+ 'encodedUser=' + btoa(action.username)
			+ '&encodedPass=' + btoa(action.password)
			+ '&encodedEmail=' + btoa(action.email);

		const xhr = new XMLHttpRequest();
		xhr.open('post', url, true);
		xhr.onload = (data) => {							   
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0
				&& data.currentTarget.respose !== false
			) {									   
				window.location = host + '/login';				
			} else {
				alert('Registration failed!');
			}
		};
		xhr.send();
	}

	if (action.type === ACTION_TYPE_CANCEL) {							
		window.location = host + '/login';
	}

	return state;
};