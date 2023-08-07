using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaleemFeeSahulats.Dto;

namespace TFCLPortal.TaleemFeeSahulats
{
    public class TaleemFeeSahulatAppService : TFCLPortalAppServiceBase, ITaleemFeeSahulatAppService
    {
        private readonly IRepository<TaleemFeeSahulat, Int32> _TaleemFeeSahulatRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        public TaleemFeeSahulatAppService(IRepository<TaleemFeeSahulat, Int32> TaleemFeeSahulatRepository,
            IRepository<Applicationz, Int32> applicationRepository)
        {
            _TaleemFeeSahulatRepository = TaleemFeeSahulatRepository;
            _applicationRepository = applicationRepository;
        }

        public void CreateTaleemFeeSahulat(CreateTaleemFeeSahulatDto input)
        {
            try
            {
                var tsa = ObjectMapper.Map<TaleemFeeSahulat>(input);
                 _TaleemFeeSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
        }

        public int CreateTaleemFeeSahulatAndReturnApplicationNumber(CreateTaleemFeeSahulatDto input)
        {
            int AppNumber = 0;
            try
            {
                var tsa = ObjectMapper.Map<TaleemFeeSahulat>(input);

                var lastId = _TaleemFeeSahulatRepository.GetAllList().LastOrDefault();

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


                _TaleemFeeSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
            return AppNumber;
        }

        public async Task<TaleemFeeSahulatListDto> GetTaleemFeeSahulatById(int Id)
        {
            try
            {
                var tsa = await   _TaleemFeeSahulatRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemFeeSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }

        public  TaleemFeeSahulatListDto GetTaleemFeeSahulatByApplicationId(int Id)
        {
            try
            {
                var tsa = _TaleemFeeSahulatRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemFeeSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }


        public async Task<string> UpdateTaleemFeeSahulat(UpdateTaleemFeeSahulatDto input)
        {
            string ResponseString = "";
            try
            {
                var tsa = _TaleemFeeSahulatRepository.Get(input.Id);
                if (tsa != null && tsa.Id > 0)
                {
                    ObjectMapper.Map(input, tsa);
                    await _TaleemFeeSahulatRepository.UpdateAsync(tsa);
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
