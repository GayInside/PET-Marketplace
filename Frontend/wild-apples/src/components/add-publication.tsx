import { useState } from "react";
import ICreatePublication from "../models/ICreatePublication";
import PublicationApi from "../services/publication-api";
import './add-publication.css';

function AddPublication(){
    const [title, setTitle] = useState<string>('');
    const [description, setDescription] = useState<string>('');
    const [subcategoriesId, setSubcategories] = useState<number[]>([]);
    const {CreatePublication} = PublicationApi;

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
    
        try {
          const model: ICreatePublication = {
            title,
            description,
            subcategoriesId,
          };
    
          const response = await CreatePublication(model);
          console.log('Created publication:', response);
    
          window.location.href = '/publications/1';
          // Reset the form fields
          setTitle('');
          setDescription('');
          setSubcategories([]);
        } catch (error) {
          console.error('Error creating publication:', error);
        }
      };

      return (
        <form onSubmit={handleSubmit} className="publication-form">
          <div>
            <label htmlFor="title">Title:</label>
            <input
              type="text"
              id="title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              required
            />
          </div>
          <div>
            <label htmlFor="description">Description:</label>
            <textarea
              id="description"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            ></textarea>
          </div>
          <div>
            <label htmlFor="subcategories">Subcategories:</label>
            <input
              type="text"
              id="subcategories"
              value={subcategoriesId.join(', ')}
              onChange={(e) => {
                const values = e.target.value.split(',').map((id) => parseInt(id.trim()));
                setSubcategories(values);
              }}
              required
            />
          </div>
          <button type="submit">Create Publication</button>
        </form>
      );
}

export default AddPublication;