import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/MainMenu';
import Button from './userInterface/Button';

class MainMenu extends React.Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	render() {
		const {} = this.props;  

		const AddBucketListItem = _ => {
			this.props.add();
		}

		const SortBucketListItem = _ => {
			this.props.sort();
		}

		const RunAlgorithm = _ => {
			this.props.runAlgorithm();
		}

		const LogOut = _ => {
			this.props.logout();
		}

		const Cancel = _ => {
			this.props.cancel();
		}

		var tableStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (	   
			<div>	
				<h1>React JS - Main Menu</h1>
				<table style={tableStyle}>
					<tr>
						<td>
							<Button onPress={AddBucketListItem} id="hvJsAddBucketListItemBtn">Add</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={SortBucketListItem} id="hvJsSortBucketListItemBtn">Sort</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={RunAlgorithm} id="hvJsRunAlgorithmBtn">Run Algorithm</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={LogOut} id="hvJsLogOutBtn">LogOut</Button> 					 
						</td>
					</tr>
					<tr>
						<td>
							<Button onPress={Cancel} id="hvJsCancelBtn">Cancel</Button> 					 
						</td>
					</tr>
				</table>		 
			</div>
		);
	};
}								 

export default connect(
	state => state.mainmenu,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(MainMenu);
										