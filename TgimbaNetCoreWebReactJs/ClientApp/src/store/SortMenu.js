var utilsRef = require('../common/Utilities');
var sessionRef = require('../common/Session');

const ACTION_TYPE_SET_SORT = 'SetSort';
const ACTION_TYPE_CANCEL = 'Cancel';	

const initialState = {};
							 
export const actionCreators = {						   
	sort: (sort) => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_SET_SORT, sort });
	},
	cancel: () => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_CANCEL }); 
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_SET_SORT) {	
		var queryString = '?sort=' + action.sort;  					   
		window.location = host + '/main' + queryString;
	}
	else if (action.type === ACTION_TYPE_CANCEL) { 
		window.location = host + '/login';
	}   

	return state;
};