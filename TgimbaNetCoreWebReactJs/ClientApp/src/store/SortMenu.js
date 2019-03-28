const ACTION_TYPE_SET_SORT = 'SetSort';

const initialState = {
	sortNavigation: false,
	sortRoute: null
};
							 
export const actionCreators = {						   
	sort: (sort) => async (dispatch, getState) => {
		var queryString = '/main?sort=' + sort;  

		dispatch({ type: ACTION_TYPE_SET_SORT, queryString });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;	

	if (action.type === ACTION_TYPE_SET_SORT) {	
		return {
			...state,
			sortNavigation: true,
			sortRoute: action.queryString
		}
	}

	return state;
};