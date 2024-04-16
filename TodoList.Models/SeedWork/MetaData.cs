using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models.SeedWork
{
    public class MetaData
    {
        public int CurentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious =>CurentPage > 1;
        public bool HasNext =>CurentPage < TotalPages;
    }
}
