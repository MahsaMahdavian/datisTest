using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertLinqApplication.Classes;
using ConvertLinqApplication.models;
using ConvertLinqApplication.models.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Primitives;

namespace ConvertLinqApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertURLController : ControllerBase
    {
       

        private IUnitOfWork _UW;
        private readonly IEncode _encode;
        private IHttpContextAccessor _accessor;
        public ConvertURLController(IUnitOfWork UW, IEncode encode, IHttpContextAccessor accessor)
        {
            _UW = UW;
            _encode = encode;
            _accessor = accessor;
        }
        public async Task<string> PostSetUrlAsync([FromBody] string mainUrl)
        {
            var entity = new Url
            {
                MainUrl = mainUrl,           
            };
            await _UW.BaseRepository<Url>().CreateAsync(entity);
            await _UW.Commit();
            string converturl= _encode.Encodeint(entity.UrlId);

            entity.ConvertedUrl = converturl;
            _UW.BaseRepository<Url>().Update(entity);
            var visit = new Visit
            {
                CountVisit = 0,
                UrlId = entity.UrlId
            };
          await  _UW.BaseRepository<Visit>().CreateAsync(visit);
        await _UW.Commit();


            return converturl;
        }

        [HttpGet]
        public async Task<string> GetConvertedUrlAsync(String convertedUrl)

        {
            if (convertedUrl!=null)
            {        
                int UrlId = _encode.Decode(convertedUrl);
                var IP = UserIp();
                var Url =await _UW.BaseRepository<Url>().FindByIDAsync(UrlId);
                if (Url!=null)
                {
                   
                    var Visits = (await _UW.BaseRepository<Visit>().FindByConditionAsync(v => v.UrlId == UrlId && v.UserIP==IP)).FirstOrDefault();
                    //if (Visits.)
                    //{ }
                    if (Visits.UserIP == null)
                    {

                        Visits.CountVisit = 1;
                        Visits.DateTimeVisit = DateTime.Now;
                        Visits.UserIP = IP;
                        _UW.BaseRepository<Visit>().Update(Visits);

                    }

                    else 
                    {
                        if (Visits.UserIP == IP)
                        {
                            Visits.CountVisit += 1;
                            _UW.BaseRepository<Visit>().Update(Visits);
                        }
                        else
                        {
                            var newVisit = new Visit
                            {
                                CountVisit = 1,
                                UserIP = IP,
                                DateTimeVisit = DateTime.Now,
                                UrlId = UrlId

                            };
                            await _UW.BaseRepository<Visit>().CreateAsync(newVisit);
                        }
                     
                    }
                   
                    await _UW.Commit();
                    return Url.MainUrl; 
                }
              
            }

            return "وجود ندارد";
        }

        [HttpGet("VisitorReport")]
        public async Task<IActionResult> GetVisitorReportAsync([FromHeader]string UserIP)
        {
           //if you call this method without userIP in header it try to return all of visits
            if (UserIP == null)
            {
              
              var  result = ((await _UW.BaseRepository<Visit>().FindAllAsync()).Where(b=>b.UserIP!=null));

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            else
            {
              var result2 = (await _UW.BaseRepository<Visit>().FindByConditionAsync(v => v.UserIP == UserIP)).FirstOrDefault();
                if (result2==null)
                {
                    return NotFound(UserIP);
                }
                return Ok(result2);
            }

           
          
        }


        private string UserIp()
        {
            var result = string.Empty;

            //first try to get IP address from the forwarded header
            if (_accessor.HttpContext.Request.Headers != null)
            {
                //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                //connecting to a web server through an HTTP proxy or load balancer

                var forwardedHeader = _accessor.HttpContext.Request.Headers["X-Forwarded-For"];
                if (!StringValues.IsNullOrEmpty(forwardedHeader))
                    result = forwardedHeader.FirstOrDefault();
            }

            //if this header not exists try get connection remote IP address
            if (string.IsNullOrEmpty(result) && _accessor.HttpContext.Connection.RemoteIpAddress != null)
                result = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return result;

        }
    }
}