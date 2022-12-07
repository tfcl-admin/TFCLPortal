using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Klasses.Dto;

namespace TFCLPortal.Klasses
{
    public class KlassAppService : TFCLPortalAppServiceBase, IKlassAppService
    {
        private readonly IRepository<Klass, Int32> _KlassRepository;
        private string Klass = "Klass";
        public KlassAppService(IRepository<Klass, Int32> KlassRepository)
        {
            _KlassRepository = KlassRepository;
        }
        public async Task CreateKlass(CreateKlassDto input)
        {
            try
            {
                var Klass = ObjectMapper.Map<Klass>(input);
                await _KlassRepository.InsertAsync(Klass);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", Klass));
            }
        }

 
        public KlassListDto GetklassById(int Id)
        {
            try
            {
                var Klass = _KlassRepository.Get(Id);

                var rtn = ObjectMapper.Map<KlassListDto>(Klass);

                if (Klass.TotalStudents != 0)
                {
                    rtn.Teacher = "Sir XYZ";
                }


                return rtn;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Klass));
            }
        }

        public List<KlassListDto> GetKlassList()
        {
            try
            {
                var Klass = _KlassRepository.GetAll();

                return ObjectMapper.Map<List<KlassListDto>>(Klass);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Klass));
            }
        }

      
    }
}
