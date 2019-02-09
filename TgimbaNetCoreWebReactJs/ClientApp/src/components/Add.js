import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Add'; // TODO -> add
import Button from './userInterface/Button';
var utilsRef = require('../common/Utilities');
   
class Add extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			name: null,
			dateCreated: null,
			bucketListItemType: null,
			completed: null,
			latitude: null,
			longitude: null
		};
	}

	render() {						  
		let {name, dateCreated, bucketListItemType, completed, latitude, longitude} = this.state;

		const processAdd = _ => {
			this.props.add(name, dateCreated, bucketListItemType, completed, latitude, longitude);
		}

		const navigateCancel = _ => {
			this.props.cancel();
		}

		var utils = Object.create(utilsRef.Utilities);
		var tableStyle = utils.GetDefaultTableStyle();

		return (
			<div>
				<h1>React JS - Add</h1>
				<table style={tableStyle}>
					<tr>
						<td>
							<label>Item Name:</label>
							<input
								id="USER_CONTROL_ADD_ITEM_NAME"
								type="text"
								value={name}
								onChange={event => this.setState({ name: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Date Created:</label>
							<input
								id="USER_CONTROL_ADD_DATE_CREATED"
								type="text"
								value={dateCreated}
								//onChange={event => this.setState({ dateCreated: event.target.value })}
								readonly
							/>																  
						</td>
					</tr>
					<tr>
						<td>
							<label>Category:</label>
							<select id="USER_CONTROL_ADD_ITEM_CATEGORY" value={bucketListItemType}>
								<option value="Hot">Hot</option>
								<option value="Warm" selected="selected">Warm</option>
								<option value="Cool">Cool</option>
							</select>
						</td>
					</tr>
					<tr>
						<td>
							<label>Completed:</label>																
							<input
								id="USER_CONTROL_ADD_COMPLETED"
								type="checkbox"
								value={completed}
								onChange={event => this.setState({ completed: event.target.value })}
								checked
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Latitude:</label>								 
							<input
								id="USER_CONTROL_ADD_LATITUDE"
								type="text"
								value={latitude}
								onChange={event => this.setState({ latitude: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Longitude:</label>							  
							<input
								id="USER_CONTROL_ADD_LONGITUDE"
								type="text"
								value={longitude}
								onChange={event => this.setState({ longitude: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={processAdd} id="hvJsAddSubmitBtn">Add</Button>
							<Button onPress={navigateCancel} id="hvJsAddCancellBtn">Cancel</Button>
						</td>
					</tr>
				</table>		
			</div>
		)						   
	}
}

export default connect(
	state => state.add,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Add)

