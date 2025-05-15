using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
//Clases que reciben las peticiones HTTP de los usuarios y devuelven las respuestas, por ejemplo una vistas
namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var proyectos = ObtenerProyectos().Take(3).ToList();//Obtenemos los proyectos 
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View("Index", modelo);//El primer parametro es el nombre de la vista y el segundo es el modelo que se le pasa a la vista
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto()
                {
                    Titulo = "Proyecto 1",
                    Descripcion = "Descripcion del proyecto 1",
                    ImagenURL = "/images/car1.jpg",
                    Link = "https://www.google.com"
                },
                new Proyecto()
                {
                    Titulo = "Proyecto 2",
                    Descripcion = "Descripcion del proyecto 2",
                    ImagenURL = "/images/donatello1.jpg",
                    Link = "https://www.google.com"
                },
                new Proyecto()
                {
                    Titulo = "Proyecto 3",
                    Descripcion = "Descripcion del proyecto 3",
                    ImagenURL = "/images/habanero-red.jpg",
                    Link = "https://www.google.com"
                }
            };
        }

        public IActionResult Privacy()
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
