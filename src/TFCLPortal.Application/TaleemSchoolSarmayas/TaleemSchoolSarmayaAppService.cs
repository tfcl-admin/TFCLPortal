using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.TaleemSchoolSarmayas.Dto;

namespace TFCLPortal.TaleemSchoolSarmayas
{
    public class TaleemSchoolSarmayaAppService : TFCLPortalAppServiceBase, ITaleemSchoolSarmayaAppService
    {
        private readonly IRepository<TaleemSchoolSarmaya, Int32> _taleemSchoolSarmayaRepository;


        public TaleemSchoolSarmayaAppService(IRepository<TaleemSchoolSarmaya, Int32> taleemSchoolSarmayaRepository)
        {
            _taleemSchoolSarmayaRepository = taleemSchoolSarmayaRepository;
        }

        public async Task CreateTaleemSchoolSarmaya(CreateTaleemSchoolSarmayaDto input)
        {
            try
            {
                var tss = ObjectMapper.Map<TaleemSchoolSarmaya>(input);
                await _taleemSchoolSarmayaRepository.InsertAsync(tss);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Sarmaya"));
            }
        }


        public async Task<TaleemSchoolSarmayasListDto> GetTaleemSchoolSarmayaById(int Id)
        {
            try
            {
                var tss = await _taleemSchoolSarmayaRepository.GetAsync(Id);

                return ObjectMapper.Map<TaleemSchoolSarmayasListDto>(tss);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Sarmaya"));
            }
        }

        public TaleemSchoolSarmayasListDto GetTaleemSchoolSarmayaByApplicationId(int Id)
        {
            try
            {
                var tss = _taleemSchoolSarmayaRepository.GetAll().Where(x => x.ApplicationId == Id).FirstOrDefault();

                return ObjectMapper.Map<TaleemSchoolSarmayasListDto>(tss);


            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Taleem School Sarmaya"));
            }
        }


        public async Task<string> UpdateTaleemSchoolSarmaya(UpdateTaleemSchoolSarmayaDto input)
        {
            string ResponseString = "";
            try
            {
                var tss = _taleemSchoolSarmayaRepository.Get(input.Id);
                if (tss != null && tss.Id > 0)
                {
                    ObjectMapper.Map(input, tss);
                    await _taleemSchoolSarmayaRepository.UpdateAsync(tss);
                    CurrentUnitOfWork.SaveChanges();
                    return ResponseString = "Records Updated Successfully";
                }
                else
                {
                    throw new UserFriendlyException(L("UpdateMethodError{0}", "Taleem School Sarmaya"));

                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("UpdateMethodError{0}", "Taleem School Sarmaya"));
            }
        }

        public int CreateTaleemSchoolSarmayaAndReturnApplicationNumber(CreateTaleemSchoolSarmayaDto input)
        {
            int AppNumber = 0;
            try
            {
                var tss = ObjectMapper.Map<TaleemSchoolSarmaya>(input);

                var lastId = _taleemSchoolSarmayaRepository.GetAllList().LastOrDefault();

                if (lastId != null)
                {
                    if (lastId.ApplicationNumber > 0)
                    {
                        AppNumber = lastId.ApplicationNumber + 1;
                        tss.ApplicationNumber = AppNumber;
                    }
                    else
                    {
                        AppNumber = 0;
                    }
                }
                else
                {
                    AppNumber = 1;
                    tss.ApplicationNumber = AppNumber;
                }

                _taleemSchoolSarmayaRepository.Insert(tss);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", "Taleem School Sarmayah"));
            }
            return AppNumber;
        }
    }
}
