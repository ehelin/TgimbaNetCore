import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Registration';
import Button from './userInterface/Button';
import withRouter from 'react-router-dom';		 

class Registration extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			username: null,	 
			email: null,
			password: null,
			confirmPassword: null
		};
	}

	render() {
		let {
			username,
			email,
			password,
			confirmPassword } = this.state;
			
		if (this.props.isRegistered === true) {	
			this.props.history.push('/login');
		}

		const processRegistration = _ => {
			this.props.register(
				username,
				email,
				password,
                confirmPassword,
                this.props.history);
		}  

		const processCancel = _ => {
			this.props.history.push('/login');
		}

		var tableStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (
			<div>
				<h1>React JS - Registration</h1><table style={tableStyle}>
					<tr>
						<td>
							<label>Username:</label>
							<input
								id="USER_CONTROL_REGISTRATION_USERNAME"
								type="text"
								value={username}
								onChange={event => this.setState({ username: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Email:</label>
							<input
								id="USER_CONTROL_REGISTRATION_EMAIL"
								type="text"
								value={email}
								onChange={event => this.setState({ email: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Password:</label>
							<input
								id="USER_CONTROL_REGISTRATION_PASSWORD"
								type="password"
								value={password}
								onChange={event => this.setState({ password: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<label>Confirm Password:</label>
							<input
								id="USER_CONTROL_REGISTRATION_CONFIRM_PASSWORD"
								type="password"
								value={confirmPassword}
								onChange={event => this.setState({ confirmPassword: event.target.value })}
							/>
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={processRegistration} id="hvJsRegisterBtn">Register</Button>
							<Button onPress={processCancel} id="hvJsRegisterCancelBtn">Cancel</Button>
						</td>
					</tr>
				</table>   
			</div>
		);

	}
}

export default connect(
	state => state.register,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Registration)