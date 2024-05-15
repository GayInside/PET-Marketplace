import axios from "axios";
import IUserCredentials from "../models/IUserCredentials";

const BASE_URL = 'http://localhost:5254/api/';

const Login = async (credentials : IUserCredentials) => {

    const url = `${BASE_URL}Account/Login`;
    const username = credentials.username;
    const password = credentials.password;
    const response = await axios.post(url, {username, password});
    return response.data;
}

const AccountApi = {
    Login
}

export default AccountApi;