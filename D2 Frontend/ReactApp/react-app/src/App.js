import './App.css';
import PersonForm from './PersonForm';
import PersonNavbar from './PersonNavbar';
import PersonTable from './PersonTable';
import Script from './Script';

function App() {
  return (
    <div className='App'>
      <PersonNavbar navbarId="PersonNavbar"/>
      <PersonForm formId="PersonForm"/>
      <PersonTable tableId="PersonTable"/>
      <Script scriptName="SubmitPerson.js"/>

    </div>
  );
}

export default App;
