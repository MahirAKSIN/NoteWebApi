import axios from 'axios'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import Cookies from "js-cookie"

const LoginPage = () => {
    const [username, setUsername] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState(null)

    const navigate = useNavigate();

    const handleSumbit = async (e) => {
        e.preventDefault();

        try {
            const res = await axios.post("https://localhost:7192/api/auth/login", {
                username: username.trim(), password
            });

            Cookies.set("access_token", res.data.token, { expires: 7 });
            navigate("/notes")
        } catch (err) {
            const data = err.response?.data;
            setError(
                Array.isArray(data) ? data.join(", ")
                    : typeof data === "string" ? data
                        : err.message
            );
        }
    }

    return (
        <div className="page">
            <form className="card card-form" onSubmit={handleSumbit}>
                <h2 className="page-title">Giriş Yap</h2>
                <p className="page-subtitle">Notlarına erişmek için hesabınla giriş yap.</p>
                {error && <p className="error-text">{error}</p>}
                <div className="field">
                    <label htmlFor="username">Kullanıcı Adı</label>
                    <input
                        id="username"
                        type="text"
                        placeholder="Kullanıcı Adı"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div className="field">
                    <label htmlFor="password">Şifre</label>
                    <input
                        id="password"
                        type="password"
                        placeholder="Şifre"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button className="btn btn-primary btn-block" type="submit">Giriş Yap</button>
            </form>
        </div>
    )
}

export default LoginPage
