import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { AllCustomers } from "./components/AllCustomers";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route path="/Customers" component={AllCustomers} />
      </Layout>
    );
  }
}
