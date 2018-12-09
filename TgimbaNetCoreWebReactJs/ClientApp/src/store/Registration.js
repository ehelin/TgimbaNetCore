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

	// TODO - move to utility function
	var host = window.location.protocol + "//"
		+ window.location.hostname + ':' + window.location.port;

	if (action.type === ACTION_TYPE_REGISTRATION) {
		const url = host + '/Home/Registration?'
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
				alert('Registration succeeded!');
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