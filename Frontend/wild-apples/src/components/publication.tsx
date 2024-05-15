import exp from "constants";
import { useParams } from "react-router-dom";
import PublicationApi from "../services/publication-api";
import IPublicationMaximized from "../models/IPublicationMaximized";
import { useState, useEffect } from "react";
import IPublicationPagination from "../models/IPublicationPagination";
import "./publication.css";

function Publication() {
  const { id } = useParams();
  const { GetPublicationProfile, DeletePublication } = PublicationApi;
  const [publication, setPublication] = useState<IPublicationMaximized>();
  const [showDetails, setShowDetails] = useState<boolean>(publication?.canChange ?? false);

  console.log(publication?.canChange);

  const handleDelete = () => {
    DeletePublication(String(id));
  };

  useEffect(() => {
    GetPublicationProfile(String(id)).then((response) => {
      setPublication(response as IPublicationMaximized);
      setShowDetails(response?.canChange ?? false);
    });
  }, []);

  return (
    <div className="Publication">
  <div>Информация о публикации {publication?.id}, владелец {publication?.ownerId}</div>
  <div className="publication-title">{publication?.title}</div>
  <div className="publication-description">{publication?.description}</div>
  {showDetails && (
    <button onClick={handleDelete}>Delete Publication</button>
  )}
</div>
  );
}

export default Publication;