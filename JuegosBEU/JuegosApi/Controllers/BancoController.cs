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
    public class BancoController : ApiController
    {
        public IHttpActionResult Post(Banco banco)
        {
            try
            {
                BancoBLL.Create(banco);
                return Content(HttpStatusCode.Created, "Banco creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            List<Banco> todos = BancoBLL.List();
            return Json(todos);
        }

        public IHttpActionResult Put(Banco banco)
        {
            try
            {
                BancoBLL.Update(banco);
                return Content(HttpStatusCode.OK, "Banco actualizado correctamente");

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
                Banco result = BancoBLL.Get(id);
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
                List<Banco> todos = BancoBLL.List(criteria);
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
                BancoBLL.Delete(id);
                return Ok("Banco eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
