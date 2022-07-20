import http from "../http-common";

const getAll = () => {
  return http.get("/get_all_leagues");
};

const get = id => {
  return http.get(`/api/FantasyLeague/${id}`);
};

const create = data => {
  return http.post("/api/FantasyLeague", data);
};

const update = (id, data) => {
  return http.put(`/api/FantasyLeague/${id}`, data);
};
const remove = id => {
  return http.delete(`/api/FantasyLeague/${id}`);
};

const findByTitle = searchstring => {
  return http.get(`/get_all_leagues?searchstring=${searchstring}`);
};

/*
const removeAll = () => {
  return http.delete(`/tutorials`);
};
*/

const FantasyLeagueService = {
  getAll,
  get,
  create,
  update,
  remove,
  findByTitle
};

export default FantasyLeagueService;