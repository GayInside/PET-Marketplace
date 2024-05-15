import axios from "axios";
import IUserCredentials from "../models/IUserCredentials";
import Cookies from "js-cookie";
import IRegistration from "../models/IRegistration";

const BASE_URL = 'http://localhost:5254/api/';
axios.defaults.withCredentials = true;

const Register = async (credentials : IRegistration) => {
    const url = `${BASE_URL}Account/Register`;
    const { username, password, firstname, surname } = credentials;

    const response = await axios.post(url, { username, password, firstname, surname });
    return response.data;
}

const Login = async (credentials : IUserCredentials) => {

    const url = `${BASE_URL}Account/Login`;
    const { username, password } = credentials;

    try {
        const response = await axios.post(url, { username, password });
  
        // Извлекаем cookie из заголовков ответа
        const authCookie = response.headers['set-cookie'];
  
        if (authCookie && !Array.isArray(authCookie)) {
          // Сохраняем cookie в браузере
          document.cookie = authCookie;
          console.log('Auth cookie stored:', authCookie);
        } else {
          console.log('Auth cookie not found in headers');
        }
  
        return response;
      } catch (error) {
        console.error('Login error:', error);
        throw error;
      }
}

const AccountApi = {
    Login,
    Register
}

export default AccountApi;