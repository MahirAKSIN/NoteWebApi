import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { fetchNoteById, updateNote } from '../services/noteService'

const EditNotePage = () => {
    const [title, setTitle] = useState("")
    const [content, setContent] = useState("")
    const { id } = useParams()
    const navigate = useNavigate()

    useEffect(() => {
        const loadNote = async () => {
            try {
                const res = await fetchNoteById(id)
                const note = res.data
                if (note) {
                    setTitle(note.title)
                    setContent(note.content)
                }
            } catch (error) {
                console.error("Not yuklenirken hata", error)
            }
        }
        loadNote()
    }, [id])

    const editHandle = async () => {
        try {
            await updateNote(id, { title, content })
            navigate("/notes")
        } catch (error) {
            console.error("Not guncellenirken hata", error)
        }
    }

    return (
        <div className="page">
            <div className="card card-form">
                <h2 className="page-title">Not Güncelle</h2>
                <p className="page-subtitle">Başlık ve içeriği düzenle.</p>
                <div className="field">
                    <label htmlFor="title">Başlık</label>
                    <input
                        id="title"
                        type="text"
                        placeholder="Not başlığı"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                    />
                </div>
                <div className="field">
                    <label htmlFor="content">İçerik</label>
                    <textarea
                        id="content"
                        placeholder="Not içeriği"
                        value={content}
                        onChange={(e) => setContent(e.target.value)}
                    />
                </div>
                <div className="form-actions">
                    <button className="btn btn-primary" type="button" onClick={editHandle}>Not Güncelle</button>
                    <button className="btn btn-secondary" type="button" onClick={() => navigate("/notes")}>Geri</button>
                </div>
            </div>
        </div>
    )
}

export default EditNotePage
