import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as Counter from './Counter';
import * as Login from './Login';
import * as Registration from './Registration';
import * as Main from './Main';
import * as WeatherForecasts from './WeatherForecasts';	
import * as Button from './userInterface/Button';	  
import * as MainMenu from './MainMenu';
import * as Add from './Add';
import * as Edit from './Edit';
import * as Table from './userInterface/Table';
import * as BucketListItem from './userInterface/BucketListItem';

export default function configureStore(history, initialState) {
  const reducers = {
	  add: Add.reducer,
	  button: Button.reducer,
	  counter: Counter.reducer,
	  login: Login.reducer,
	  main: Main.reducer,
	  mainmenu: MainMenu.reducer,
	  register: Registration.reducer,	
	  table: Table.reducer,
	  bucketListItem: BucketListItem.reducer,
	  edit: Edit.reducer,
	  weatherForecasts: WeatherForecasts.reducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
