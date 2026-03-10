import * as api from "../../api";

export const GET_CHALLENGES = 'GET_CHALLENGES';
export const GET_CHALLENGE = 'GET_CHALLENGE';
export const CREATE_CHALLENGE = 'CREATE_CHALLENGE';
export const JOIN_CHALLENGE = 'JOIN_CHALLENGE';

export const getChallenges = () => async (dispatch) => {
  try {
    const response = await api.getChallenges();
    dispatch({ type: GET_CHALLENGES, payload: response.data });
  } catch (error) {
    console.error('Failed to fetch challenges:', error);
  }
};

export const getChallenge = (id) => async (dispatch) => {
  try {
    const response = await api.getChallenge(id);
    dispatch({ type: GET_CHALLENGE, payload: response.data });
  } catch (error) {
    console.error('Failed to fetch challenge:', error);
  }
};

export const createChallenge = (data) => async (dispatch) => {
  try {
    const response = await api.createChallenge(data);
    dispatch({ type: CREATE_CHALLENGE, payload: response.data });
  } catch (error) {
    console.error('Failed to create challenge:', error);
  }
};

export const joinChallenge = (id) => async (dispatch) => {
  try {
    const response = await api.joinChallenge(id);
    dispatch({ type: JOIN_CHALLENGE, payload: response.data });
  } catch (error) {
    console.error('Failed to join challenge:', error);
  }
};