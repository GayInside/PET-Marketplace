import axios from "axios";
import IPublicationPagination from "../models/IPublicationPagination";
import IPublicationMaximized from "../models/IPublicationMaximized";

const BASE_URL = 'http://localhost:5254/api/';

const GetAllPublications = async (pageNumber: string = "1") : Promise<IPublicationPagination> => {

    const url = `${BASE_URL}Publication/GetAllPublications?pageNumber=${pageNumber}`;
    const response = await axios.get<IPublicationPagination>(url);
    return response.data;
}

const GetPublicationProfile = async (id: string) : Promise<IPublicationMaximized> => {
    const url = `${BASE_URL}Publication/GetPublication?id=${id}`;
    const response = await axios.get<IPublicationMaximized>(url);
    return response.data;
}

const PublicationApi = {
    GetAllPublications,
    GetPublicationProfile
}

export default PublicationApi;