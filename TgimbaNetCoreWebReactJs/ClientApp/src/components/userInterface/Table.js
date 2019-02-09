import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/userInterface/Table';	

class Table extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		const bucketListItems = [
			{
				name: 'Eat at flowParis restraurant (on Westhimer)',
				dateCreated: '8/05/2015',
				bucketListItemType: 3,
				completed: 'true',
				latitude: 29.7371000000,
				longitude: 95.4803000000,
				databaseId: 109,
				userName: null
			},
			{
				name: 'see sink holes at Cenote Samula Yucatan Mexico',
				dateCreated: '8/07/2015',
				bucketListItemType: 3,
				completed: 'false',
				latitude: 34.7371000000,
				longitude: 35.4803000000,
				databaseId: 110,
				userName: null
			}
		]

		var trList = bucketListItems.map((bucketListItem, index) => {
			return (
				<tr key={bucketListItem.name}>
					<td>{bucketListItem.name}</td>
					<td>{bucketListItem.dateCreated}</td>
					<td>{bucketListItem.bucketListItemType}</td>
					<td>{bucketListItem.completed}</td>
					<td>{bucketListItem.latitude}</td>
					<td>{bucketListItem.longitude}</td>
				</tr>);
		});	

		return (<table border="1">
				<thead>
					<th>Name</th>
					<th>Date Created</th>
					<th>Category</th>
					<th>Completed</th>
					<th>Latitude</th>
					<th>Longitude</th>
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
										