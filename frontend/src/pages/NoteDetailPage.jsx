import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { fetchNoteById } from '../services/noteService'

const NoteDetailPage = () => {
    const [note, setNote] = useState(null)
    const [loading, setLoading] = useState(true)
    const { id } = useParams()
    const navigate = useNavigate()

    useEffect(() => {
        const loadNote = async () => {
            setLoading(true);
            try {
                const res = await fetchNoteById(id)
                setNote(res.data);
            } catch (error) {
                console.error("Not getirilemedi,", error);
            } finally {
                setLoading(false)
            }
        }
        loadNote();
    }, [id])

    if (loading) {
        return (
            <div className="page">
                <p className="status-text">Yükleniyor...</p>
            </div>
        )
    }

    if (!note) {
        return (
            <div className="page">
                <p className="status-text">Not bulunamadı</p>
            </div>
        )
    }

    return (
        <div className="page">
            <article className="card card-form">
                <h2 className="page-title">Not Detayı</h2>
                <div className="field">
                    <label>Başlık</label>
                    <h3 className="note-card-title">{note.title}</h3>
                </div>
                <div className="field">
                    <label>İçerik</label>
                    <p className="note-card-content" style={{ WebkitLineClamp: "unset", display: "block" }}>
                        {note.content}
                    </p>
                </div>
                {note.createdAt && (
                    <p className="note-card-meta">
                        Kayıt tarihi: {new Date(note.createdAt).toLocaleString("tr-TR")}
                    </p>
                )}
                <div className="form-actions">
                    <button className="btn btn-secondary" type="button" onClick={() => navigate("/notes")}>Geri</button>
                    <button className="btn btn-primary" type="button" onClick={() => navigate(`/edit-note/${id}`)}>Güncelle</button>
                </div>
            </article>
        </div>
    )
}

export default NoteDetailPage
