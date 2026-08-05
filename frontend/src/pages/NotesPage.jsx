import { useNavigate } from 'react-router-dom'

const NotesPage = () => {
    const navigate = useNavigate()
    const token = localStorage.getItem("token")

    const handleLogout = () => {
        localStorage.removeItem("token")
        navigate("/login")
    }

    return (
        <>
            <h2>Notlarım</h2>
            <p>Giriş başarılı. Token kaydedildi.</p>
            <pre style={{ whiteSpace: 'pre-wrap', wordBreak: 'break-all' }}>{token}</pre>
            <button onClick={handleLogout}>Çıkış Yap</button>
        </>
    )
}

export default NotesPage
