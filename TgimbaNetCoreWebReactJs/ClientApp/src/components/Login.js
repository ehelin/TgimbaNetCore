import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Login';
import Button from './userInterface/Button';   
import withRouter from 'react-router-dom';
var utilsRef = require('../common/Utilities');

class Login extends React.Component {
	constructor(props) {
		super(props);
		this.state = { username: null, password: null };	

		var utils = Object.create(utilsRef.Utilities);	
		if (utils.IsLoggedIn()) {
			var host = utils.GetHost();
			window.location = host + '/main';	
		}  			
	}

	render() {
		//var utils = Object.create(utilsRef.Utilities);
		//if (utils.IsLoggedIn()) {
		//	//var host = utils.GetHost();
		//	//window.location = host + '/main';	
		//	this.props.history.push('/main');
		//}
		//else {
		let { username, password } = this.state;

		const processLogin = _ => {
			this.props.login(username, password);
		}

		const navigateRegistration = _ => {
			this.props.history.push('/register');
		}

		var tableStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (
			<div>
				<h1>React JS - Login</h1>
				<table style={tableStyle}>
					<tr>
						<td>
							<label>Username:</label>
							<input
								id="USER_CONTROL_LOGIN_USERNAME"
								type="text"
								value={username}
								onChange={event => this.setState({ username: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Password:</label>
							<input
								id="USER_CONTROL_LOGIN_PASSWORD"
								type="password"
								value={password}
								onChange={event => this.setState({ password: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={processLogin} id="hvJsLoginBtn">Login</Button>
							<Button onPress={navigateRegistration} id="hvJsRegisterPanelBtn">Register</Button>
						</td>
					</tr>
				</table>
			</div>
		);
		//}
	};
}

export default connect(
	state => state.login,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Login);