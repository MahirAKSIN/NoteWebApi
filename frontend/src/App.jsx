import { BrowserRouter, Routes, Route } from "react-router-dom"
import LoginPage from "./pages/LoginPage"
import NotesPage from "./pages/NotesPage"
import PrivateRoute from "./components/PrivateRoute"


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route  path="/notes" element={
          <PrivateRoute>
            <NotesPage/>
          </PrivateRoute>
        }/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
