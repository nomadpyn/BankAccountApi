using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BankAccountApi.Models
{
    public class PageParameters
    {
        private const int maxPageSize = 100;
        private int pageSize = 25;
        private int pageNumber = 1;
        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                pageNumber = (value <= 0) ? 1 : value;
            }
        }
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
