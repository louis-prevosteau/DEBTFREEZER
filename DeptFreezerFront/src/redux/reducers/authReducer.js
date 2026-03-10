import { LOGIN_SUCCESS, LOGOUT } from "../actions/authActions";

export const AuthReducer = (state = { user: null }, action) => {
  switch (action.type) {
    case LOGIN_SUCCESS:
      return { ...state, user: action.payload };
    case LOGOUT:
      return { ...state, user: null };
    default:
      return state;
  }
};