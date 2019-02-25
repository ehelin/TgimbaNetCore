import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';

import Add from './components/Add';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Home from './components/Home';
import Login from './components/Login';
import Main from './components/Main';
import MainMenu from './components/MainMenu';
import Registration from './components/Registration';
import Edit from './components/Edit';

export default () => (
  <Layout>									   
    <Route path='/add' component={Add} />  
    <Route path='/counter' component={Counter} />	
    <Route path='/edit' component={Edit} />  		
    <Route exact path='/' component={Login} />	  	
	<Route exact path='/home' component={Home} />
    <Route exact path='/login' component={Login} />	  	
	<Route exact path='/main' component={Main} />
	<Route exact path='/mainmenu' component={MainMenu} />		 
    <Route exact path='/register' component={Registration} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
