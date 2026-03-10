import axios from 'axios';

const api = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
  headers: {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`,
  },
});

export const register = (data) => api.post('/auth/register', data);
export const login = (data) => api.post('/auth/login', data);

export const getDebts = () => api.get('/debts');
export const getDebt = (id) => api.get(`/debts/${id}`);
export const createDebt = (data) => api.post('/debts', data);
export const updateDebt = (id, data) => api.put(`/debts/${id}`, data);
export const deleteDebt = (id) => api.delete(`/debts/${id}`);

export const getPayments = (debtId) => api.get(`/debts/${debtId}/payments`);
export const createPayment = (debtId, data) => api.post(`/debts/${debtId}/payments`, data);

export const getChallenges = () => api.get('/challenges');
export const getChallenge = (id) => api.get(`/challenges/${id}`);
export const createChallenge = (data) => api.post('/challenges', data);
export const joinChallenge = (id) => api.post(`/challenges/${id}/join`);