import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Edit'; 
import Button from './userInterface/Button';
import BucketListItem from './userInterface/BucketListItem';		
import withRouter from 'react-router-dom';	
var utilsRef = require('../common/Utilities');
const queryString = require('query-string');
   
class Edit extends React.Component {
	constructor(props) {
		super(props);
		const parsed = queryString.parse(this.props.location.search);

		this.state = {
			name: parsed.name,
			dateCreated: parsed.dateCreated,
			bucketListItemType: parsed.bucketListItemType,
			completed: parsed.completed,
			latitude: parsed.latitude,
			longitude: parsed.longitude,
			databaseId: parsed.databaseId,
			userName: parsed.userName
		};
	}			  

	formSubmit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
        this.props.edit(name, dateCreated, bucketListItemType, completed,
                        latitude, longitude, databaseId, userName);
	}

	formCancel() {			  	
		this.props.history.push('/login'); 
	}				 

	render() {
		let { name, dateCreated, bucketListItemType, completed, latitude,
			longitude, databaseId, userName } = this.state;

		return (
			<div>
				<BucketListItem parent={this}
					name={name}
					dateCreated={dateCreated}
					bucketListItemType={bucketListItemType}
					completed={completed} 
					latitude={latitude}									
					longitude={longitude} 
					databaseId={databaseId} 
					userName={userName}
				></BucketListItem>
			</div>
		);
	}
}

export default connect(
	state => state.edit,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Edit)

