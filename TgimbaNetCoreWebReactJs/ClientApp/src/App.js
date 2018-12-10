import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import Login from './components/Login';
import Registration from './components/Registration';
import FetchData from './components/FetchData';
import Main from './components/Main';

export default () => (
  <Layout>
    <Route exact path='/' component={Login} />	  
    <Route exact path='/login' component={Login} />	  
    <Route exact path='/register' component={Registration} />	
    <Route exact path='/main' component={Main} />
    <Route path='/counter' component={Counter} />	
	<Route exact path='/home' component={Home} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
