import React, { useState } from 'react'
import PersonTable from './PersonTable';
import Button from './Button'

function NewPersonForm() {
    const [person, setPerson] = useState({isEmployee : false});
    const [list, setList] = useState([]);
    const [error, setError] = useState(null);

    function isValidEmail(email) {
        return /\S+@\S+\.\S+/.test(email);
    }

    function handleEmailChange(event){
        const value = event.target.type === 'checkbox' ? event.target.checked : event.target.value;
        setPerson({...person, [event.target.name]: value});

        if (!isValidEmail(event.target.value)) {
            setError('Email is invalid');
          } else {
            setError(null);
          }
    }

    function handleChange(event){
        console.log(person);
        const value = event.target.type === 'checkbox' ? event.target.checked : event.target.value;
        setPerson({...person, [event.target.name]: value});
    }

    function handleSubmit(event) {
        setList([...list, person]);
        setPerson({
            firstName: "",
            lastName: "",
            age: "",
            email: "",
            isEmployee : false
        });
        setError(null);
    }

  return (
    <div id="NewPersonForm">
        <form id="PersonForm">
            <input type="text" name="firstName" value={person.firstName} onChange={handleChange} placeholder="First name"/><br/>
            <input type="text" name="lastName" value={person.lastName} onChange={handleChange} placeholder="Last name"/><br/>
            <input type="number" name="age" value={person.age} onChange={handleChange} placeholder="Age"/><br/>
            <div style={{display : 'flex'}}>
                <input type="email" name="email" value={person.email} onChange={handleEmailChange} placeholder="Email"/>
                {error && <h3 style={{color: 'red'}}>{error}</h3>}
            </div>
            <label id="employeeLabel">Is Employee:</label>
            <input type="checkbox" name="isEmployee" checked={person.isEmployee} onChange={handleChange} /><br/>    
            <Button buttonId="SubmitButton" submitClick={handleSubmit} message="Submit" />
        </form>

        <PersonTable people={list}/>
    </div>
  )
}
export default NewPersonForm