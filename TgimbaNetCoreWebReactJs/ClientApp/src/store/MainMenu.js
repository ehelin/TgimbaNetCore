var utilsRef = require('../common/Utilities');
var sessionRef = require('../common/Session');

const ACTION_TYPE_ADD = 'Add';
const ACTION_TYPE_SORT = 'Sort';
const ACTION_TYPE_RUN_ALGORITHM = 'RunAlgorithm';
const ACTION_TYPE_LOGOUT = 'LogOut';
const ACTION_TYPE_CANCEL = 'Cancel';	

const initialState = {};
							 
export const actionCreators = {						   
	add: () => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_ADD }); 
	},
	sort: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_SORT });
	},
	runAlgorithm: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_RUN_ALGORITHM });
	},
	logout: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_LOGOUT });
	},
	cancel: () => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_CANCEL }); 
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_ADD) {
		window.location = host + '/add';
	}
	else if (action.type === ACTION_TYPE_SORT) {
		//alert('Sort was clicked!');
	}
	else if (action.type === ACTION_TYPE_RUN_ALGORITHM) {
		//alert('Run Algorithm was clicked!');
	}
	else if (action.type === ACTION_TYPE_LOGOUT) {
		//alert('Logout was clicked!');
		var session = Object.create(sessionRef.Session);
		session.SessionClearStorage();	  
												 
		window.location = host + '/login';
	}
	else if (action.type === ACTION_TYPE_CANCEL) { 
		window.location = host + '/login';
	}   

	return state;
};