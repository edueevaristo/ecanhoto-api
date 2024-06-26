﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ecanhoto.DTO;
using ecanhoto.Model;
using ecanhoto.Context;
using Microsoft.IdentityModel.Tokens;
using ecanhoto.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecanhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    //[Authorize]

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

        // GET api/<EmpresaController>/id/5
        [HttpGet("id/{id}")]
        public ActionResult<string> Get(int id)
        {
            var empresa = _dataContext.Empresa.Find(id);

            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            return empresa.Nome;
        }

        // GET api/<EmpresaController>/nome/{nome}
        [HttpGet("nome/{nome}")]
        public ActionResult<int> GetEmpresaPerName(string nome)
        {
            var empresa = _dataContext.Empresa.FirstOrDefault(s => s.Nome == nome);

            if (empresa == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            return empresa.Id;
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
