import axios from "axios";
import Cookies from "js-cookie";

const API_URL = "https://localhost:7192/api/notes";

const getAuthHeader = () => {
    const token = Cookies.get("access_token");
    return { Authorization: `Bearer ${token}` }
}

export const fetchNotes = () => {
    return axios.get(API_URL, { headers: getAuthHeader() })
}

export const createNote = (note) => {
    return axios.post(API_URL, note, { headers: getAuthHeader() })
}

export const fetchNoteById = (id) => {
    return axios.get(`${API_URL}/${id}`, { headers: getAuthHeader() })
}

export const updateNote = (id, note) => {
    return axios.put(`${API_URL}/${id}`, note, { headers: getAuthHeader() })
}

export const deleteNote = (id) => {
    return axios.delete(`${API_URL}/${id}`, { headers: getAuthHeader() })
}
