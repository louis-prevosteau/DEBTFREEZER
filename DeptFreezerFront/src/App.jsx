import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { Route, Routes } from 'react-router-dom'
import Authentication from './pages/authentication'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Routes>
        <Route path='auth' element={<Authentication />} />
      </Routes>
    </>
  )
}

export default App
