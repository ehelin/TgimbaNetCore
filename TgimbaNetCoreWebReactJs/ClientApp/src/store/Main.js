var utilsRef = require('../common/Utilities');
var constantsRef = require('../common/Constants');
var sessionRef = require('../common/Session');
		   
const ACTION_TYPE_LOAD = 'Load';
const ACTION_TYPE_DELETE = 'Delete';
const ACTION_TYPE_EDIT = 'Edit';	
const ACTION_TYPE_SEARCH = 'Search';
const ACTION_TYPE_CANCEL = 'Cancel';
						 
const initialState = {
	bucketListItems: null,
	showSearchResults: false
};

function setBucketListCounter(bucketListItems){	  
	for (let i = 0; i < bucketListItems.length; i++) {
		bucketListItems[i].number = i + 1;
	}

	return bucketListItems;
};

function getLoadCallUrl(sort, searchTerm) {
	var constants = Object.create(constantsRef.Constants);
	var session = Object.create(sessionRef.Session);

	var token = session.SessionGet(constants.SESSION_TOKEN);
	var userName = session.SessionGet(constants.SESSION_USERNAME);	   

	let url = 'BucketListItem/GetBucketListItems'
		+ '?encodedUserName=' + btoa(userName)
		+ '&encoderedSortString=' + btoa(sort)
		+ '&encodedToken=' + btoa(token);

	if (searchTerm && searchTerm.length > 0)
	{
		url += '&encodedSrchTerm=' + btoa(searchTerm);
	}

	return url;
};


export const actionCreators = {
	cancel: () => async (dispatch, getState) => {	  		 
		let url = getLoadCallUrl('', '');

		const response = await fetch(url);		 
		let bucketListItems = await response.json();
		bucketListItems = setBucketListCounter(bucketListItems);

		dispatch({ type: ACTION_TYPE_CANCEL, bucketListItems });
	},
	search: (searchTerm) => async (dispatch, getState) => {		  		 
		let url = getLoadCallUrl('', searchTerm);

		const response = await fetch(url);		 
		let bucketListItems = await response.json();
		bucketListItems = setBucketListCounter(bucketListItems);

		dispatch({ type: ACTION_TYPE_SEARCH, bucketListItems });
	},	 
	delete: (id, history) => async (dispatch, getState) =>
	{	 
		// TODO - refactor to simplify
		var constants = Object.create(constantsRef.Constants);
		var session = Object.create(sessionRef.Session);

		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();

		var userName = session.SessionGet(constants.SESSION_USERNAME);	

		const url = host + '/BucketListItem/DeleteBucketListItem'
			+ '?dbId=' + id				
			+ '&encodedUser=' + btoa(userName)
			+ '&encodedToken=' + btoa(session.SessionGet(constants.SESSION_TOKEN));

		const xhr = new XMLHttpRequest();
		xhr.open('delete', url, true);
		xhr.onload = (data) => {
			if (data && data.currentTarget
				&& data.currentTarget && data.currentTarget.response
				&& data.currentTarget.response.length > 0
				&& data.currentTarget.response === 'true') {
				window.location = host + '/main';
				dispatch({ type: ACTION_TYPE_DELETE });
			} else {
				alert('delete failed');
			}
		};
		xhr.send();
	}, 	
	edit: (name, dateCreated, bucketListItemType, completed,
			latitude, longitude, databaseId, userName) => async (dispatch, getState) =>
	{	
		var queryString = '/edit?name=' + name
			+ '&dateCreated=' + dateCreated
			+ '&bucketListItemType=' + bucketListItemType
			+ '&completed=' + completed
			+ '&latitude=' + latitude
			+ '&longitude=' + longitude
			+ '&databaseId=' + databaseId
			+ '&userName=' + userName;
					   
		dispatch({ type: ACTION_TYPE_EDIT, queryString });
	}, 	
	load: (sort, searchTerm) => async (dispatch, getState) => {		  
		let url = getLoadCallUrl(sort, searchTerm);

		const response = await fetch(url);		 
		let bucketListItems = await response.json();
		bucketListItems = setBucketListCounter(bucketListItems);

		dispatch({ type: ACTION_TYPE_LOAD,  bucketListItems});
	}
};

export const reducer = (state, action) => {
	state = state || initialState;		

	var utils = Object.create(utilsRef.Utilities);
	var host = utils.GetHost();

	if (action.type === ACTION_TYPE_LOAD || action.type == ACTION_TYPE_CANCEL) {	
		return {
			...state,					   
			showSearchResults: false,
			bucketListItems: action.bucketListItems
		};
	}
	else if (action.type == ACTION_TYPE_SEARCH) {
		return {
			...state,
			showSearchResults: true,
			bucketListItems: action.bucketListItems
		};
	}	  	
	else if (action.type == ACTION_TYPE_DELETE) {
		return {
			...state,
			deleteSuccessful: true
		}; 
	}	
	else if (action.type === ACTION_TYPE_EDIT) {   		  
		var utils = Object.create(utilsRef.Utilities);
		var host = utils.GetHost();  		
		window.location = host + action.queryString;	
	}										  

	return state;
};