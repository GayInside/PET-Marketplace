import { useEffect, useState } from "react";
import IPublicationMinimized from "../models/IPublicationMinimized";
import { error } from "console";
import { Link, useParams } from "react-router-dom";
import PublicationApi from "../services/publication-api";
import IPublicationPagination from "../models/IPublicationPagination";
import PublicationMinimized from "./publication-minimized";
import "./publications.css";

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
  {publications?.items.map(item => (
    <div className="PublicationMinimized">
      <a href={`/publications/publication/${item.id}`}>
        <div className="publication-id">{item.id}</div>
        <div className="publication-title">{item.title}</div>
      </a>
    </div>
  ))}
</div>
    );
  }
  
  export default Publications;