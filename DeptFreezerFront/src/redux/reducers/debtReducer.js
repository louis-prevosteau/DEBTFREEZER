import { CREATE_DEBT, DELETE_DEBT, GET_DEBT, GET_DEBTS, UPDATE_DEBT } from "../actions/debtActions";

export const DebtsReducer = (state = [], action) => {
  switch (action.type) {
    case GET_DEBTS:
      return action.payload;
    case CREATE_DEBT:
      return [...state, action.payload];
    case DELETE_DEBT:
      return state.filter(debt => debt.id !== action.payload);
    default:
      return state;
  }
};

export const DebtReducer = (state = null, action) => {
  switch (action.type) {
    case GET_DEBT:
      return action.payload;
    case UPDATE_DEBT:
      return { ...state, ...action.payload };
    default:
      return state;
  }
};