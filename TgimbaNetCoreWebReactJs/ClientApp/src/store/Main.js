const ACTION_TYPE_MAIN_MENU = 'MainMenu';
const initialState = {};

export const actionCreators = {
	main: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_MAIN_MENU });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	// TODO - move to utility function
	var host = window.location.protocol + "//"
		+ window.location.hostname + ':' + window.location.port;

	if (action.type == ACTION_TYPE_MAIN_MENU) {
		alert('main menu reducer');
		window.location = host + '/mainmenu';
	}

	return state;
};