import * as api from "../../api";

export const GET_PAYMENTS = 'GET_PAYMENTS';
export const CREATE_PAYMENT = 'CREATE_PAYMENT';

export const getPayments = (debtId) => async (dispatch) => {
  try {
    const response = await api.getPayments(debtId);
    dispatch({ type: GET_PAYMENTS, payload: response.data });
  } catch (error) {
    console.error('Failed to fetch payments:', error);
  }
};

export const createPayment = (debtId, data) => async (dispatch) => {
  try {
    const response = await api.createPayment(debtId, data);
    dispatch({ type: CREATE_PAYMENT, payload: response.data });
  } catch (error) {
    console.error('Failed to create payment:', error);
  }
};