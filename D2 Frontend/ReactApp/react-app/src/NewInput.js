import React from 'react'

function NewInput(props) {
  return (
    <div className='newInput'>
        <input type={props.type} id={props.id} placeholder={props.placeholder} required/><br/>
    </div>
  )
}

export default NewInput