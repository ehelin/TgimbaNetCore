var utilsRef = require('../common/Utilities');
var sessionRef = require('../common/Session');
													 
const ACTION_TYPE_LOGOUT = 'LogOut';	

const initialState = {};
							 
export const actionCreators = {						   
	logout: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_LOGOUT });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_LOGOUT) {
		var session = Object.create(sessionRef.Session);
		session.SessionClearStorage();	  
												 
		window.location = host + '/login';		
	}

	return state;
};