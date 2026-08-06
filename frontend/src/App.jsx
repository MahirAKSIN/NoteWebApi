import { BrowserRouter, Routes, Route } from "react-router-dom"
import LoginPage from "./pages/LoginPage"
import NotesPage from "./pages/NotesPage"
import PrivateRoute from "./components/PrivateRoute"
import AddNotePage from "./pages/AddNotePage"
import EditNotePage from "./pages/EditNotePage"
import NoteDetailPage from "./pages/NoteDetailPage"
import Layout from "./components/Layout"

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/notes" element={
            <PrivateRoute>
              <NotesPage />
            </PrivateRoute>
          } />
          <Route path="/add-note" element={
            <PrivateRoute>
              <AddNotePage />
            </PrivateRoute>
          } />
          <Route path="/edit-note/:id" element={
            <PrivateRoute>
              <EditNotePage />
            </PrivateRoute>
          } />
          <Route path="/note/:id" element={
            <PrivateRoute>
              <NoteDetailPage />
            </PrivateRoute>
          } />
        </Routes>
      </Layout>
    </BrowserRouter>
  )
}

export default App
