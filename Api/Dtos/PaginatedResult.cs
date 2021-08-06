using System.Collections.Generic;

namespace Api.Dtos
{
    public class PaginatedResult<T> where T : class
    {
        public int TotalItems {get;set;}
        public int CurrentPage {get;set;}
        public int PageSize {get;set;}
        public int TotalPages {get;set;}
        public IReadOnlyList<T> Data {get;set;}
    }
}