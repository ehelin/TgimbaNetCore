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

		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (
			<div style={panelStyle}>
				<h1>React JS - Main Panel</h1>
				<Button onPress={showMainMenu} id="btnMainMenu">Menu</Button>
				<Table></Table>
			</div>
		);
	};
}

export default connect(
	state => state.main,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Main);