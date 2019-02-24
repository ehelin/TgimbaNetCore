import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/userInterface/Table';
import Button from '../userInterface/Button';

class Table extends React.Component {
	constructor(props) {
		super(props);
	}

	formEdit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
		alert('formDelete: ' + name);
	}

	formDelete(id) {
		alert('formDelete: ' + id);
	}

	render() {
		const { bucketListItems } = this.props;			  

		var trList = bucketListItems.map((bucketListItem, index) => {
			return (
				<tr key={bucketListItem.name}>
					<td>{bucketListItem.number}</td>
					<td>{bucketListItem.name}</td>
					<td>{bucketListItem.dateCreated}</td>
					<td>{bucketListItem.bucketListItemType}</td>
					<td>{bucketListItem.completed === true ? 'true' : 'false'}</td>
					<td>{bucketListItem.latitude}</td>
					<td>{bucketListItem.longitude}</td>
					<td>{bucketListItem.databaseId}</td>
					<td>{bucketListItem.userName}</td>
					<td>											  
						<Button onPress={() => this.formEdit(		
							bucketListItem.name, 
							bucketListItem.dateCreated,
							bucketListItem.bucketListItemType,
							bucketListItem.completed,
							bucketListItem.latitude,
							bucketListItem.longitude,
							bucketListItem.databaseId,
							bucketListItem.userName,
						)} id="hvJsFormEditBtn">Edit</Button>
					</td>		
					<td>
						<Button onPress={() => this.formDelete(
							bucketListItem.databaseId
						)} id="hvJsFormDeleteBtn">Delete</Button>
					</td>	
				</tr>);
		});	

		return (<table border="1">
				<thead>			 
					<th></th>
					<th>Name</th>
					<th>Date Created</th>
					<th>Category</th>
					<th>Completed</th>
					<th>Latitude</th>
					<th>Longitude</th>
					<th>DbId</th>
					<th>UserName</th>
					<th></th>
					<th></th>			
				</thead>
				<tbody>
					{trList}
				</tbody>
			</table>);	
	};
}		
									 
export default connect(
	state => state.table,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Table);
										