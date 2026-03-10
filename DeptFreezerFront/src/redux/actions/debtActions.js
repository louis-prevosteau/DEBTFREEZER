import * as api from "../../api";

export const GET_DEBTS = 'GET_DEBTS';
export const GET_DEBT = 'GET_DEBT';
export const CREATE_DEBT = 'CREATE_DEBT';
export const UPDATE_DEBT = 'UPDATE_DEBT';
export const DELETE_DEBT = 'DELETE_DEBT';

export const getDebts = () => async (dispatch) => {
  try {
        const response = await api.getDebts();
        dispatch({ type: GET_DEBTS, payload: response.data });
    } catch (error) {
        console.error('Failed to fetch debts:', error);
    }
};

export const getDebt = (id) => async (dispatch) => {
  try {
    const response = await api.getDebt(id);
    dispatch({ type: GET_DEBT, payload: response.data });
  } catch (error) {
    console.error('Failed to fetch debt:', error);
  }
};

export const createDebt = (data) => async (dispatch) => {
  try {
    const response = await api.createDebt(data);
    dispatch({ type: CREATE_DEBT, payload: response.data });
  } catch (error) {
    console.error('Failed to create debt:', error);
  }
};

export const updateDebt = (id, data) => async (dispatch) => {
  try {
    const response = await api.updateDebt(id, data);
    dispatch({ type: UPDATE_DEBT, payload: response.data });
  } catch (error) {
    console.error('Failed to update debt:', error);
  }
};

export const deleteDebt = (id) => async (dispatch) => {
  try {
    await api.deleteDebt(id);
    dispatch({ type: DELETE_DEBT, payload: id });
  } catch (error) {
    console.error('Failed to delete debt:', error);
  }
};