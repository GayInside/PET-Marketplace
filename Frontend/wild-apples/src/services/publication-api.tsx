import axios from "axios";
import IPublicationPagination from "../models/IPublicationPagination";
import IPublicationMaximized from "../models/IPublicationMaximized";
import Cookies from "js-cookie";
import ICreatePublication from "../models/ICreatePublication";

const BASE_URL = 'http://localhost:5254/api/';

const GetAllPublications = async (pageNumber: string = "1") : Promise<IPublicationPagination> => {

    const url = `${BASE_URL}Publication/GetAllPublications?pageNumber=${pageNumber}`;
    const response = await axios.get<IPublicationPagination>(url);
    return response.data;
}

const GetPublicationProfile = async (id: string) : Promise<IPublicationMaximized> => {
    const url = `${BASE_URL}Publication/GetPublication?id=${id}`;
    const authToken = Cookies.get('.AspNetCore.Cookies');
    const response = await axios.get<IPublicationMaximized>(url,{
        headers: {
            'Content-Type': 'application/json',
            'Cookie': authToken,
          }
    });
    return response.data;
}

const CreatePublication = async (model: ICreatePublication)=>{
    const url = `${BASE_URL}Publication/CreatePublication`;
    const authToken = Cookies.get('.AspNetCore.Cookies');
    const {title, description, subcategoriesId} = model;
    const response = await axios.post<IPublicationMaximized>(url, model,{
        headers: {
            'Content-Type': 'application/json',
            'Cookie': authToken,
          }
    });
    return response.data;
}

const DeletePublication = async (id: string) => {
    const url = `${BASE_URL}Publication/DeletePublication`;
    const authToken = Cookies.get('.AspNetCore.Cookies');
  
    const response = await axios.delete(url, {
      data: {
        id: id,
      },
      headers: {
        'Content-Type': 'application/json',
        'Cookie': authToken,
      }
    });
  
    return response.data;
  };

const PublicationApi = {
    GetAllPublications,
    GetPublicationProfile,
    DeletePublication,
    CreatePublication
}

export default PublicationApi;