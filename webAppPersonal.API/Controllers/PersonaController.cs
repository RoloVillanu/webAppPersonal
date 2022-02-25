using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using webAppPersonal.BL.Data;
using webAppPersonal.BL.DTO;
using webAppPersonal.BL.Models;
using webAppPersonal.BL.Repositories.Implements;
using webAppPersonal.BL.Services.Implements;

namespace webAppPersonal.API.Controllers
{
    [RoutePrefix("api/Personas")]
    public class PersonaController : ApiController
    {
        private IMapper mapper;

        private readonly PersonService PersonaService = new PersonService(
                                                            new PersonRepository(
                                                                                    webAppPersonalContext.Create()
                                                                                )
                                                        );
        /// <summary>
        /// Constructor del Controlador de inicializacion de Persona
        /// </summary>
        public PersonaController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Obtener objetos personas
        /// </summary>
        /// <returns>Listado de objetos de personas</returns>
        /// <response code="200">OK. Devuelve listado de objetos solicitados</response>
        [HttpGet]
        [Route("getAll")]
        [ResponseType(typeof(IEnumerable<personaDTO>))]
        public async System.Threading.Tasks.Task<IHttpActionResult> getAll()
        {
            var personas = await PersonaService.GetAll();
            var personasDTO = personas.Select(x => mapper.Map<personaDTO>(x));
            // Metodo Http Status Code
            return Ok(personasDTO);
        }

        /// <summary>
        /// Obtiene uin objeto Persona por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Objeto Persona</returns>
        /// <response code="200">OK. Devuelve listado de objetos solicitados</response>
        /// <response code="400">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> getById(int id)
        {
            var persona = await PersonaService.GetById(id);

            if (persona == null) return NotFound();

            var personasDTO = mapper.Map<personaDTO>(persona);

            return Ok(personasDTO);
        }

        /// <summary>
        /// Metodo para crear una persona
        /// </summary>
        /// <param name="pDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post(personaDTO pDTO) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            try
            {
                var p = mapper.Map<persona>(pDTO);
                p = await PersonaService.Insert(p);
                return Ok(p);
            }
            catch (System.Exception ex) { return InternalServerError(ex); }
            
        }

        /// <summary>
        /// Metodo de actualizacion de datos de una persona
        /// </summary>
        /// <param name="pDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Put(personaDTO pDTO, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Valido que el id de la persona sea coherente
            if (pDTO.idPersona != id) {
                return BadRequest(ModelState);
            }

            // Valido que la persona que se intenta modificar exista
            var flag = await PersonaService.GetById(id);
            if (flag == null) { return NotFound(); }

            try
            {
                var p = mapper.Map<persona>(pDTO);
                p = await PersonaService.Update(p);
                return Ok(p);
            }
            catch (System.Exception ex) { return InternalServerError(ex); }

        }

        /// <summary>
        /// Metodo para elimar el registro de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Delete(int id)
        {
            // Valido que la persona que se intenta modificar exista
            var flag = await PersonaService.GetById(id);
            if (flag == null) { return NotFound(); }

            try
            {                
                await PersonaService.Delete(id);
                return Ok();
            }
            catch (System.Exception ex) { return InternalServerError(ex); }

        }

    }
}
