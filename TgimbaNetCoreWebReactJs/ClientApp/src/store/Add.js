var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_ADD = 'Add';
const ACTION_TYPE_CANCEL = 'Cancel';

const initialState = {
	name: null,
	dateCreated: null,
	bucketListItemType: null,
	completed: null,
	latitude: null,
	longitude: null
};

export const actionCreators = {
	cancel: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_CANCEL });
	},
	add: (
		name,
		dateCreated,
		bucketListItemType,
		completed,
		latitude,
		longitude
	) => async (dispatch, getState) => {
		dispatch
			({
				type: ACTION_TYPE_ADD,
				name,
				dateCreated,
				bucketListItemType,
				completed,
				latitude,
				longitude
			});
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type == ACTION_TYPE_ADD) {
		alert('Add Reducer Event -> implement');
	}
	else if (action.type === ACTION_TYPE_CANCEL) {
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();
		window.location = host + '/login';
	}

	return state;
};