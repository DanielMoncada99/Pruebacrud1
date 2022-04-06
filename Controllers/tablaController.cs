using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pruebacrud.Models;
using Pruebacrud.Models.viewmodels;

namespace Pruebacrud.Controllers
{
    public class tablaController : Controller
    {
        // GET: tabla
        public ActionResult Index()

        {
            List<Listtablaviewmodel> lst;
            using (CrudEntities db= new CrudEntities())
            {
                 lst = (from d in db.tabla
                          select new Listtablaviewmodel
                          {
                              Id=d.id,
                              Nombre_de_pelicula=d.nombre_de_pelicula,
                              Genero=d.genero,              
                              Fecha_compra=d.fecha_compra
                          }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(tablaviewmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.genero = model.Genero;
                        oTabla.fecha_compra = model.Fecha_compra;
                        oTabla.nombre_de_pelicula= model.Nombre_de_pelicula;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            tablaviewmodel model = new tablaviewmodel();
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tabla.Find(Id);
                model.Nombre_de_pelicula = oTabla.nombre_de_pelicula;
                model.Genero = oTabla.genero;
                model.Fecha_compra= oTabla.fecha_compra;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(tablaviewmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = db.tabla.Find(model.Id);
                        oTabla.genero = model.Genero;
                        oTabla.fecha_compra = model.Fecha_compra;
                        oTabla.nombre_de_pelicula = model.Nombre_de_pelicula;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntities db = new CrudEntities())
            {

                var oTabla = db.tabla.Find(Id);
                db.tabla.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }
    }
}