import React from 'react'

function PersonTable(props) {
  return (
    <table id={props.tableId}>
      <thead>
        <tr>
          <th>First name</th>
          <th>Last name</th>
          <th>Age</th>
          <th>Email</th>
        </tr>
      </thead>
    </table>
  )
}

export default PersonTable