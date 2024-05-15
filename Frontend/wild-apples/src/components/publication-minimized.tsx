import { FC } from "react";
import IPublicationMinimized from "../models/IPublicationMinimized";
import { Link } from "react-router-dom";
import "./publication-minimized.css";

interface PublicationProps{
    publication: IPublicationMinimized
}

const PublicationMinimized: FC<PublicationProps> = ({publication}) => {
    
    return(
        <div className="publication-minimized">
  <Link to={`/publications/publication/${publication.id}`}>
    <div className="publication-id">{publication.id}</div>
    <div className="publication-title">{publication.title}</div>
  </Link>
</div>

    );
}

export default PublicationMinimized;