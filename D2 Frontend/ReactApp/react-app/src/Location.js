import React, { Component } from 'react'

export default class Location extends Component {
  render() {
    return (
      <div>
        <label>Location</label>
        <select name="store">
            <option value="newYork">New York</option>
            <option value="houston">Houston</option>
            <option value="losAngeles">Los Angeles</option>
            <option value="portland">Portland</option>
            <option value="paris">Paris</option>
            <option value="london">London</option>
        </select> <br/>
      </div>
    )
  }
}
