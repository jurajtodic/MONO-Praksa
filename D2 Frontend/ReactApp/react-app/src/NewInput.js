import React from 'react'

function NewInput(props) {
  return (
    <div>
        <input id={props.id} type={props.type} value={props.value} onChange={props.onChange} placeholder={props.placeholder} required/><br/>
    </div>
  )
}

export default NewInput