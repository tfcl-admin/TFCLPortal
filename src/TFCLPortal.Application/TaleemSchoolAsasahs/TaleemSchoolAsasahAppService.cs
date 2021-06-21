using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaleemSchoolAsasahs.Dto;

namespace TFCLPortal.TaleemSchoolAsasahs
{
    public class TaleemSchoolAsasahAppService : TFCLPortalAppServiceBase, ITaleemSchoolAsasahAppService
    {
        private readonly IRepository<TaleemSchoolAsasah, Int32> _taleemSchoolAsasahRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        public TaleemSchoolAsasahAppService(IRepository<TaleemSchoolAsasah, Int32> taleemSchoolAsasahRepository,
            IRepository<Applicationz, Int32> applicationRepository)
        {
            _taleemSchoolAsasahRepository = taleemSchoolAsasahRepository;
            _applicationRepository = applicationRepository;
        }

        public void CreateTaleemSchoolAsasah(CreateTaleemSchoolAsasahDto input)
        {
            try
            {
                var tsa = ObjectMapper.Map<TaleemSchoolAsasah>(input);
                 _taleemSchoolAsasahRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
        }

        public int CreateTaleemSchoolAsasahAndReturnApplicationNumber(CreateTaleemSchoolAsasahDto input)
        {
            int AppNumber = 0;
            try
            {
                var tsa = ObjectMapper.Map<TaleemSchoolAsasah>(input);

                var lastId = _taleemSchoolAsasahRepository.GetAllList().LastOrDefault();

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


                _taleemSchoolAsasahRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
            return AppNumber;
        }

        public async Task<TaleemSchoolAsasahListDto> GetTaleemSchoolAsasahById(int Id)
        {
            try
            {
                var tsa = await   _taleemSchoolAsasahRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemSchoolAsasahListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }

        public  TaleemSchoolAsasahListDto GetTaleemSchoolAsasahByApplicationId(int Id)
        {
            try
            {
                var tsa = _taleemSchoolAsasahRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemSchoolAsasahListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }


        public async Task<string> UpdateTaleemSchoolAsasah(UpdateTaleemSchoolAsasahDto input)
        {
            string ResponseString = "";
            try
            {
                var tsa = _taleemSchoolAsasahRepository.Get(input.Id);
                if (tsa != null && tsa.Id > 0)
                {
                    ObjectMapper.Map(input, tsa);
                    await _taleemSchoolAsasahRepository.UpdateAsync(tsa);
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
