using System;
using System.Collections.Generic;

namespace HentaiSite.Models.ViewModels
{
    public class IndexViewModel : BasicViewModel
    {
        public List<Post> posts;
        public string queryString;
        public string queryStringWithoutPage;
        public int page;
        public int totalPages;

        public bool HasPreviousPage()
        {
            return page > 1;
        }

        public bool HasNextPage()
        {
            return page < totalPages;
        }
    }
}
