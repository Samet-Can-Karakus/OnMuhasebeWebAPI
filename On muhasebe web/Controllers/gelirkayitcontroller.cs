using Microsoft.AspNetCore.Mvc;
using On_muhasebe_web.Business;
using On_muhasebe_web.data.repository;

namespace On_muhasebe_web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class gelirkayitcontroller : ControllerBase
    {

        private readonly IGelirRepository _gelirRepository;

        public gelirkayitcontroller(IGelirRepository gelirRepository)
        {
            _gelirRepository = gelirRepository;
        }

        [HttpGet]
        public IActionResult GetGelirKayitlari()
        {
            var kayitlar = _gelirRepository.GetGelirKayitlari();
            return Ok(kayitlar);
        }

        [HttpPost]
        public IActionResult InsertGelirKayit(gelirkayit kayit)
        {
            _gelirRepository.InsertGelirKayit(kayit);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGelirKayit(gelirkayit kayit)
        {
            _gelirRepository.UpdateGelirKayit(kayit);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGelirKayit(int id)
        {
            _gelirRepository.DeleteGelirKayit(id);
            return Ok();
        }
    }

}
