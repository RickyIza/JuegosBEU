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
    public class DetallePagoController : ApiController
    {
        public IHttpActionResult Post(DetallePago pago)
        {
            try
            {
                DetallePagoBLL.Create(pago);
                return Content(HttpStatusCode.Created, "DetallePago creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            List<DetallePago> todos = DetallePagoBLL.List();
            return Json(todos);
        }

        public IHttpActionResult Put(DetallePago pago)
        {
            try
            {
                DetallePagoBLL.Update(pago);
                return Content(HttpStatusCode.OK, "DetallePago actualizado correctamente");

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
                DetallePago result = DetallePagoBLL.Get(id);
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
                DetallePagoBLL.Delete(id);
                return Ok("DetallePago eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
