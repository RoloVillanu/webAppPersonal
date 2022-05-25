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
    [RoutePrefix("api/Productos")]
    public class ProductoController : ApiController
    {
        private IMapper mapper;

        private readonly ProductService ProductoService = new ProductService(
                                                            new ProductRepository(
                                                                                    webAppPersonalContext.Create()
                                                                                )
                                                        );
        /// <summary>
        /// Constructor del Controlador de inicializacion de Persona
        /// </summary>
        public ProductoController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Obtener objetos productos
        /// </summary>
        /// <returns>Listado de objetos productos</returns>
        /// <response code="200">OK. Devuelve listado de objetos solicitados</response>
        [HttpGet]
        [Route("getAll")]
        [ResponseType(typeof(IEnumerable<productoDTO>))]
        public async System.Threading.Tasks.Task<IHttpActionResult> getAll()
        {
            var productos = await ProductoService.GetAll();
            var productoDTO = productos.Select(x => mapper.Map<productoDTO>(x));
            // Metodo Http Status Code
            return Ok(productoDTO);
        }

        /// <summary>
        /// Obtiene un objeto Producto por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Objeto Producto</returns>
        /// <response code="200">OK. Devuelve listado de objetos solicitados</response>
        /// <response code="400">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> getById(int id)
        {
            var producto = await ProductoService.GetById(id);

            if (producto == null) return NotFound();

            var productoDTO = mapper.Map<productoDTO>(producto);

            return Ok(productoDTO);
        }

        /// <summary>
        /// Metodo para crear un producto
        /// </summary>
        /// <param name="pDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Post(productoDTO pDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var p = mapper.Map<producto>(pDTO);
                p = await ProductoService.Insert(p);
                return Ok(p);
            }
            catch (System.Exception ex) { return InternalServerError(ex); }

        }

        /// <summary>
        /// Metodo de actualizacion de datos de un producto
        /// </summary>
        /// <param name="pDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Put(productoDTO pDTO, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Valido que el id de la persona sea coherente
            if (pDTO.idProducto != id)
            {
                return BadRequest(ModelState);
            }

            // Valido que la persona que se intenta modificar exista
            var flag = await ProductoService.GetById(id);
            if (flag == null) { return NotFound(); }

            try
            {
                var p = mapper.Map<producto>(pDTO);
                p = await ProductoService.Update(p);
                return Ok(p);
            }
            catch (System.Exception ex) { return InternalServerError(ex); }

        }

        /// <summary>
        /// Metodo para elimar el registro de un producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async System.Threading.Tasks.Task<IHttpActionResult> Delete(int id)
        {
            // Valido que la persona que se intenta modificar exista
            var flag = await ProductoService.GetById(id);
            if (flag == null) { return NotFound(); }

            try
            {
                await ProductoService.Delete(id);
                return Ok();
            }
            catch (System.Exception ex) { return InternalServerError(ex); }

        }
    }
}