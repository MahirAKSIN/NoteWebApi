import { BrowserRouter, Routes, Route } from "react-router-dom"
import LoginPage from "./pages/LoginPage"
import NotesPage from "./pages/NotesPage"
import PrivateRoute from "./components/PrivateRoute"
import AddNotePage from "./pages/AddNotePage"


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
            <Route  path="/add-note" element={
          <PrivateRoute>
            <AddNotePage/>
          </PrivateRoute>
        }/>
      </Routes>
    </BrowserRouter>
  )
}

export default App
