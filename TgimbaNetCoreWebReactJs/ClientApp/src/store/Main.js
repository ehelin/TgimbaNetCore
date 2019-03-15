var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');

const ACTION_TYPE_MAIN_MENU = 'MainMenu';
const ACTION_TYPE_LOAD = 'Load';
const ACTION_TYPE_DELETE = 'Delete';
const ACTION_TYPE_EDIT = 'Edit';
						 
const initialState = {
	bucketListItems: null,
	searchTerm: null, 
	showSearchResults: false
};

export const actionCreators = {
	main: () => async (dispatch, getState) => {		 
		dispatch({ type: ACTION_TYPE_MAIN_MENU });
	},
	delete: (id) => async (dispatch, getState) =>
	{	 
		dispatch({ type: ACTION_TYPE_DELETE, id });
	}, 	
	edit: (name, dateCreated, bucketListItemType, completed,
		latitude, longitude, databaseId, userName) => async (dispatch, getState) =>
	{											
		dispatch({
			type: ACTION_TYPE_EDIT, name, dateCreated,
			bucketListItemType, completed, latitude, longitude, databaseId, userName
		});
	}, 	
	load: (sort, searchTerm) => async (dispatch, getState) => {
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);

		var token = session.SessionGet(constants.SESSION_TOKEN);
		var userName = session.SessionGet(constants.SESSION_USERNAME);	   

		let url = 'BucketListItem/GetBucketListItems'
			+ '?encodedUserName=' + btoa(userName)
			+ '&encoderedSortString=' + btoa(sort)
			+ '&encodedToken=' + btoa(token);

		let showSearchResults = false; 
		if (searchTerm && searchTerm.length > 0)
		{
			url += '&encodedSrchTerm=' + btoa(searchTerm);
			showSearchResults = true;
		}

		const response = await fetch(url);		 
		const bucketListItems = await response.json();

		for (let i = 0; i < bucketListItems.length; i++) {
			bucketListItems[i].number = i + 1;
		}

		dispatch({ type: ACTION_TYPE_LOAD, bucketListItems, 
					showSearchResults, searchTerm });
	}
};

export const reducer = (state, action) => {
	state = state || initialState;		

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_LOAD) {
		return {
			...state,
			bucketListItems: action.bucketListItems,
			showSearchResults: action.showSearchResults,	
			searchTerm: action.searchTerm
		};
	}
	else if (action.type == ACTION_TYPE_DELETE) {
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);

		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();

		var userName = session.SessionGet(constants.SESSION_USERNAME);	

		const url = host + '/BucketListItem/DeleteBucketListItem'
			+ '?dbId=' + action.id				
			+ '&encodedUser=' + btoa(userName)
			+ '&encodedToken=' + btoa(session.SessionGet(constants.SESSION_TOKEN));

		const xhr = new XMLHttpRequest();
		xhr.open('delete', url, true);
		xhr.onload = (data) => {
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0
				&& data.currentTarget.response === 'true') {
				//window.location = host + '/main';
			} else {
				alert('delete failed');
			}
		};
		xhr.send();
	}
	else if (action.type == ACTION_TYPE_MAIN_MENU) {
		window.location = host + '/mainmenu';
	}
	else if (action.type === ACTION_TYPE_EDIT) {
		var queryString = '?name=' + action.name
			+ '&dateCreated=' + action.dateCreated
			+ '&bucketListItemType=' + action.bucketListItemType
			+ '&completed=' + action.completed
			+ '&latitude=' + action.latitude
			+ '&longitude=' + action.longitude
			+ '&databaseId=' + action.databaseId
			+ '&userName=' + action.userName;
					   
		window.location = host + '/edit' + queryString;
	}											  

	return state;
};