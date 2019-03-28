var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_ADD_TO_SERVER = 'AddToServer';

const initialState = {
	name: null,
	dateCreated: null,
	bucketListItemType: null,
	completed: null,
	latitude: null,
	longitude: null,
	displayBucketList: false
};

export const actionCreators = {
	add: (
		name,
		dateCreated,
		bucketListItemType,
		completed,
		latitude,
        longitude
	) => async (dispatch, getState) => {
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);			  

		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();

		var userName = session.SessionGet(constants.SESSION_USERNAME);
		var completed = completed === true ? 'true' : 'false';

		const url = host + '/BucketListItem/AddBucketListItem'
			+ '?Name=' + name
			+ '&DateCreated=' + dateCreated
			+ '&BucketListItemType=' + bucketListItemType
			+ '&Completed=' + completed
			+ '&Latitude=' + latitude
			+ '&Longitude=' + longitude
			+ '&DatabaseId=' + ''
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
				dispatch
				({
					type: ACTION_TYPE_ADD_TO_SERVER
				});
			} else {
				alert('Add failed');
			}
		};
		xhr.send();
	}
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type == ACTION_TYPE_ADD_TO_SERVER) {		   
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();  		
		window.location = host + '/main';	
	}

	return state;
};