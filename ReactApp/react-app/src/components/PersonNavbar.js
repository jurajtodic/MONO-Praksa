import React from 'react'

function PersonNavbar(props) {
  return (
    <ul id={props.navbarId}>
        <li>Home</li>
        <li>Contacts</li>
        <li>New Person</li>
        <li>Info</li>
    </ul>
  )
}

export default PersonNavbar