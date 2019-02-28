var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_EDIT_TO_SERVER = 'EditToServer';
const ACTION_TYPE_CANCEL = 'Cancel';
const ACTION_TYPE_EDIT = 'Edit';

const initialState = {
	name: null,
	dateCreated: null,
	bucketListItemType: null,
	completed: null,
	latitude: null,
	longitude: null,
	databaseId: null,
	userName: null
};

export const actionCreators = {
	cancel: () => async (dispatch, getState) => {
		dispatch({ type: ACTION_TYPE_CANCEL });
	},
	edit: (
		name,
		dateCreated,
		bucketListItemType,
		completed,
		latitude,
		longitude,
		databaseId,
		userName
	) => async (dispatch, getState) => {
		dispatch
			({
				type: ACTION_TYPE_EDIT_TO_SERVER,
				name,
				dateCreated,
				bucketListItemType,
				completed,
				latitude,
				longitude,
				databaseId,
				userName
			});
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type == ACTION_TYPE_EDIT_TO_SERVER) {  
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);			  

		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();

		var userName = session.SessionGet(constants.SESSION_USERNAME);		
		var completed = action.completed === true ? 'true' : 'false';

		const url = host + '/BucketListItem/EditBucketListItem'
			+ '?Name=' + action.name
			+ '&DateCreated=' + action.dateCreated
			+ '&BucketListItemType=' + action.bucketListItemType
			+ '&Completed=' + completed
			+ '&Latitude=' + action.latitude
			+ '&Longitude=' + action.longitude
			+ '&DatabaseId=' + action.databaseId
			+ '&UserName=' + userName
			+ '&encodedUser=' + btoa(userName)
			+ '&encodedToken=' + btoa(session.SessionGet(constants.SESSION_TOKEN));

		const xhr = new XMLHttpRequest();
		xhr.open('post', url, true);
		xhr.onload = (data) => {
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0
				&& data.currentTarget.response === 'true') {   
				window.location = host + '/main';
			} else {
				alert('Add failed');
			}
		};
		xhr.send();
	}
	else if (action.type === ACTION_TYPE_CANCEL) {
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();
		window.location = host + '/login';
	}											   

	return state;
};