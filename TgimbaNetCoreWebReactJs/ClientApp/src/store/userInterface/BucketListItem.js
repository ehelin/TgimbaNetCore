const ACTION_TYPE_BUCKETLISTITEM_ADD = 'Add';
const ACTION_TYPE_BUCKETLISTITEM_EDIT = 'Edit';
const initialState = {};

export const actionCreators = {
	addSubmit: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_BUCKETLISTITEM_ADD})
	},
	editSubmit: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_BUCKETLISTITEM_EDIT})
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === ACTION_TYPE_BUCKETLISTITEM_ADD) {
		//alert('add reducer');
	}

	if (action.type === ACTION_TYPE_BUCKETLISTITEM_EDIT) {
		//alert('edit reducer');
	}

	return state;
};