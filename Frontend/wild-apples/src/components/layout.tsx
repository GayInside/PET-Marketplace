import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Publications from "./publications";
import AddPublication from "./add-publication";
import Publication from "./publication";
import LoginPage from "./login-page";

function Layout(){
    return(
      <BrowserRouter>
      <div>
        <Link to="">WildApples </Link>
        <Link to="publications/1">Publications</Link>
      </div>
        <Routes>
            <Route index element={<LoginPage/>}></Route>

          <Route path="publications">
            <Route path=":page-number" element={<Publications/>}/>
            <Route path="publication/:id" element={<Publication/>}></Route>
            <Route path="add-publication" element={<AddPublication/>}></Route>
          </Route>

          <Route path="*" element={<div>Нет так страницы</div>}/>
        </Routes>
      </BrowserRouter>
    );
}

export default Layout;