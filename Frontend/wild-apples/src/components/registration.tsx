import { useState } from "react";
import ICreatePublication from "../models/ICreatePublication";
import AccountApi from "../services/account-api";
import IRegistration from "../models/IRegistration";
import "./registration.css"

function RegistrationPage(){
    const [username, setName] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [firstname, setFirstname] = useState<string>('');
    const [surname, setSurname] = useState<string>('');
    const {Register} = AccountApi;

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
    
        try {
          const model: IRegistration = {
            username,
            password,
            firstname,
            surname
          };
    
          const response = await Register(model);
          console.log('Created user:', response);
    
          window.location.href = '/';
          // Reset the form fields
          setName('');
          setPassword('');
          setFirstname('');
          setSurname('');
        } catch (error) {
            alert("Something wrong with your data");
          console.error('Error creating user:', error);
        }
      };

      return (
        <form onSubmit={handleSubmit}>
  <label>
    <span>Username:</span>
    <input type="text" value={username} onChange={(e) => setName(e.target.value)} />
  </label>
  <label>
    <span>Password:</span>
    <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
  </label>
  <label>
    <span>Firstname:</span>
    <input type="text" value={firstname} onChange={(e) => setFirstname(e.target.value)} />
  </label>
  <label>
    <span>Surname:</span>
    <input type="text" value={surname} onChange={(e) => setSurname(e.target.value)} />
  </label>
  <button type="submit">Register</button>
</form>
      );
}

export default RegistrationPage;