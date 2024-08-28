using Microsoft.AspNetCore.Mvc;
using On_muhasebe_web.Business;
using On_muhasebe_web.data.repository;

namespace On_muhasebe_web.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class giderkayitcontroller : ControllerBase
        {

            private readonly IGiderRepository _giderRepository;

            public giderkayitcontroller(IGiderRepository giderRepository)
            {
                _giderRepository = giderRepository;
            }

            [HttpGet]
            public IActionResult GetGiderKayitlari()
            {
                var kayitlar = _giderRepository.GetGiderKayitlari();
                return Ok(kayitlar);
            }

            [HttpPost]
            public IActionResult InsertGelirKayit(giderkayit kayit)
            {
                _giderRepository.InsertGiderKayit(kayit);
                return Ok();
            }

            [HttpPut]
            public IActionResult UpdateGiderKayit(giderkayit kayit)
            {
                _giderRepository.UpdateGiderKayit(kayit);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteGiderKayit(int id)
            {
                _giderRepository.DeleteGiderKayit(id);
                return Ok();
            }
        }
}

