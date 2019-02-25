import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Add'; // TODO -> add
import Button from './userInterface/Button';
import BucketListItem from './userInterface/BucketListItem';
var utilsRef = require('../common/Utilities');
   
class Add extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			name: '',
			dateCreated: '',
			bucketListItemType: '',
			completed: null,
			latitude: '',
			longitude: '',
			databaseId: '',
			userName: ''
		};
	}

	formSubmit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
		alert('edit submit - ' + name);
		//this.props.add(name, dateCreated, bucketListItemType, completed, latitude, longitude);
	}

	formCancel() {
		this.props.cancel();
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
	state => state.add,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Add)

