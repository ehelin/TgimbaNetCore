import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Main.js';

class Main extends React.Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	render() {
		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (
			<div style={panelStyle}>
				<p>main.html</p>
			</div>
		);
	};
}

export default connect(
	//state = {}, //state.main,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Main);