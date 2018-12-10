const ACTION_TYPE_MAIN = 'MAIN';
const initialState = {};

export const actionCreators = {
	main: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_MAIN });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type == ACTION_TYPE_MAIN) {
		// Load main panel contents here
	}

	return state;
};