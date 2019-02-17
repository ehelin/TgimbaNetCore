var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_MAIN_MENU = 'MainMenu';
const ACTION_TYPE_LOAD = 'Load';
						 
const initialState = {
	bucketListItems: null
};

export const actionCreators = {
	main: () => async (dispatch, getState) => {		 
		dispatch({ type: ACTION_TYPE_MAIN_MENU });
	}, 	
	load: () => async (dispatch, getState) => {
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);

		var token = session.SessionGet(constants.SESSION_TOKEN);
		var userName = session.SessionGet(constants.SESSION_USERNAME);	   

		const url = 'BucketListItem/GetBucketListItems'
			+ '?encodedUserName=' + btoa(userName)
			+ '&encoderedSortString=' + btoa('')
			+ '&encodedToken=' + btoa(token);
		const response = await fetch(url);
		const bucketListItems = await response.json();

		for (let i = 0; i < bucketListItems.length; i++) {
			bucketListItems[i].number = i + 1;
		}

		dispatch({ type: ACTION_TYPE_LOAD, bucketListItems });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;		

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_LOAD) {
		return {
			...state,
			bucketListItems: action.bucketListItems
		};
	}
	if (action.type == ACTION_TYPE_MAIN_MENU) {
		window.location = host + '/mainmenu';
	}

	return state;
};