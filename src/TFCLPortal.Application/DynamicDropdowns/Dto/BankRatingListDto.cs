using Abp.AutoMapper;
using Abp.Domain.Entities;
using TFCLPortal.Banks;
using TFCLPortal.DynamicDropdowns.BankRatings;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapFrom(typeof(BankRating))]
    public class BankRatingListDto : Entity
    {
        public string Name { get; set; }
        //public string AllowedLTV { get; set; }

    }
}
