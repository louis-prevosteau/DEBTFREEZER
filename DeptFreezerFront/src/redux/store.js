import { configureStore } from "@reduxjs/toolkit";
import { DebtReducer, DebtsReducer } from "./reducers/DebtReducer";
import { PaymentsReducer } from "./reducers/paymentReducer";
import { ChallengeReducer, ChallengesReducer } from "./reducers/challengeReducer";
import { AuthReducer } from "./reducers/authReducer";

export default configureStore({
  reducer: {
    auth: AuthReducer,
    debts: DebtsReducer,
    debt: DebtReducer,
    payments: PaymentsReducer,
    challenges: ChallengesReducer,
    challenge: ChallengeReducer
  },
});