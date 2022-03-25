using ElasticProject.Data;
using ElasticProject.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IElasticsearchService _elasticsearchService;
        public HomeController(IElasticsearchService elasticsearchService)
        {
            _elasticsearchService = elasticsearchService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            #region InsertFullData
           await InsertFullData();
            #endregion

            #region Index yoksa oluştur
            //await _elasticsearchService.ChekIndex("cities");
            #endregion

            #region Id göre silme işlemi
            //await _elasticsearchService.DeleteByIdDocument("cities", new Cities { Id = "c651489f-43fa-4a19-97c9-f789e8f630fd", City = "Rize" });
            #endregion

            #region Index göre silme işlemi
           // await _elasticsearchService.DeleteIndex("cities");
            #endregion

            #region Id göre data getirme
            // Cities getCities = await _elasticsearchService.GetDocument("cities", "e6120a5d-3346-4671-ae4f-af97e2daa3e4");
            #endregion
          
            #region Id göre data Insert etme
    //       await _elasticsearchService.InsertDocument("cities", new Cities { City = "EskişehirEskişehirEskişehirEskişehirEskişehir", CreateDate = System.DateTime.Now, Id = Guid.NewGuid().ToString(), Population = 50000, Region = "İç Anadolu" });
            #endregion

            #region Id göre data update işlemi
            // await _elasticsearchService.InsertDocument("cities", new Cities { City = "Bolu", CreateDate = System.DateTime.Now, Id = "", Population = 50000, Region = "Karadeniz" });
            #endregion


            #region query işlemleri
          //  List<Cities> cities = await _elasticsearchService.GetDocuments("cities");
            #endregion

            return Ok("");
        }
        private async Task InsertFullData()
        {
            List<Cities> citiesList = new List<Cities>() {
            new Cities{City="Ankara",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=50000,Region="İç Anadolu"},
            new Cities{City="İzmir",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=30500,Region="Ege"},
            new Cities{City="Aydın",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=65000,Region="Ege"},
            new Cities{City="Rize",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=36522,Region="Karadeniz"},
            new Cities{City="İstanbul",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=25620,Region="Marmara"},
            new Cities{City="Sinop",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=50669,Region="Karadeniz"},
            new Cities{City="Kars",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=55500,Region="Doğu Anadolu"},
            new Cities{City="Van",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=55500,Region="Doğu Anadolu"},
            new Cities{City="Adıyaman",CreateDate=System.DateTime.Now,Id=Guid.NewGuid().ToString(),Population=55500,Region="Güneydoğu Anadolu"},
            };
            await _elasticsearchService.InsertBulkDocuments("cities", citiesList);
        }
    }
}
