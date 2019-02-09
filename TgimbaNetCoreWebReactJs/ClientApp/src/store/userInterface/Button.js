const ACTION_TYPE_BUTTON = 'BUTTON';			
const initialState = {};
							 
export const actionCreators = {						   
	handleClick: () => async (dispatch, getState) => {  
		dispatch({ type: ACTION_TYPE_BUTTON }); 
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_BUTTON) {	
		alert('button reducer click');
	}	   

	return state;
};