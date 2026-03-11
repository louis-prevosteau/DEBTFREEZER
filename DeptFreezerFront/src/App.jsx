import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { Navigate, Route, Routes } from 'react-router-dom'
import Authentication from './pages/authentication'
import Debts from './pages/debts'
import Navbar from './components/navbar'

function PrivateRoute({ children }) {
  const token = localStorage.getItem("token");

  return token ? children : <Navigate to="/auth" replace />;
}

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Navbar />
      <Routes>
        <Route
          path="/"
          element={
            <PrivateRoute>
              <Debts />
            </PrivateRoute>
          }
        />
        <Route path='auth' element={<Authentication />} />
      </Routes>
    </>
  )
}

export default App
