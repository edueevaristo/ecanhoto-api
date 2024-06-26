﻿using Microsoft.AspNetCore.Cors;
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
    public class StatusController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public StatusController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<StatusController>
        [HttpGet]
        public ActionResult<List<Status>> Get()
        {
            return _dataContext.Status.ToList();
        }

        // GET api/<StatusController>/id/5
        [HttpGet("id/{id}")]
        public ActionResult<string> Get(int id)
        {
            var status = _dataContext.Status.Find(id);
            if (status == null)
            {
                return NotFound("Status não encontrado.");
            }
            return status.Nome;
        }

        // GET api/<StatusController>/nome/{nome}
        [HttpGet("nome/{nome}")]
        public ActionResult<int> GetStatusPerName(string nome)
        {
            var status = _dataContext.Status.FirstOrDefault(s => s.Nome == nome);
            if (status == null)
            {
                return NotFound("Status não encontrado.");
            }
            return status.Id;
        }

        // POST api/<StatusController>
        [HttpPost]
        public ActionResult<Status> Post([FromBody] StatusRequest statusRequest)
        {
            if (ModelState.IsValid)
            {
                var status = statusRequest.ToModel();
                _dataContext.Status.Add(status);
                _dataContext.SaveChanges();
                return Ok("Status adicionado com sucesso!");
            }

            return BadRequest(ModelState);
        }

        // PUT api/<StatusController>
        [HttpPut]
        public ActionResult<Status> Put([FromBody] Status status)
        {
            var atualiza = _dataContext.Status.Where(l => l.Id == status.Id).First();

            if (atualiza == null)
            {
                return BadRequest();
            }

            atualiza.Nome = status.Nome.IsNullOrEmpty() ? atualiza.Nome : status.Nome;
            atualiza.Ativo = status.Ativo == atualiza.Ativo ? atualiza.Ativo : status.Ativo;

            _dataContext.SaveChanges();

            return Ok("Status atualiazado com sucesso!");
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var status = _dataContext.Status.Find(id);

            if (status == null)
            {
                ModelState.AddModelError("id", "Status não encontrado!");
            }

            if (ModelState.IsValid)
            {
                _dataContext.Status.Remove(status);
                _dataContext.SaveChanges();
                return Ok("Status removido com sucesso!");
            }

            return BadRequest(ModelState);
        }
    }
}
