import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { createNote } from '../services/noteService'

const AddNotePage = () => {
    const [title, setTitle] = useState("")
    const [content, setContent] = useState("")
    const navigate = useNavigate();

    const handleAdd = async () => {
        if (!title.trim()) return;
        await createNote({ title, content })
        navigate("/notes");
    }

    return (
        <div className="page">
            <div className="card card-form">
                <h2 className="page-title">Yeni Not</h2>
                <p className="page-subtitle">Başlık ve içeriği girerek notunu kaydet.</p>
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
                    <button className="btn btn-primary" type="button" onClick={handleAdd}>Not Ekle</button>
                    <button className="btn btn-secondary" type="button" onClick={() => navigate("/notes")}>Geri</button>
                </div>
            </div>
        </div>
    )
}

export default AddNotePage
