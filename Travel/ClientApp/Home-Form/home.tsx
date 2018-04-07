import "es6-promise";
import { render } from 'react-dom';
import * as React from 'react';
import * as _ from 'lodash';
import HomeFormContainer from './Home-form-container';


var app = React.createElement(HomeFormContainer);;
const appMount = document.getElementById('home-body-form');
render(app, appMount);