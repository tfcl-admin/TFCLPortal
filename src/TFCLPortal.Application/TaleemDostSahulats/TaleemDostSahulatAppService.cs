using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaleemDostSahulats.Dto;

namespace TFCLPortal.TaleemDostSahulats
{
    public class TaleemDostSahulatAppService : TFCLPortalAppServiceBase, ITaleemDostSahulatAppService
    {
        private readonly IRepository<TaleemDostSahulat, Int32> _TaleemDostSahulatRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        public TaleemDostSahulatAppService(IRepository<TaleemDostSahulat, Int32> TaleemDostSahulatRepository,
            IRepository<Applicationz, Int32> applicationRepository)
        {
            _TaleemDostSahulatRepository = TaleemDostSahulatRepository;
            _applicationRepository = applicationRepository;
        }

        public void CreateTaleemDostSahulat(CreateTaleemDostSahulatDto input)
        {
            try
            {
                var tsa = ObjectMapper.Map<TaleemDostSahulat>(input);
                 _TaleemDostSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
        }

        public int CreateTaleemDostSahulatAndReturnApplicationNumber(CreateTaleemDostSahulatDto input)
        {
            int AppNumber = 0;
            try
            {
                var tsa = ObjectMapper.Map<TaleemDostSahulat>(input);

                var lastId = _TaleemDostSahulatRepository.GetAllList().LastOrDefault();

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


                _TaleemDostSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
            return AppNumber;
        }

        public async Task<TaleemDostSahulatListDto> GetTaleemDostSahulatById(int Id)
        {
            try
            {
                var tsa = await   _TaleemDostSahulatRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemDostSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }

        public  TaleemDostSahulatListDto GetTaleemDostSahulatByApplicationId(int Id)
        {
            try
            {
                var tsa = _TaleemDostSahulatRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemDostSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }


        public async Task<string> UpdateTaleemDostSahulat(UpdateTaleemDostSahulatDto input)
        {
            string ResponseString = "";
            try
            {
                var tsa = _TaleemDostSahulatRepository.Get(input.Id);
                if (tsa != null && tsa.Id > 0)
                {
                    ObjectMapper.Map(input, tsa);
                    await _TaleemDostSahulatRepository.UpdateAsync(tsa);
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
