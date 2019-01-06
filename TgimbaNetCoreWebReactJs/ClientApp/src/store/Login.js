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
		// TODO - move to utility function
		var host = window.location.protocol + "//"
			+ window.location.hostname + ':' + window.location.port;
								
		const url = host + '/Home/Login?encodedUser=' + btoa(action.username)
					+ '&encodedPass=' + btoa(action.password);
		const xhr = new XMLHttpRequest();
		xhr.open('post', url, true);
		xhr.onload = (data) => {
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0)
			{
				alert('User is logged in!');
				// TODO - move to utility function
				var host = window.location.protocol + "//"
					+ window.location.hostname + ':' + window.location.port;
				window.location = host + '/main';
			} else {
				alert('User is not logged in!');
			}
		};
		xhr.send();
	}	   

	return state;
};