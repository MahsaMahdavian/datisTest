using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertLinqApplication.Classes;
using ConvertLinqApplication.Filter;
using ConvertLinqApplication.models;
using ConvertLinqApplication.models.UnitOfWork;
using ConvertLinqApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ConvertLinqApplication.Controllers.v2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ConvertURLController : v1.ConvertURLController
    {
        private IUnitOfWork _UW;
        private readonly IEncode _encode;
        private IHttpContextAccessor _accessor;
        private  IjwtService _jwtService;
        public ConvertURLController(IUnitOfWork UW, IEncode encode, IHttpContextAccessor accessor, IjwtService jwtService)
            :base(UW,encode,accessor,jwtService)
        {
            _UW = UW;
            _encode = encode;
            _accessor = accessor;
            _jwtService = jwtService;
        }

        [HttpGet]
        public override async Task<ApiResult<string>> GetConvertedUrlAsync(String convertedUrl)
        {
            var Visits = (await _UW.BaseRepository<Url>().FindByConditionAsync(u => u.ConvertedUrl == convertedUrl)).SingleOrDefault();
            return Visits.MainUrl;
           
        }
    }
}