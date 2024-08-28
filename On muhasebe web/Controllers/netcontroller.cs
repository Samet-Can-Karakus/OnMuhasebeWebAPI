using Microsoft.AspNetCore.Mvc;
using On_muhasebe_web.Business;
using On_muhasebe_web.data.repository;

namespace On_muhasebe_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class netkayitcontroller : ControllerBase
    {

        private readonly INetRepository _netRepository;

        public netkayitcontroller(INetRepository netRepository)
        {
            _netRepository = netRepository;
        }

        [HttpGet]
        public IActionResult GetNetKayitlari()
        {
            var kayitlar = _netRepository.GetNetKayitlari();
            return Ok(kayitlar);
        }
        [HttpPost]
        public IActionResult Inserttarih(tarih kayit)
        {
            var result= _netRepository.Inserttarih(kayit);
            return Ok(result);
        }




    }


}
