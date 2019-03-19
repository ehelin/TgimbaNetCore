var utilsRef = require('../common/Utilities');
var sessionRef = require('../common/Session');

const ACTION_TYPE_SET_SORT = 'SetSort';

const initialState = {};
							 
export const actionCreators = {						   
	sort: (sort) => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_SET_SORT, sort });
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

	return state;
};