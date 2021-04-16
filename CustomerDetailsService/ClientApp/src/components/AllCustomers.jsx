import React, { Component, useState } from "react";
import axios from "axios";
import "./AllCustomers.css";

export class AllCustomers extends Component {
  constructor() {
    super();

    this.getCustomerhandler = this.getCustomerhandler.bind(this);
    this.getAllCustomersHandler = this.getAllCustomersHandler.bind(this);
    this.createCustomerHandler = this.createCustomerHandler.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
    this.deleteCustomerHandler = this.deleteCustomerHandler.bind(this);
  }

  state = {
    customers: [],
    name: "",
    age: "",
    showRefresh: false,
    currentCustomer: {},
    showCurrentCustomerTable: false,
  };

  handleInputChange(event) {
    if (event.target.name == "name") {
      this.setState({ name: event.target.value });
    } else {
      this.setState({ age: event.target.value });
    }
  }

  getCustomerhandler() {
    const { name } = this.state;
    fetch(`api/customer/${name}`)
      .then((res) => res.json())
      .then((response) =>
        this.setState({
          currentCustomer: response,
          showCurrentCustomerTable: true,
        })
      );
  }

  getAllCustomersHandler() {
    fetch("api/Customer")
      .then((res) => res.json())
      .then((response) =>
        this.setState({ customers: response, showRefresh: true })
      );
  }

  createCustomerHandler() {
    const { name, age } = this.state;
    const bodyRequest = {
      name: name,
      age: parseInt(age),
      ageDetail: "string",
    };

    (async () => {
      const rawResponse = await fetch("api/Customer", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(bodyRequest),
      });
    })();
  }

  deleteCustomerHandler() {
    const { name } = this.state;
    (async () => {
      await fetch(`api/customer/${name}`, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
    })();
    this.setState({
      currentCustomer: {},
      showCurrentCustomerTable: false,
    });
  }

  render() {
    const {
      customers,
      showRefresh,
      showCurrentCustomerTable,
      currentCustomer,
    } = this.state;
    let button;
    if (showRefresh) {
      button = (
        <button type="button" onClick={this.getAllCustomersHandler}>
          Refresh
        </button>
      );
    } else {
      button = (
        <button type="button" onClick={this.getAllCustomersHandler}>
          Get All Customers
        </button>
      );
    }

    return (
      <div>
        {showRefresh && (
          <div>
            <h1>Customers</h1>
            <table>
              <tbody>
                <tr>
                  <th>Name</th>
                  <th>Age</th>
                </tr>
                {customers.map((customer) => (
                  <tr>
                    <td>{customer.name}</td>
                    <td>{customer.age}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
        {button}

        <input
          name="name"
          class="customer-input"
          type="text"
          onChange={this.handleInputChange}
          placeholder="Enter customers name"
        ></input>
        <input
          name="age"
          class="customer-input"
          type="text"
          onChange={this.handleInputChange}
          placeholder="Enter customers age"
        ></input>
        <button type="button" onClick={this.createCustomerHandler}>
          Create Customer
        </button>
        <div class="flexContainer">
          <input
            name="name"
            class="inputField"
            type="text"
            onChange={this.handleInputChange}
            placeholder="Enter customers name to retrieve their details"
          ></input>
          <input
            type="submit"
            onClick={this.getCustomerhandler}
            value="Retrieve"
          ></input>
        </div>
        {showCurrentCustomerTable && (
          <div>
            <table>
              <tbody>
                <tr>
                  <th>Name</th>
                  <th>Age</th>
                  <th>Age Detail</th>
                </tr>
                <tr>
                  <td>{currentCustomer.name}</td>
                  <td>{currentCustomer.age}</td>
                  <td>{currentCustomer.ageDetail}</td>
                </tr>
              </tbody>
            </table>
          </div>
        )}
        <button type="button" onClick={this.deleteCustomerHandler}>
          Delete Customer
        </button>
      </div>
    );
  }
}
