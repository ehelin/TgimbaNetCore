var sessionRef = require('../common/Session');
													 
const ACTION_TYPE_LOGOUT = 'LogOut';	

const initialState = {
	isLoggedOut: false
};
							 
export const actionCreators = {						   
	logout: () => async (dispatch, getState) => {   		
		var session = Object.create(sessionRef.Session);
		session.SessionClearStorage();	  

		dispatch({ type: ACTION_TYPE_LOGOUT });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	if (action.type === ACTION_TYPE_LOGOUT) {
		return {
			...state,
			isLoggedOut: true
		}
	}

	return state;
};