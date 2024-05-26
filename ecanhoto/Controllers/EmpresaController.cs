using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ecanhoto.DTO;
using ecanhoto.Model;
using ecanhoto.Context;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecanhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class EmpresaController : ControllerBase
    {    

        private readonly DataContext _dataContext;
        public EmpresaController() {
            _dataContext = new DataContext();
        }


        // GET: api/<EmpresaController>
        [HttpGet]
        public ActionResult<List<Empresa>> Get()
        {
            return _dataContext.Empresa.ToList();
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public ActionResult<Empresa> Get(int id)
        {
            Empresa empresa = _dataContext.Empresa.FirstOrDefault(empresa => empresa.Id == id);

            if (empresa == null) {
                return NotFound();
            }

            return empresa;
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public ActionResult<Empresa> Post([FromBody] EmpresaRequest empresaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = empresaRequest.ToModel();
            _dataContext.Empresa.Add(empresa);
            _dataContext.SaveChanges();
            return empresa;
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public ActionResult<Empresa> Put([FromBody] Empresa empresaRequest)
        {
            Empresa empresa = _dataContext.Empresa.Where(empresa => empresa.Id == empresaRequest.Id).First();

            if (empresa == null)
            {
                return BadRequest();
            }

            empresa.Nome = empresaRequest.Nome;
            empresa.Cnpj = empresaRequest.Cnpj;
            empresa.RazaoSocial = empresaRequest.RazaoSocial;
     
            _dataContext.SaveChanges();

            return Ok();
        }

            // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empresa = _dataContext.Empresa.Find(id);
            if (empresa == null)
            {
                ModelState.AddModelError("Empresa", "Id da empresa não existe");
            }

            if (ModelState.IsValid)
            {
                _dataContext.Empresa.Remove(empresa);
                _dataContext.SaveChanges();
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
