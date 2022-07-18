import React from 'react'
import Button from './Button'
import NewInput from './NewInput'

function PersonForm(props) {
  return (
    <form id={props.formId}>
      <NewInput type="text" id="fname" placeholder="First name"/>
      <NewInput type="text" id="lname" placeholder="Last name"/>
      <NewInput type="number" id="age" placeholder="Age"/>
      <NewInput type="email" id="email" placeholder="Email"/>
      <Button buttonId="SubmitButton" message="Submit" />
    </form>
  )
}

export default PersonForm