import React from 'react'
import ReturnIsEmployee from './ReturnIsEmployee'

/*
class PersonTable extends React.Component {
  constructor(props){
    super(props);
    this.state = {}
  }
  render (){
    return (
      <table id="PersonTable">
        <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>Age</th>
            <th>Email</th>
            <th>Employee</th>
        </tr>
        {this.state.people.map((l) => (
            <tr>
                <td>{l.firstName}</td>
                <td>{l.lastName}</td>
                <td>{l.age}</td>
                <td>{l.email}</td> 
                <ReturnIsEmployee isEmployee={l.isEmployee} />           
            </tr>
        ))}
      </table>
    );
  }
}
*/

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
