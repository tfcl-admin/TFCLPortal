using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFCLPortal.Web.Models.Search
{
    public class SearchModel
    {
        [Required]
        public string SearchQuery { get; set; }

        [Required]
        public string SearchType { get; set; }

    }
}
