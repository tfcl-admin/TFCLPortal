using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaleemJariSahulats.Dto;

namespace TFCLPortal.TaleemJariSahulats
{
    public class TaleemJariSahulatAppService : TFCLPortalAppServiceBase, ITaleemJariSahulatAppService
    {
        private readonly IRepository<TaleemJariSahulat, Int32> _TaleemJariSahulatRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        public TaleemJariSahulatAppService(IRepository<TaleemJariSahulat, Int32> TaleemJariSahulatRepository,
            IRepository<Applicationz, Int32> applicationRepository)
        {
            _TaleemJariSahulatRepository = TaleemJariSahulatRepository;
            _applicationRepository = applicationRepository;
        }

        public void CreateTaleemJariSahulat(CreateTaleemJariSahulatDto input)
        {
            try
            {
                var tsa = ObjectMapper.Map<TaleemJariSahulat>(input);
                 _TaleemJariSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
        }

        public int CreateTaleemJariSahulatAndReturnApplicationNumber(CreateTaleemJariSahulatDto input)
        {
            int AppNumber = 0;
            try
            {
                var tsa = ObjectMapper.Map<TaleemJariSahulat>(input);

                var lastId = _TaleemJariSahulatRepository.GetAllList().LastOrDefault();

                if(lastId!=null)
                {
                    if (lastId.ApplicationNumber>0)
                    {
                        AppNumber = lastId.ApplicationNumber + 1;
                        tsa.ApplicationNumber = AppNumber;
                    }
                    else
                    {
                        AppNumber = 0;
                    }
                }
                else
                {
                    AppNumber = 1;
                    tsa.ApplicationNumber = AppNumber;
                }


                _TaleemJariSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
            return AppNumber;
        }

        public async Task<TaleemJariSahulatListDto> GetTaleemJariSahulatById(int Id)
        {
            try
            {
                var tsa = await   _TaleemJariSahulatRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemJariSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }

        public  TaleemJariSahulatListDto GetTaleemJariSahulatByApplicationId(int Id)
        {
            try
            {
                var tsa = _TaleemJariSahulatRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemJariSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }


        public async Task<string> UpdateTaleemJariSahulat(UpdateTaleemJariSahulatDto input)
        {
            string ResponseString = "";
            try
            {
                var tsa = _TaleemJariSahulatRepository.Get(input.Id);
                if (tsa != null && tsa.Id > 0)
                {
                    ObjectMapper.Map(input, tsa);
                    await _TaleemJariSahulatRepository.UpdateAsync(tsa);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "Taleem School Asasah"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Taleem School Asasah"));
            }
        }
    }
}
