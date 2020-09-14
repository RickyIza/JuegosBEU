using JuegosBEU;
using JuegosBEU.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JuegosApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CabeceraController : ApiController
    {
        public IHttpActionResult Post(CabeceraPedido cabecera)
        {
            try
            {
                CabeceraBLL.Create(cabecera);
                return Content(HttpStatusCode.Created, "CabeceraPedido creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            List<CabeceraPedido> todos = CabeceraBLL.List();
            return Json(todos);
        }

        public IHttpActionResult Put(CabeceraPedido cabecera)
        {
            try
            {
                CabeceraBLL.Update(cabecera);
                return Content(HttpStatusCode.OK, "CabeceraPedido actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                CabeceraPedido result = CabeceraBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                CabeceraBLL.Delete(id);
                return Ok("CabeceraPedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
