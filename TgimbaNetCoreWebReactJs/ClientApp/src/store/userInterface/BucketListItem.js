const ACTION_TYPE_BUCKETLISTITEM_ADD = 'Add';
const ACTION_TYPE_BUCKETLISTITEM_EDIT = 'Edit';
const ACTION_TYPE_BUCKETLISTITEM_TOGGLE = 'Toggle';
const initialState = {};

export const actionCreators = {
	addSubmit: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_BUCKETLISTITEM_ADD})
	},
	editSubmit: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_BUCKETLISTITEM_EDIT})
	},
	toggle: (completed) => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_BUCKETLISTITEM_TOGGLE, completed });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_BUCKETLISTITEM_TOGGLE) {
		return {
			...state,
			completed: action.completed
		};
	}

	if (action.type === ACTION_TYPE_BUCKETLISTITEM_ADD) {
		//alert('add reducer');
	}

	if (action.type === ACTION_TYPE_BUCKETLISTITEM_EDIT) {
		//alert('edit reducer');
	}

	return state;
};