import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { createNote } from '../services/noteService'




const AddNotePage = () => {
    const [title, setTitle] = useState([])
    const [content, setContent] = useState([])
   
    const navigate = useNavigate();

    const handleAdd = async () => {
        if (!title.trim) return;
        await createNote({ title, content })
        navigate("/notes");
    }

    return (
        <>
            <h2>Yeni Not Ekleme</h2>
            <input type="text" placeholder='Not Başlık' value={title} onChange={(e) => setTitle(e.target.value)} />
            <input type="text" placeholder='Not Icerik' value={content} onChange={(e) => setContent(e.target.value)} />
            <button onClick={handleAdd}>Not Ekle</button>
        </>
    )
}

export default AddNotePage