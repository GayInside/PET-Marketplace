import IPublicationMinimized from "./IPublicationMinimized";

interface IPublicationPagination{
    pageNumber: number,
    totalPages: number,
    hasPreviousPage: boolean,
    hasNextPage: boolean,
    items: IPublicationMinimized[]
}

export default IPublicationPagination;