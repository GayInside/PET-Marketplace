import React, { useState } from 'react';
import axios from 'axios';
import Cookies from 'js-cookie';
import IUserCredentials from '../models/IUserCredentials';
import AccountApi from '../services/account-api';

const LoginPage = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const { Login } = AccountApi;

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      await Login({ username, password });
      // После успешной авторизации, токен будет помещен в cookie .AspNetCore.Cookies
      // Поэтому мы можем сразу перенаправить пользователя на защищенную страницу
      window.location.href = '/publications/1';
    } catch (error) {
      console.error('Error logging in:', error);
      // Отображаем сообщение об ошибке
      alert('Неправильное имя пользователя или пароль');
    }
  };

  const checkAuth = () => {
    // Проверяем наличие токена в cookie .AspNetCore.Cookies
    const authToken = Cookies.get('.AspNetCore.Cookies');
    if (authToken) {
      // Если токен есть, перенаправляем пользователя на защищенную страницу
      window.location.href = '/publications/1';
    }
  };

  React.useEffect(() => {
    checkAuth();
  }, []);

  return (
    <div>
      <h1>Страница авторизации</h1>
      <form onSubmit={handleLogin}>
        <label>
          Имя пользователя:
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </label>
        <br />
        <label>
          Пароль:
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </label>
        <br />
        <button type="submit">Войти</button>
      </form>
    </div>
  );
};

export default LoginPage;