import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Main';
import Button from './userInterface/Button';
import Table from './userInterface/Table';
var utilsRef = require('../common/Utilities'); 
const queryString = require('query-string');

class Main extends React.Component {
	sort = ''; 
	searchTerm = '';
	firstLoad = false;

	constructor(props) {
		super(props);				
		const parsed = queryString.parse(this.props.location.search);
		if (parsed && parsed.sort) {
			this.sort = parsed.sort;
		}
		   	
		if (parsed && parsed.search) {
			this.searchTerm = parsed.search;
		} else {		
			this.searchTerm = '';
		}

		this.state = { 
			bucketListItems: null, 
			searchTerm: this.searchTerm
		};
	}	  

	componentDidMount() {
		this.props.load(this.sort, this.searchTerm);							 
	}

	//componentWillReceiveProps(nextProps) {
	//	this.props.load(this.sort, '');
	//}

	formEdit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName) {
		this.props.edit(name, dateCreated, bucketListItemType, completed, latitude, longitude, databaseId, userName);
	}

	formDelete(id) {
		this.props.delete(id);
	}

	render() {			   
		let { searchTerm } = this.firstLoad === false ? this.searchTerm : this.state;
		if (this.firstLoad === false) {
			this.firstLoad = true;	  
		} 

		const showMainMenu = _ => {		   
			this.props.main();
		}	

		const cancel = _ => {	
			this.props.cancel();
		}

		const search = _ => {		
			this.props.search(searchTerm);
		}
	
		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		var searchResultsPanelStyle = { "display":"none" };

		if (this.searchTerm && this.searchTerm.length > 0)
		{
			searchResultsPanelStyle = { "display":"block" };
		}  

		return (
			this.props.bucketListItems ?
				<div style={panelStyle}>
					<h1>React JS - Main Panel</h1>
					<table>
					<tr>
						<td> 																							 
						<Button onPress={showMainMenu} id="btnMainMenu">Menu</Button>
						</td>
						<td>
							<input	type="text" 
									id="USER_CONTROL_SEARCH_TEXT_BOX" 
									value={searchTerm}
									onChange={event => this.setState({ searchTerm: event.target.value })}
							/>							 
							<Button onPress={search} id="USER_CONTROL_SEARCH_BUTTON">Search</Button>
							<div id="cancelSrchResults" style={searchResultsPanelStyle}>
								<p>Viewing Search Results</p>																			 									
								<Button onPress={cancel} id="USER_CONTROL_CANCEL_BUTTON">Cancel</Button>
							</div>
						</td>
					</tr>		
				</table>
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