import './App.css';
import NewPersonForm from './NewPersonForm';
import PersonNavbar from './PersonNavbar';


function App() {
  return (
    <div className='App'>
      <PersonNavbar navbarId="PersonNavbar"/>
      <NewPersonForm id="PersonForm"/>
    </div>
  );
}

export default App;
