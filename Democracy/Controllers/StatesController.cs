using Democracy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Democracy.Controllers
{
    //para poder darle autorizacion a este controlador o asi con [Authorize], tanto a nivel de clase o acciones o poder entrar pero no crear  o no dejarlo entrar
    [Authorize]
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
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                //para que muestre una pantalla de erro, lo mejor es crear una vista para 
                //mostra nostros mismos que paso
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //para buscar el id en base de datos fin devuelve un objeto tipo state
            var state = db.States.Find(id);

            //se valida si el estado existe
            if(state ==null)
            {
                //mensaje de error
                return HttpNotFound();
            }
            return View(state);
        }



        //para poner guardar el cambio luedo de editar
        [HttpPost]
        public ActionResult Edit(State state)
        {
            if(!ModelState.IsValid)
            {
                //para que no se pierda lo que el usario lleno ponemos state
                return View(state);
            }

            //para modificar el dato ingresado
            db.Entry(state).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //para mostrar el detalle
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //para que muestre una pantalla de erro, lo mejor es crear una vista para 
                //mostra nostros mismos que paso
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //para buscar el id en base de datos fin devuelve un objeto tipo state
            var state = db.States.Find(id);

            //se valida si el estado existe
            if (state == null)
            {
                //mensaje de error
                return HttpNotFound();
            }
            return View(state);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //para que muestre una pantalla de erro, lo mejor es crear una vista para 
                //mostra nostros mismos que paso
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //para buscar el id en base de datos fin devuelve un objeto tipo state
            var state = db.States.Find(id);

            //se valida si el estado existe
            if (state == null)
            {
                //mensaje de error
                return HttpNotFound();
            }
            return View(state);
        }

        //pos para poder borrar
        [HttpPost]
        public ActionResult Delete(int id, State state )
        {
            //para buscar el id en base de datos fin devuelve un objeto tipo state
            state = db.States.Find(id);

            //se valida si el estado existe
            if (state == null)
            {
                //mensaje de error
                return HttpNotFound();
            }
            db.States.Remove(state);
            db.SaveChanges();
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