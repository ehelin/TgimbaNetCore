import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Main';
import Button from './Button';

class Main extends React.Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	render() {
		const showMainMenu = _ => {
			//alert('main menu display');
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
				<p>main.html</p>
			</div>

		);
	};
}

export default connect(
	state => state.main,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Main);