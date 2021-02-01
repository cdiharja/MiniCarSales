import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { GetCarsData } from './components/GetCarsData';
import { GetBoatsData } from './components/GetBoatsData';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/get-boats' component={GetBoatsData} />
        <Route path='/get-cars' component={GetCarsData} />
      </Layout>
    );
  }
}
