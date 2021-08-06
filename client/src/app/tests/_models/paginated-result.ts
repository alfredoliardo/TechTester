export interface PaginatedResult<T> {
    currentPage:number;
    pageSize:number;
    totalPages:number;
    totalItems:number;
    data:T[];
}
