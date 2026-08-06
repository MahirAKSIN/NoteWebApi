import Cookies from "js-cookie"
import { Navigate } from 'react-router-dom'

const PrivateRoute = ({ children }) => {
    const token = Cookies.get("access_token");
    return token ? children : <Navigate to="/login" replace />
}

export default PrivateRoute
