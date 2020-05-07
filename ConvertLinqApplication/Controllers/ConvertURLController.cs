using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertLinqApplication.Classes;
using ConvertLinqApplication.models;
using ConvertLinqApplication.models.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConvertLinqApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertURLController : ControllerBase
    {
       

        private IUnitOfWork _UW;
        private readonly IEncode _Encode;
        public ConvertURLController(IUnitOfWork UW, IEncode encode)
        {
            _UW = UW;
            _Encode = encode;
        }
        public async Task<string> PostSetUrlAsync( string mainUrl)
        {
            var entity = new Url
            {

                MainUrl = mainUrl,           
            };
            await _UW.BaseRepository<Url>().CreateAsync(entity);
            await _UW.Commit();
            string converturl= _Encode.Encodeint(entity.UrlId);

            entity.ConvertedUrl = converturl;
            _UW.BaseRepository<Url>().Update(entity);
            await _UW.Commit();


            return converturl;
        }

        [HttpGet]
        public async Task<string> GetConvertedUrlAsync(String convertedUrl)

        {
            if (convertedUrl.Length > 0)

            {
                
                int UrlId = _Encode.Decode(convertedUrl);               
                var Url =await _UW.BaseRepository<Url>().FindByIDAsync(UrlId);
                if (Url!=null)
                { 
                    return Url.MainUrl; 
                }
              
            }

            return "وجود ندارد";
        }
    }
}