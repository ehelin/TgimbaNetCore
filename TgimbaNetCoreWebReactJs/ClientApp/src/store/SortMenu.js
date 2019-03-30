var utilsRef = require('../common/Utilities');

const ACTION_TYPE_SET_SORT = 'SetSort';
const initialState = {};

export const actionCreators = {						   
	sort: (sort) => async (dispatch, getState) => {
		var queryString = '/main';
		if (sort && sort.length > 0) {
			queryString += '?sort=' + sort;  
		}

		dispatch({ type: ACTION_TYPE_SET_SORT, queryString });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	if (action.type === ACTION_TYPE_SET_SORT) {	  								    
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();	
		window.location = host + action.queryString;	
	}

	return state;
};