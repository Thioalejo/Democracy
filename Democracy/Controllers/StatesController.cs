using Democracy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Democracy.Controllers
{
    public class StatesController : Controller
    {
        //clase para conectarme a base de datos
        private DemocratyContext db = new DemocratyContext();
        // GET: States

       ///para crear lista de estados
        public ActionResult Index()
        {
            return View(db.States.ToList());
        }

        //para crear la accion, para crear lista o llenar tabla
        public ActionResult Create()
        {
            return View();
        }
        //se sobre escribe el metodo crear para que al precionar el boton crear si cree
        [HttpPost]
        public ActionResult Create(State state)
        {
            //si el modelo no es valido devuelvase
            if(!ModelState.IsValid)
            {
                return View(state);
            }

            //mandamos el objeto a la base de datos, es decir asi grabamos en base de datos
            db.States.Add(state);
            db.SaveChanges();

            //para retornar a la misma vista dejamos return View, pero para 
            //retornar otra vista ponemos RedirectToAction y el nombre de la vista
            return RedirectToAction("Index");
        }

        //cerrar conexion bd
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}