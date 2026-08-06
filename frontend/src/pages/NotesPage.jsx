import { useEffect, useState } from 'react'
import { deleteNote, fetchNotes } from '../services/noteService'
import { Link, useNavigate } from 'react-router-dom'

const NotesPage = () => {
    const [notes, setNotes] = useState([])
    const [loading, setLoading] = useState(true)
    const navigate = useNavigate();

    useEffect(() => {
        loadNotes();
    }, [])

    const loadNotes = async () => {
        try {
            setLoading(true);
            const res = await fetchNotes();
            setNotes(res.data)
        } catch (error) {
            console.error("Notlar yuklenirken bir hata meydana geldi", error);
        } finally {
            setLoading(false)
        }
    }

    const deleteHandle = async (id) => {
        if (!id) return;
        await deleteNote(id)
        setNotes(prev => prev.filter(q => q.id !== id))
    }

    const editHandle = (id) => {
        navigate(`/edit-note/${id}`)
    }

    const detailHandle = (id) => {
        navigate(`/note/${id}`)
    }

    return (
        <div className="page">
            <div className="page-header">
                <div>
                    <h1 className="page-title">Notlarım</h1>
                </div>
                <Link to="/add-note">
                    <button className="btn btn-primary" type="button">Yeni Not Ekle</button>
                </Link>
            </div>

            {loading ? (
                <p className="status-text">Yükleniyor...</p>
            ) : notes.length === 0 ? (
                <p className="status-text">Henüz not yok. Yeni bir not ekleyebilirsin.</p>
            ) : (
                <ul className="notes-grid">
                    {notes.map((note) => (
                        <li key={note.id} className="card note-card">
                            <h3 className="note-card-title">{note.title}</h3>
                            <p className="note-card-content">{note.content}</p>
                            <div className="note-card-actions">
                                <button className="btn btn-secondary" type="button" onClick={() => detailHandle(note.id)}>Detay</button>
                                <button className="btn btn-secondary" type="button" onClick={() => editHandle(note.id)}>Güncelle</button>
                                <button className="btn btn-danger" type="button" onClick={() => deleteHandle(note.id)}>Sil</button>
                            </div>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    )
}

export default NotesPage
