using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsDealerApi.Dtos.Pagination
{
    public class PaginationDto<T>
    {
        public T? Items { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}