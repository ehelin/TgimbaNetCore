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

	if (action.type === ACTION_TYPE_ADD) {
		alert('Add was clicked!');
	}
	else if (action.type === ACTION_TYPE_SORT) {
		alert('Sort was clicked!');
	}
	else if (action.type === ACTION_TYPE_RUN_ALGORITHM) {
		alert('Run Algorithm was clicked!');
	}
	else if (action.type === ACTION_TYPE_LOGOUT) {
		alert('Logout was clicked!');
	}
	else if (action.type === ACTION_TYPE_CANCEL) {
		alert('Cancel was clicked!');
	}   

	return state;
};