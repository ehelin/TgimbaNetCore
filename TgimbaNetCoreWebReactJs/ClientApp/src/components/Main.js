import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Main';
import Button from './userInterface/Button';
import Table from './userInterface/Table';
var utilsRef = require('../common/Utilities');

class Main extends React.Component {
	constructor(props) {
		super(props);
		this.state = { bucketListItems: null };
	}	  

	componentDidMount() {
		this.props.load();							 
	}

	componentWillReceiveProps(nextProps) {
		this.props.load();
	}

	formEdit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
		this.props.edit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName);
	}

	formDelete(id) {
		this.props.delete(id);
	}

	render() {
		let { bucketListItems } = this.state;
		const showMainMenu = _ => {		   
			this.props.main();
		}	
	
		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (
			this.props.bucketListItems ?
				<div style={panelStyle}>
					<h1>React JS - Main Panel</h1>
					<Button onPress={showMainMenu} id="btnMainMenu">Menu</Button>
					<Table bucketListItems={this.props.bucketListItems} main={this}></Table>
				</div> :
				<div> Loading ... </div>
		);			
	};
}

export default connect(
	state => state.main,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Main);