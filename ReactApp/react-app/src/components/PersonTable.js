import React from 'react'
import ReturnIsEmployee from './ReturnIsEmployee'

function PersonTable(props) {
  return (
    <table id="PersonTable">
      <tr>
          <th>First name</th>
          <th>Last name</th>
          <th>Age</th>
          <th>Email</th>
          <th>Employee</th>
      </tr>
      {props.people.map((l) => (
          <tr>
              <td>{l.firstName}</td>
              <td>{l.lastName}</td>
              <td>{l.age}</td>
              <td>{l.email}</td> 
              <ReturnIsEmployee isEmployee={l.isEmployee} />           
          </tr>
      ))}
    </table>
  )
}

export default PersonTable
