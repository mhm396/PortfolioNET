using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
//Clases que reciben las peticiones HTTP de los usuarios y devuelven las respuestas, por ejemplo una vistas
namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProyectosRepositorio proyectosRepositorio;
        private readonly IEmailService servicioEmail;

        public HomeController(ILogger<HomeController> logger, IProyectosRepositorio proyectosRepositorio, IEmailService servicioEmail)
        {
            _logger = logger;
            this.proyectosRepositorio = proyectosRepositorio;
            this.servicioEmail = servicioEmail;
        }

        //Acciones que se ejecutan cuando hacemos una peticion HTTP a una ruta especifica de la aplicacion
        //Se ejecutan en respuestan a una peticion HTTP de un cliente
        public IActionResult Index()
        {
            //ViewBag es un diccionario que permite pasar datos desde el controlador a la vista 
            //ViewBag.Nombre = "Miguel Ángel";//Lo que pasa esque solo afecta a la vista Index.cshtml, es mejor utilizar modelos fuertemente tipados
            /*var persona = new Persona()
            {
                Nombre = "Miguel Ángel",
                Edad = 25
            };*/
           // _logger.LogInformation("Se ha cargado la vista Index");
            var proyectos = proyectosRepositorio.ObtenerProyectos().Take(3).ToList();//Obtenemos los proyectos 
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View("Index", modelo);//El primer parametro es el nombre de la vista y el segundo es el modelo que se le pasa a la vista
        }



        public IActionResult Proyectos()//Por defecto es HTTPGET
        {
            var proyectos = proyectosRepositorio.ObtenerProyectos().ToList();
            return View("Proyectos", proyectos);
        }

        public IActionResult Contacto()
        {
           
            return View();
        }

        [HttpPost]//Especificamos que esta accion solo se ejecutara cuando se haga una peticion HTTP POST
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await servicioEmail.Enviar(contactoViewModel);//Enviamos el email
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
