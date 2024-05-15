import exp from "constants";
import { useParams } from "react-router-dom";
import PublicationApi from "../services/publication-api";
import IPublicationMaximized from "../models/IPublicationMaximized";
import { useState, useEffect } from "react";
import IPublicationPagination from "../models/IPublicationPagination";

function Publication()
{
    const {id} = useParams();
    const {GetPublicationProfile} = PublicationApi;
    const [publication, setPublication] = useState<IPublicationMaximized>(

    );

    useEffect(() => {
        GetPublicationProfile(String(id))
            .then(response => {
                setPublication(response as IPublicationMaximized)
            })
    }, []);


    return(
        <div className="Publication">
            <div>Информация о публикации {publication?.id}, владелец {publication?.ownerId}</div>
            <div className="publication-title">{publication?.title}</div>
            <div className="publication-description">{publication?.description}</div>
            {/* {publication?.subcategoryTitle.map(item => (
                <div className="subcategories">{item}</div>
            ))} */}

        </div>
    );
}

export default Publication;