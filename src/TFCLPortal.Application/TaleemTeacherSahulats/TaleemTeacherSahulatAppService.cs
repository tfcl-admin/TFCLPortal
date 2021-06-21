using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;
using TFCLPortal.TaleemTeacherSahulats.Dto;

namespace TFCLPortal.TaleemTeacherSahulats
{
    public class TaleemTeacherSahulatAppService : TFCLPortalAppServiceBase, ITaleemTeacherSahulatAppService
    {
        private readonly IRepository<TaleemTeacherSahulat, Int32> _TaleemTeacherSahulatRepository;
        private readonly IRepository<Applicationz, Int32> _applicationRepository;

        public TaleemTeacherSahulatAppService(IRepository<TaleemTeacherSahulat, Int32> TaleemTeacherSahulatRepository,
            IRepository<Applicationz, Int32> applicationRepository)
        {
            _TaleemTeacherSahulatRepository = TaleemTeacherSahulatRepository;
            _applicationRepository = applicationRepository;
        }

        public void CreateTaleemTeacherSahulat(CreateTaleemTeacherSahulatDto input)
        {
            try
            {
                var tsa = ObjectMapper.Map<TaleemTeacherSahulat>(input);
                 _TaleemTeacherSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
        }

        public int CreateTaleemTeacherSahulatAndReturnApplicationNumber(CreateTaleemTeacherSahulatDto input)
        {
            int AppNumber = 0;
            try
            {
                var tsa = ObjectMapper.Map<TaleemTeacherSahulat>(input);

                var lastId = _TaleemTeacherSahulatRepository.GetAllList().LastOrDefault();

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


                _TaleemTeacherSahulatRepository.Insert(tsa);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Asasah"));
            }
            return AppNumber;
        }

        public async Task<TaleemTeacherSahulatListDto> GetTaleemTeacherSahulatById(int Id)
        {
            try
            {
                var tsa = await   _TaleemTeacherSahulatRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemTeacherSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }

        public  TaleemTeacherSahulatListDto GetTaleemTeacherSahulatByApplicationId(int Id)
        {
            try
            {
                var tsa = _TaleemTeacherSahulatRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemTeacherSahulatListDto>(tsa);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Asasah"));
            }
        }


        public async Task<string> UpdateTaleemTeacherSahulat(UpdateTaleemTeacherSahulatDto input)
        {
            string ResponseString = "";
            try
            {
                var tsa = _TaleemTeacherSahulatRepository.Get(input.Id);
                if (tsa != null && tsa.Id > 0)
                {
                    ObjectMapper.Map(input, tsa);
                    await _TaleemTeacherSahulatRepository.UpdateAsync(tsa);
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
