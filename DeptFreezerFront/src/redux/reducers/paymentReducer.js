import { CREATE_PAYMENT, GET_PAYMENTS } from "../actions/paymentsActions";

export const PaymentsReducer = (state = { payments: [] }, action) => {
  switch (action.type) {
    case GET_PAYMENTS:
        return { ...state, payments: action.payload };
    case CREATE_PAYMENT:
        return { ...state, payments: [...state.payments, action.payload] };
    default:
        return state;
  }
};