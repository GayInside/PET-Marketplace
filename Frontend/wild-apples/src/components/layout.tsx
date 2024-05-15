import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Publications from "./publications";
import AddPublication from "./add-publication";
import Publication from "./publication";
import LoginPage from "./login-page";
import RegistrationPage from "./registration";
import "./layout.css";

function Layout(){
  return (
    <BrowserRouter>
      <div className="navigation">
        <Link to="">WildApples</Link>
        <Link to="publications/1">Публикации</Link>
        <Link to="publications/add-publication">Создать публикацию</Link>
      </div>
      <div className="page-container">
        <Routes>
          <Route index element={<LoginPage />}></Route>
          <Route path="registration" element={<RegistrationPage />}></Route>
  
          <Route path="publications">
            <Route path="add-publication" element={<AddPublication />}></Route>
            <Route path=":page-number" element={<Publications />} />
            <Route path="publication/:id" element={<Publication />}></Route>
          </Route>
  
          <Route path="*" element={<div className="error-page">
            <h1>404</h1>
            <p>Нет такой страницы</p>
          </div>} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default Layout;