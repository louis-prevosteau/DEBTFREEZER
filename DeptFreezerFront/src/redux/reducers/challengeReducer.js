import { CREATE_CHALLENGE, GET_CHALLENGE, GET_CHALLENGES, JOIN_CHALLENGE } from "../actions/challengeActions";

export const ChallengesReducer = (state = { challenges: [], challenge: null }, action) => {
  switch (action.type) {
    case GET_CHALLENGES:
      return { ...state, challenges: action.payload };
    case CREATE_CHALLENGE:
      return { ...state, challenges: [...state.challenges, action.payload] };
    default:
      return state;
  }
};

export const ChallengeReducer = (state = { challenge: null }, action) => {
  switch (action.type) {
    case GET_CHALLENGE:
    case JOIN_CHALLENGE:
      return { ...state, challenge: action.payload };
    default:
      return state;
  }
};