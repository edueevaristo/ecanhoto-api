using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ecanhoto.Model;
using ecanhoto.DTO;
using ecanhoto.Context;
using Microsoft.IdentityModel.Tokens;
using ecanhoto.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecanhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    [Authorize]
    public class CanhotoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CanhotoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<CanhotoController>
        [HttpGet]
        public ActionResult<List<Canhoto>> Get()
        {
            return _dataContext.Canhoto.ToList();
        }

        // GET api/<CanhotoController>/5
        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var canhoto = _dataContext.Canhoto.Find(id);

            if (canhoto == null)
            {
                return NotFound();
            }

            return Ok(canhoto);
        }

        // POST api/<CanhotoController>
        [HttpPost]
        public ActionResult<Canhoto> Post([FromBody] CanhotoRequest canhotoRequest)
        {
            if (ModelState.IsValid) {

                var canhoto = canhotoRequest.ToModel();
                _dataContext.Canhoto.Add(canhoto);
                _dataContext.SaveChanges();
                return Ok("Canhoto adicionado com sucesso");

            }

            return BadRequest(ModelState);
        }

        // PUT api/<CanhotoController>
        [HttpPut]
        public ActionResult<Canhoto> Put([FromBody] Canhoto canhoto)
        {
            var atualiza = _dataContext.Canhoto.Where(l => l.Id == canhoto.Id).First();

            if (atualiza == null) {

                return BadRequest();

            }

            atualiza.ImagemCanhoto = canhoto.ImagemCanhoto.IsNullOrEmpty() ? atualiza.ImagemCanhoto : canhoto.ImagemCanhoto;
            atualiza.ColaboradorId = canhoto.ColaboradorId == 0 ? atualiza.ColaboradorId : canhoto.ColaboradorId;
            atualiza.EmpresaId = canhoto.EmpresaId == 0 ? atualiza.EmpresaId : canhoto.EmpresaId;
            atualiza.StatusId = canhoto.StatusId == 0 ? atualiza.StatusId : canhoto.StatusId;
            atualiza.ValorCanhoto = canhoto.ValorCanhoto == 0 ? atualiza.ValorCanhoto : canhoto.ValorCanhoto;
            atualiza.ChaveNf = canhoto.ChaveNf == 0 ? atualiza.ChaveNf : canhoto.ChaveNf;
            atualiza.NumNf = canhoto.NumNf == 0 ? atualiza.NumNf : canhoto.NumNf;

            _dataContext.SaveChanges();

            return Ok();
        }
      
        // DELETE api/<CanhotoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var canhoto = _dataContext.Canhoto.Find(id);

            if (canhoto == null) {

                ModelState.AddModelError("id", "Canhoto não encontrado!");

            }

            if (ModelState.IsValid) {

                _dataContext.Canhoto.Remove(canhoto);
                _dataContext.SaveChanges();
                return Ok();

            }

            return BadRequest(ModelState);
        }

        [HttpGet("imagem/{id}")]
        public IActionResult GetImagemCanhoto(int id)
        {
            var canhoto = _dataContext.Canhoto.Find(id);

            if (canhoto == null) {

                return NotFound("Canhoto não encontrado.");

            } else {

              if (string.IsNullOrEmpty(canhoto.ImagemCanhoto)) {

                return NotFound("Imagem do canhoto não encontrada.");

              }

            }

            return Ok(canhoto.ImagemCanhoto);
        }
    }
}
