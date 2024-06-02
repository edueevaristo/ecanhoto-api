using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ecanhoto.Model;
using ecanhoto.DTO;
using ecanhoto.Context;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecanhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ColaboradorController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ColaboradorController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<ColaboradorController>
        [HttpGet]
        public ActionResult<List<Colaborador>> Get()
        {
            return _dataContext.Colaborador.ToList();
        }

        // GET api/<ColaboradorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _dataContext.Colaborador.Find(id).Nome;
        }

        // POST api/<ColaboradorController>
        [HttpPost]
        public ActionResult<Colaborador> Post([FromBody] ColaboradorRequest colaboradorRequest)
        {
            if (ModelState.IsValid)
            {

                var Colaborador = colaboradorRequest.ToModel();
                _dataContext.Colaborador.Add(Colaborador);
                _dataContext.SaveChanges();
                return Ok("Colaborador Adicionado com sucesso");

            }

            return BadRequest(ModelState);
        }

        // PUT api/<ColaboradorController>
        [HttpPut]
        public ActionResult<Colaborador> Put([FromBody] Colaborador Colaborador)
        {
            var atualiza = _dataContext.Colaborador.Where(l => l.Id == Colaborador.Id).First();

            if (atualiza == null) {

                return BadRequest();
            }

            atualiza.Nome = Colaborador.Nome.IsNullOrEmpty() ? atualiza.Nome : Colaborador.Nome;
            atualiza.Senha = Colaborador.Senha.IsNullOrEmpty() ? atualiza.Senha : Colaborador.Senha;
            atualiza.Email = Colaborador.Email.IsNullOrEmpty() ? atualiza.Email : Colaborador.Email;
            atualiza.DataNascimento = Colaborador.DataNascimento.IsNullOrEmpty() ? atualiza.DataNascimento : Colaborador.DataNascimento;
            atualiza.Cep = Colaborador.Cep == 0 ? atualiza.Cep : Colaborador.Cep;
            atualiza.Endereco = Colaborador.Endereco.IsNullOrEmpty() ? atualiza.Endereco : Colaborador.Endereco;

            _dataContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<ColaboradorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Colaborador = _dataContext.Colaborador.Find(id);

            if (Colaborador == null)
            {
                ModelState.AddModelError("id", "Colaborador não encontrado!");
            }

            if (ModelState.IsValid)
            {
                _dataContext.Colaborador.Remove(Colaborador);
                _dataContext.SaveChanges();
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
