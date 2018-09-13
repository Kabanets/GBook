using System.Collections.Generic;

namespace GBook.Models
{
    public class RecordsListViewModel
    {
        public IEnumerable<Record> Records { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public SortingInfo SortingInfo { get; set; }
    }
}