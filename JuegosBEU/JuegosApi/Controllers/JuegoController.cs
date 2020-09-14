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
    public class JuegoController : ApiController
    {
        public IHttpActionResult Post(Juego juego)
        {
            try
            {
                JuegoBLL.Create(juego);
                return Content(HttpStatusCode.Created, "Juego creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            List<Juego> todos = JuegoBLL.List();
            return Json(todos);
        }

        public IHttpActionResult Put(Juego juego)
        {
            try
            {
                JuegoBLL.Update(juego);
                return Content(HttpStatusCode.OK, "Juego actualizado correctamente");

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
                Juego result = JuegoBLL.Get(id);
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

        public IHttpActionResult Get(string criteria)
        {
            try
            {
                List<Juego> todos = JuegoBLL.List(criteria);
                return Content(HttpStatusCode.OK, todos);
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
                JuegoBLL.Delete(id);
                return Ok("Juego eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
