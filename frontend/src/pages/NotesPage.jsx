import { useEffect, useState } from 'react'
import { fetchNotes } from '../services/noteService'
import { Link } from 'react-router-dom'

const NotesPage = () => {
    const [notes, setNotes] = useState([])
    const [loading, setLoading] = useState(true)

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

    return (
        <>
            <Link to={"/add-note"}>
                <button>Yeni Not Ekle</button>
            </Link>

            {loading ? <p>Yukleniyor...</p> : (
                <ul>
                    {
                        notes.map((note) => (
                            <li key={note.id}>{note.title}----{note.content}</li>
                        ))
                    }
                </ul>
            )}
        </>
    )
}

export default NotesPage
