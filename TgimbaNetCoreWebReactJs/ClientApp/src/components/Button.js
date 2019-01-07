import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Button';	

class Button extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { onPress, children, id } = this.props;  

		//var tableStyle = {					 
		//	"width": "100%",			
		//};

		return (		   
			<button type="button" onClick={onPress} id={id}>
				{children}
			</button>
		);
	};
}								 

export default connect(
	state => state.button,
	dispatch => bindActionCreators(actionCreators, dispatch)
)(Button);
										