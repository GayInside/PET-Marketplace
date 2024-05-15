import { FC } from "react";
import IPublicationMinimized from "../models/IPublicationMinimized";
import { Link } from "react-router-dom";

interface PublicationProps{
    publication: IPublicationMinimized
}

const PublicationMinimized: FC<PublicationProps> = ({publication}) => {
    
    return(
        <div className="publication-minimized">
        <Link to={`/publications/publication/${publication.id}`}>
            <div>
                {publication.id}
                {publication.title}
            </div>  
        </Link>         
        </div>

    );
}

export default PublicationMinimized;