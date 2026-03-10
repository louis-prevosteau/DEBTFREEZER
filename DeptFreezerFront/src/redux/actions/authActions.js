import * as api from "../../api";

export const LOGIN_SUCCESS = 'LOGIN_SUCCESS';
export const LOGOUT = 'LOGOUT';

export const register = (data) => async (dispatch) => {
  try {
    const response = await api.register(data);
    const { token, user } = response.data;
    localStorage.setItem('token', token);
    dispatch({ type: LOGIN_SUCCESS, payload: user });
  } catch (error) {
    console.error('Registration failed:', error);
  }
};

export const login = (data) => async (dispatch) => {
  try {
    const response = await api.login(data);
    const { token, user } = response.data;
    localStorage.setItem('token', token);
    dispatch({ type: LOGIN_SUCCESS, payload: user });
  } catch (error) {
    console.error('Login failed:', error);
  }
};

export const logout = () => (dispatch) => {
  localStorage.removeItem('token');
  dispatch({ type: LOGOUT });
};