using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriApp.Data;
using NutriApp.Data.Interfaces;
using NutriApp.Data.Repositories;
using NutriApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Paciente")]
    public class PacienteController : Controller
    {
        private readonly NutriAppContext _context;
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController(NutriAppContext context, IPacienteRepository pacienteRepository)
        {
            _context = context;
            _pacienteRepository = pacienteRepository;
        }

        // GET: api/Paciente
        [HttpGet]        
        public IEnumerable<Paciente> GetPaciente()
        {
            //var result = _context.Paciente.Include("Endereco");

            return _pacienteRepository.GetAll();
        }

        // GET: api/Paciente/5
        [HttpGet("{id}")]
        public IActionResult GetPaciente([FromRoute] int id)
        {
            var paciente = _pacienteRepository.GetById(id);
            if (paciente == null)
                return NotFound();

            return Json(paciente);


        }

        // PUT: api/Paciente/5
        [HttpPut("{id}")]
        public IActionResult PutPaciente([FromRoute] int id, [FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                string mensagem = string.Empty;
                foreach (var item in ModelState.Values.SelectMany(v => v.Errors).ToList())
                {
                    mensagem += string.Format("{0}\n\r", item.ErrorMessage);
                }

                return BadRequest(mensagem);
            }

            if (id != paciente.idPaciente)
            {
                return BadRequest();
            }

            //_context.Entry(paciente).State = EntityState.Modified;
            _pacienteRepository.Update(paciente);

            try
            {
                _pacienteRepository.SaveChanges();
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaciente", new { id = paciente.idPaciente }, paciente);
        }

        // POST: api/Paciente
        [HttpPost]
        public IActionResult PostPaciente([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pacienteRepository.Add(paciente);
            _pacienteRepository.SaveChanges();

            return CreatedAtAction("GetPaciente", new { id = paciente.idPaciente }, paciente);
        }

        // DELETE: api/Paciente/5
        [HttpDelete("{id}")]
        public IActionResult DeletePaciente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paciente = _pacienteRepository.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }

            //_context.Paciente.Remove(paciente);
            _pacienteRepository.Remove(id);
            //await _context.SaveChangesAsync();
            _pacienteRepository.SaveChanges();

            return Ok(paciente);
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.idPaciente == id);
        }
    }
}