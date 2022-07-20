import React from 'react'
import IsEmployee from './IsEmployee'
import IsNotEmployee from './IsNotEmployee'

function ReturnIsEmployee(props) {
    if (props.isEmployee === true) {
      return <IsEmployee />
    }
    else{
      return <IsNotEmployee />
    }
}

export default ReturnIsEmployee