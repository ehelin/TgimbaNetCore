import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Main';
import Button from './Button';
var utilsRef = require('../common/Utilities');

class Main extends React.Component {
	constructor(props) {
		super(props);
		if (props && props.bucketListItems && props.bucketListItems.length > 0) {
			this.state = props.bucketListItems;
		} else {
			this.state = {
				bucketListItems: []
			};	 
		}

		//var utils = Object.create(utilsRef.Utilities);
		//if (utils.IsLoggedIn()) {
		//	this.props.load();
		//}  
	}

	//componentDidMount() {
	//	this.props.load();
	//	//this.props.loadSchools(this.props.termId);
	//}

	render() {
		const showMainMenu = _ => {		   
			this.props.main();
		}

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

		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (<div style={panelStyle}>
			<h1>React JS - Main Panel</h1>
			<Button onPress={showMainMenu} id="btnMainMenu">Menu</Button>
			<table border="1">
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
			</table>
		</div>);

	

		//return (	   
		//	<div style={panelStyle}>
		//		<h1>React JS - Main Panel</h1>
		//		<Button onPress={showMainMenu} id="btnMainMenu">Menu</Button>
		//		<table border="1">
		//			<tr>
		//				<td>col 1</td>
		//				<td>col 2</td>
		//			</tr>
		//		</table>
		//	</div>
		//);
	};
}

export default connect(
	state => state.main,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Main);