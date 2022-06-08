using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.ApplicationWorkFlows.BccStates.Dto;
using TFCLPortal.EntityFrameworkCore.Repositories;
using TFCLPortal.Mobilizations;
using TFCLPortal.ProscribedPersons;
using TFCLPortal.Schedules;
using TFCLPortal.WorkFlows;

namespace TFCLPortal.Customs
{
    public class CustomAppService : AsyncCrudAppService<BccState, BccStateListDto, Int32, PagedResultRequestDto, CreateBccStateDto, BccStateListDto>, ICustomAppService
    {
        private static IRepository<BccState, int> repository;
        private static IRepository<ProscribedPerson> _proscribedPersonRepository;
        private readonly ICustomRepository _customRepository;

        public CustomAppService(ICustomRepository customRepository, IRepository<ProscribedPerson> proscribedPersonRepository) : base(repository)
        {
            _proscribedPersonRepository = proscribedPersonRepository;
            _customRepository = customRepository;
        }


        public async Task<bool> GetBccApplicationApprovedStaus(int applicationId)
        {
            return await _customRepository.GetBccApplicationApprovedStaus(applicationId);
        }

        public async Task<double> GetIrr(int nper, double pmt, double pv, double fv, bool type)
        {
            return await _customRepository.GetIRR(nper, pmt, pv, fv, type);
        }

        public async Task<List<GetMobilizationListDto>> getMobilizationListBySP()
        {
            return _customRepository.GetMobilizationsByMaxInteractionNumber();
        }

        public string getNactaData()
        {
            var JsonResponse = GetJson();

            if (!JsonResponse.Equals("Error"))
            {
                var personList = ObjectMapper.Map<List<ProscribedPerson>>(JsonResponse);

                if(personList.Count>0)
                {
                    var allPersons = _proscribedPersonRepository.GetAllList();

                    foreach(var person in allPersons)
                    {
                        _proscribedPersonRepository.DeleteAsync(person);
                    }

                    foreach (var person in personList)
                    {
                        _proscribedPersonRepository.InsertAsync(person);
                    }
                }
                else
                {
                    return "Error: No Rows";
                }


                return "Success";

            }
            else
            {
                return "Error";
            }

        }

        public List<ProscribedPerson> getProscribedPersonList()
        {

            var allPersons = _proscribedPersonRepository.GetAllList();

            return allPersons;
        }

        public Object GetJson()
        {

            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://nfs.punjab.gov.pk/Home/GetJosn");

            //HttpContent content = response.Content;


            //JObject s = JObject.Parse(await content.ReadAsStringAsync());
            //string yourPrompt = (string)s["dialog"]["prompt"];

            string url = "http://nfs.punjab.gov.pk/Home/GetJosn";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                return s;
            }
            else
            {
                return "Error";
            }

        }

    }
}
