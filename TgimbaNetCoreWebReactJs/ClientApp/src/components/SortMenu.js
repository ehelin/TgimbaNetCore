import withRouter from 'react-router-dom';	
import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/SortMenu';
import Button from './userInterface/Button';

class SortMenu extends React.Component {
	state;

	constructor(props) {
		super(props);
		this.state = {
			descending: false,
			checked: false
		};
	}
	
	sort(sortColumn, descending) {
		let sort = 'order by ' + sortColumn;

		if (descending === true) {
			sort += ' desc';
		}

		this.props.sort(sort);
	}
	
	cancel() {					    		
		this.props.history.push('/login'); 
	}

	render() {	
		let { descending, checked } = this.state;

		if (this.props.sortNavigation === true) {	
			this.props.history.push(this.props.sortRoute);
		}

		var tableStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		return (	   
			<div>	
				<table style={tableStyle}>
					<tr>
						<td>
							<Button 							
							onPress={() => this.sort('ListItemName', descending)} 
							id="hvJsSortItemBtn">Name</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button 
							onPress={() => this.sort('Created', descending)} 
							id="hvJsSortCreatedBtn">Created</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button 		  
							onPress={() => this.sort('Category', descending)} 
							id="hvJsSortCategoryBtn">Category</Button> 
						</td>
					</tr>
					<tr>
						<td>
							<Button 	  
							onPress={() => this.sort('Achieved', descending)}  
							id="hvJsSortAchievedBtn">Achieved</Button> 					 
						</td>						 
					</tr>
					<tr>
						<label>Descending Order:</label>
						<input type="checkbox"				  
							id="hvJsDescCheckbox"		
							onChange={event => this.setState(
							{
								checked: !checked,	 
								descending: !descending
							})}
							value={descending}
						/>	 					
					</tr>
					<tr>
						<td>
							<Button onPress={() => this.cancel()}  
								id="hvJsCancelBtn">Cancel</Button> 					 
						</td>
					</tr>
				</table>		 
			</div>
		);
	};
}								 

export default connect(
	state => state.sortmenu,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(SortMenu);
										