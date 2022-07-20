import './App.css';
import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css"
import PersonNavbar from './components/PersonNavbar';
import AddFantasyLeague from './components/AddFantasyLeague';
import FantasyLeagueTable from './components/FantasyLeagueTable';


function App() {
  return (
    <div className='App'>
      <PersonNavbar navbarId="PersonNavbar"/>
      <AddFantasyLeague />
      <FantasyLeagueTable />
      {/* <NewPersonForm id="PersonForm"/> */}
    </div>
  );
}

export default App;
