import React from 'react'

function Button(props) {
  return (
    <button id={props.buttonId} type="button">{props.message}</button>
  )
}

export default Button;