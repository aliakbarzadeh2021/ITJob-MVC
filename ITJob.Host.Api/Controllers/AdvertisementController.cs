using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITJob.Infrastructure.Exceptions;
using ITJob.Service.Dto;
using ITJob.Service.Interfaces;

namespace ITJob.Host.Api.Controllers
{
    public class AdvertisementController : ApiController
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        //public AdvertisementController()
        //{
            
        //}

        public HttpResponseMessage Post([FromBody] AdvertisementDto advertisement)
        {
            try
            {
                _advertisementService.CreateNewAdvertisement(advertisement);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (DomainException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex.Message));
            }
            catch (Exception ex)
            {
                //ExceptionLogger.SaveException(ex, "_studentService.SaveOrUpdate");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "خطا در پردازش اطلاعات."));
            }
        }
        public void Put(int id, string value)
        {
            var param = new AdvertisementDto();
            _advertisementService.UpdateAdvertisement(param);
        }
        public void Delete(int id)
        {
            var param = new AdvertisementDto();
            _advertisementService.DeleteAdvertisement(param);
        }
        public IEnumerable<AdvertisementDto> Get()
        {
            return _advertisementService.SearchAdvertisement(x => true);
        }
        public AdvertisementDto Get(Guid id)
        {
            return _advertisementService.GetAdvertisementById(id);
        }
    }
}
