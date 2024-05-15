import { useEffect, useState } from "react";
import IPublicationMinimized from "../models/IPublicationMinimized";
import { error } from "console";
import { Link, useParams } from "react-router-dom";
import PublicationApi from "../services/publication-api";
import IPublicationPagination from "../models/IPublicationPagination";
import PublicationMinimized from "./publication-minimized";

const Publications = () => {
    const {pageNumber} = useParams();
    const {GetAllPublications} = PublicationApi;
    const [publications, setPublications] = useState<IPublicationPagination>(

    );

    useEffect(() => {
        GetAllPublications(pageNumber)
            .then(response => {
                setPublications(response as IPublicationPagination)
            })
    }, []);


    return (
      <div className="Publications">
        <Link to="add-publication">Создать публикацию</Link>
        {publications?.items.map(item => (
				<PublicationMinimized publication={item}></PublicationMinimized>	
				))}

      </div>
    );
  }
  
  export default Publications;