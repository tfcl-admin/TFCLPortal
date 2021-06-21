using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFCLPortal.Mobilizations;
using TFCLPortal.Mobilizations.Dto;

namespace TFCLPortal.Web.Models.MobilizationSearch
{
    public class MobilizationSearch
    {
        public int SDEUserId { get; set; }
        public int ProductId { get; set; }
        public int MobilizationStatusId { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string nextmeeting { get; set; }
    }

    public class ApplicationSearch
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class MobilizationSearchViewModel
    {
        public MobilizationSearchViewModel()
        {
            mobilizationSearch = new MobilizationSearch();
        }
        public MobilizationSearch mobilizationSearch { get; set; }
        public List<GetMobilizationListDto> MobilizationList { get; set; }
        public Pager Pager { get; set; }

    }

    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}

