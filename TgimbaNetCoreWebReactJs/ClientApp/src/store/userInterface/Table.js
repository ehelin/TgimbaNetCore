const ACTION_TYPE_TABLE = 'TABLE';			
const initialState = {};
							 
export const actionCreators = {						   
	handleClick: () => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_TABLE }); 
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_TABLE) {	
		alert('table reducer click');
	}	   

	return state;
};