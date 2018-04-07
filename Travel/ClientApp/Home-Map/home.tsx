import "es6-promise";
import { render } from 'react-dom';
import * as React from 'react';
import * as _ from 'lodash';
import HomeMapContainer from './home-map-container';

var app = React.createElement(HomeMapContainer);
const appMount = document.getElementById('home-body-map');
render(app, appMount);