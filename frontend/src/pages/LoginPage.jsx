import axios from 'axios'
import React, { useEffect, useState } from 'react'
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
         console.log(username, password);
       // localStorage.setItem("token", res.data.token)
       Cookies.set("acces_token",res.data.token,{expires:7});
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
        <>
            <h2>Giriş Yap</h2>
            {error&& <p style={{color:'red'}}>{error}</p>}
            <form onSubmit={handleSumbit}>
                <input type="text" placeholder='Kullanıcı Adı' value={username} onChange={(e) => setUsername(e.target.value)} />
                <input type="password" placeholder='Kullanıcı Sifresi' value={password} onChange={(e) => setPassword(e.target.value)} />
                <button type='submit'>Giris Yap</button>
            </form>
        </>
    )
}

export default LoginPage