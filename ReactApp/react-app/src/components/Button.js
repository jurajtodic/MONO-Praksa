import React from 'react'

function Button(props) {
  return (
    <button id={props.buttonId} type="button" onClick={props.submitClick}>{props.message}</button>
  )
}

export default Button;