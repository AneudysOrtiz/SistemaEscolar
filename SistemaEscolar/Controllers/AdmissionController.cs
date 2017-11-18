using SistemaEscolar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

using System.Web.Http;
using System.Web.UI.WebControls;

namespace SistemaEscolar.Controllers
{
    [RoutePrefix("api/Admission")]
    public class AdmissionController : ApiController
    {


        [HttpGet, Route("GetMyAdmission/{id}")]
        public IHttpActionResult GetMyAdmission(int id)
        {
            using (var db = new GeneralContext())
            {
                var entity = db.Admissions.Where(x=>x.UserId==id).ToList();

                return Ok(entity);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            if (id == 0)
                return BadRequest();

            Admission admission = new Admission();
            admission.UserId = id;
            admission.Date = DateTime.UtcNow;
            admission.Status = 1;

            var acta = HttpContext.Current.Request.Files["acta"];
            

            if (acta != null)
            {
                if (acta.ContentLength > 0)
                {
                    if (Path.GetExtension(acta.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(acta.FileName).ToLower() == ".png"
                            || Path.GetExtension(acta.FileName).ToLower() == ".jpeg"
                            || Path.GetExtension(acta.FileName).ToLower() == ".gif"
                            || Path.GetExtension(acta.FileName).ToLower() == ".docx"
                            || Path.GetExtension(acta.FileName).ToLower() == ".pdf"
                            || Path.GetExtension(acta.FileName).ToLower() == ".doc")
                    {
                        var fileName = Path.GetFileName(acta.FileName); //getting only file name 
                        fileName = "Acta" + admission.UserId.ToString() + fileName;
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/files"), fileName);
                        //empleado.imagen = path;                                                     
                        admission.ActaNacimiento = fileName;
                        acta.SaveAs(path);

                    }
                }
            }


            var Foto = HttpContext.Current.Request.Files["foto"];

            if (Foto != null)
            {
                if (Foto.ContentLength > 0)
                {
                    if (Path.GetExtension(Foto.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".png"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".jpeg"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".docx"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".pdf"
                            || Path.GetExtension(Foto.FileName).ToLower() == ".doc")
                    {
                        var fileName = Path.GetFileName(Foto.FileName); //getting only file name 
                        fileName = "Foto" + admission.UserId.ToString() + fileName;
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/files"), fileName);
                        //empleado.imagen = path;                                                     
                        admission.Foto = fileName;
                        Foto.SaveAs(path);

                    }
                }
            }


            var Conducta = HttpContext.Current.Request.Files["conducta"];

            if (Conducta != null)
            {
                if (Conducta.ContentLength > 0)
                {
                    if (Path.GetExtension(Conducta.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".png"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".jpeg"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".docx"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".pdf"
                            || Path.GetExtension(Conducta.FileName).ToLower() == ".doc")
                    {
                        var fileName = Path.GetFileName(Conducta.FileName); //getting only file name 
                        fileName = "Conducta" + admission.UserId.ToString() + fileName;
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/files"), fileName);
                        //empleado.imagen = path;                                                     
                        admission.BuenaConducta = fileName;
                        Conducta.SaveAs(path);

                    }
                }
            }



            var Record = HttpContext.Current.Request.Files["record"];
            if (Record != null)
            {
                if (Record.ContentLength > 0)
                {
                    if (Path.GetExtension(Record.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Record.FileName).ToLower() == ".png"
                            || Path.GetExtension(Record.FileName).ToLower() == ".jpeg"
                            || Path.GetExtension(Record.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Record.FileName).ToLower() == ".docx"
                            || Path.GetExtension(Record.FileName).ToLower() == ".pdf"
                            || Path.GetExtension(Record.FileName).ToLower() == ".doc")
                    {
                        var fileName = Path.GetFileName(Record.FileName); //getting only file name 
                        fileName = "Record" + admission.UserId.ToString() + fileName;
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/files"), fileName);
                        //empleado.imagen = path;                                                     
                        admission.RecordNotas = fileName;
                        Record.SaveAs(path);

                    }
                }
            }


            var Saldo = HttpContext.Current.Request.Files["saldo"];
            if (Saldo != null)
            {
                if (Saldo.ContentLength > 0)
                {
                    if (Path.GetExtension(Saldo.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".png"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".jpeg"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".gif"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".docx"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".pdf"
                            || Path.GetExtension(Saldo.FileName).ToLower() == ".doc")
                    {
                        var fileName = Path.GetFileName(Saldo.FileName); //getting only file name 
                        fileName = "Saldo" + admission.UserId.ToString() + fileName;
                        var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/files"), fileName);
                        //empleado.imagen = path;                                                     
                        admission.CartaSaldo = fileName;
                        Saldo.SaveAs(path);

                    }
                }
            }

            using (var db = new GeneralContext())
            {
                db.Admissions.Add(admission);
                db.SaveChanges();
            }

            return Ok();
        }

    }

    

}
