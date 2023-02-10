using Api_Damas.DAL.Listados;
using Api_Damas.DAL.Manejadoras;
using Api_Damas.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api_Damas.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        // GET: api/<JugadoresController>
        [HttpGet]
        public List<clsJugador> Get()
        {
            return clsListadoJugadores.ObtenerListadoJugadoresDAL();
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public clsJugador Get(int id)
        {
            return clsListadoJugadores.ObtenerJugadorPorIdDAL(id);
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public IActionResult Post([FromBody] clsJugador jugador)
        {
            IActionResult result = null;
            int numeroFilasAfectadas = 0;
            try
            {
                numeroFilasAfectadas = clsManejadoraJugadores.insertarJugadorDAL(jugador);
            }
            catch (Exception e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;
        }

        // PUT api/<JugadoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] clsJugador jugador)
        {
            IActionResult result = null;
            int numeroFilasAfectadas = 0;

            try
            {
                numeroFilasAfectadas = clsManejadoraJugadores.editarJugadorDAL(jugador);
            }
            catch (Exception e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;
        }
    }
}