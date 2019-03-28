import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Add';
import BucketListItem from './userInterface/BucketListItem';   
import Button from './userInterface/Button';   
import withRouter from 'react-router-dom';	

class Add extends React.Component {
	constructor(props) {
		super(props);	 
	}

	formSubmit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
        this.props.add(name, dateCreated, bucketListItemType, completed,
            latitude, longitude);
	}

	formCancel() {
		this.props.history.push('/login'); 
	}				 

	render() {	
		return (
			<div> 		
				<BucketListItem parent={this}></BucketListItem>
			</div>
		);						   
	}
}

export default connect(
	state => state.add,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Add)

