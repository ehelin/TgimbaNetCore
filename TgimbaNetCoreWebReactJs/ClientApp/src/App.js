﻿import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';

import Add from './components/Add';
import Login from './components/Login';
import Main from './components/Main';
import MainMenu from './components/MainMenu'; 
import SortMenu from './components/SortMenu';
import Registration from './components/Registration';
import Edit from './components/Edit';

export default () => (
  <Layout>									   
    <Route path='/add' component={Add} />  
    <Route path='/edit' component={Edit} />  		
    <Route exact path='/' component={Login} />	  
    <Route exact path='/login' component={Login} />	  	
	<Route exact path='/main' component={Main} />
	<Route exact path='/mainmenu' component={MainMenu} />
	<Route exact path='/sortmenu' component={SortMenu} />		 
    <Route exact path='/register' component={Registration} />
  </Layout>
);
