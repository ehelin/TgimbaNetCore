import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/userInterface/Table';	

class Table extends React.Component {
	constructor(props) {
		super(props);
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
					<td>{bucketListItem.completed}</td>
					<td>{bucketListItem.latitude}</td>
					<td>{bucketListItem.longitude}</td>
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
										