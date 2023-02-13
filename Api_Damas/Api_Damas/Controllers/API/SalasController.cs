using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Damas.DAL;
using Api_Damas.Entidades;
using Api_Damas.DAL.Listados;
using Api_Damas.DAL.Manejadoras;

namespace Api_Damas.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        // GET: api/<SalasController>
        [HttpGet]
        public IEnumerable<clsSala> Get()
        {
            return clsListadoSalas.ObtenerListadoCompletoSalasDAL();
        }

        // GET api/<SalasController>/5
        [HttpGet("{id}")]
        public clsSala Get(int id)
        {
            return clsListadoSalas.ObtenerSalaPorIdDAL(id);
        }

        // POST api/<SalasController>
        [HttpPost]
        public void Post([FromBody] clsSala sala)
        {
            clsManejadoraSalas.insertarSalaDAL(sala);
        }

        // PUT api/<SalasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] clsSala sala)
        {
            clsManejadoraSalas.editarSalaDAL(sala);
        }

        // DELETE api/<SalasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int codSala)
        {
            IActionResult result = null;
            int numeroFilasAfectadas = 0;
            try
            {
                numeroFilasAfectadas = clsManejadoraSalas.borrarSalaDAL(codSala);
                if (numeroFilasAfectadas == 0)
                {
                    result = NoContent();
                }
                else
                {
                    result = Ok();
                }
            }
            catch (Exception)
            {
                result = BadRequest();
            }
            return result;
        }
    }
}
