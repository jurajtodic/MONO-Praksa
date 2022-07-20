import React, { useEffect, useState } from 'react'
import FantasyLeagueService from '../services/FantasyLeagueSerice'

const FantasyLeagueTable = () => {
  const [fantasyLeagues, setFantasyLeagues] = useState([]);
  const [currentFantasyLeague, setCurrentFantasyLeague] = useState(null);
  const [searchstring, setSearchstring] = useState("");

  useEffect(() => {
    retrieveFantasyLeagues();
  }, []);

  const onChangeSearchName = e => {
    const searchstring = e.target.value;
    setSearchstring(searchstring);
  }

  const retrieveFantasyLeagues = () => {
    FantasyLeagueService.getAll().then(response => {
      setFantasyLeagues(response.data);
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  };

  const setActiveFantasyLeague = (fantasyLeague) => {
    setCurrentFantasyLeague(fantasyLeague);
  }

  const findByName = () => {
    FantasyLeagueService.findByTitle(searchstring).then(response => {
      setFantasyLeagues(response.data);
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  };

  return (
    <div>
      <div className="col-md-8">
        <div className="input-group mb-3">
          <input type="text" className="form-control" placeholder="Search by name" value={searchstring} onChange={onChangeSearchName}/>
          <div className="input-group-append">
            <button className="btn btn-outline-secondary" type="button" onClick={findByName}>Search</button>
          </div>
        </div>
      </div>
      <div>
        <table id="PersonTable">
          <tr>
              <th>Fantasy League Name</th>
              <th>Budget</th>
              <th>Maximum Teams</th>
              <th>Maximum Free Subs</th>
              <th>Maximum Drivers Per Team</th>
              <th>Creation Date</th>
          </tr>
          {fantasyLeagues && fantasyLeagues.map((league) => (
            <tr>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.FantasyLeagueName}</td>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.Budget}</td>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.MaximumTeams}</td>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.MaximumFreeSubs}</td>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.MaximumDriversPerTeam}</td>
              <td onClick={() => setActiveFantasyLeague(league)}>{league.CreationDate}</td>
            </tr>
          ))}
        </table>
      </div>
      <div className="col-md-6">
        {currentFantasyLeague ? (
          <div>
            <h4>{currentFantasyLeague.FantasyLeagueName}</h4>
            <div>
              <label>Id:</label>
              {currentFantasyLeague.FantasyLeagueId}
            </div>
            <div>
              <label>Budget:</label>
              {currentFantasyLeague.Budget}
            </div>
            <div>
              <label>Maximum teams:</label>
              {currentFantasyLeague.MaximumTeams}
            </div>
            <div>
              <label>Maximum free subs:</label>
              {currentFantasyLeague.MaximumFreeSubs}
            </div>
            <div>
              <label>Maximum drivers per team:</label>
              {currentFantasyLeague.MaximumDriversPerTeam}
            </div>
            <div>
              <label>CreationDate:</label>
              {currentFantasyLeague.CreationDate}
            </div>
          </div>
        ):(
          <div>
            <br/>
            <p>Select a fantasy league to edit</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default FantasyLeagueTable