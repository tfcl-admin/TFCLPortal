using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Klasses;
using TFCLPortal.Students.Dto;

namespace TFCLPortal.Students
{
    public class StudentAppService : TFCLPortalAppServiceBase, IStudentAppService
    {
        private readonly IRepository<Student, Int32> _StudentRepository;
        private readonly IRepository<Klass, Int32> _KlassRepository;
        private string Student = "Student";
        public StudentAppService(IRepository<Student, Int32> StudentRepository, IRepository<Klass, Int32> KlassRepository)
        {
            _StudentRepository = StudentRepository;
            _KlassRepository = KlassRepository;
        }
        public async Task CreateStudent(CreateStudentDto input)
        {
            try
            {
                var Student = ObjectMapper.Map<Student>(input);
                await _StudentRepository.InsertAsync(Student);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CreateMethodError{0}", Student));
            }
        }
        public  StudentListDto GetStudentById(int Id)
        {
            try
            {
                var Student = _StudentRepository.Get(Id);

                var rtn= ObjectMapper.Map<StudentListDto>(Student);

                if (Student.Class != 0)
                {
                    var classname=_KlassRepository.Get(Student.Class);
                    if(classname != null)
                    {
                        rtn.ClassName = classname.Name;
                    }
                }


                return rtn;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Student));
            }

        }
        public List<StudentListDto> GetStudentList()
        {
            try
            {
                var Student = _StudentRepository.GetAll();

                return ObjectMapper.Map<List<StudentListDto>>(Student);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", Student));
            }
        }

      
    }
}
