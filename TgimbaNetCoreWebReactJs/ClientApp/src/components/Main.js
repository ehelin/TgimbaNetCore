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

	constructor(props) {
		super(props);				
		const parsed = queryString.parse(this.props.location.search);
		if (parsed && parsed.sort) {
			this.sort = parsed.sort;
		}

		this.state = { 
			bucketListItems: null, 
			searchTerm: null, 
			showSearchResults: false 
		};
	}	  

	componentDidMount() {
		this.props.load(this.sort, '');							 
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
		let { bucketListItems, searchTerm, showSearchResults } = this.state;
		const showMainMenu = _ => {		   
			this.props.main();
		}	

		const cancel = _ => {	
			this.setState({ searchTerm: '' });
			this.props.load(this.sort, searchTerm);
		}

		const search = _ => {		
			this.props.load(this.sort, searchTerm);
		}
	
		var panelStyle = {
			"width": "100%",
			"text-align": "center",
			"vertical-align": " middle"
		};

		var searchResultsPanelStyle = { "display":"none" };

		if (this.props.showSearchResults && this.props.showSearchResults === true)
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