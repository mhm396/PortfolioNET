using Portfolio.Models;

namespace Portfolio.Services
{

    public interface IProyectosRepositorio
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class ProyectosRepositorio : IProyectosRepositorio
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto()
                {
                    Titulo = "Filtros espaciales en imágenes",
                    Descripcion = "Programa en C++ para preprocesamiento de imágenes mediante filtros como detección de bordes, suavizado y ajuste de contraste.",
                    ImagenURL = "/images/TDI.png",
                    Link = "https://github.com/mhm396/TDI-Filtros-espaciales"
                },
                    new Proyecto()
                {
                    Titulo = "Ransomware post-cuántico",
                    Descripcion = "Simulación de ataque en Linux con RSA y McEliece, incluyendo un videojuego como fachada para el cifrado.",
                    ImagenURL = "/images/ransomware.jpg",
                    Link = "https://github.com/mhm396/Proyecto-RansomwareEducativo"
                },
                    new Proyecto()
                {
                    Titulo = "SWAPI",
                    Descripcion = "Backend en Laravel y MySQL para gestionar naves y pilotos de Star Wars, con API REST y comando Artisan para importar datos desde SWAPI.",
                    ImagenURL = "/images/swapi.png",
                    Link = "https://github.com/mhm396/SWAPI-BACKEND"
                },
                new Proyecto()
                {
                    Titulo = "Infraestructura en GCP",
                    Descripcion = "Gestión de instancias, contenedores con Kubernetes, copias de seguridad y configuración de firewalls en Google Cloud Platform.",
                    ImagenURL = "/images/kubernetes.jpg",
                    Link = "https://github.com/mhm396"
                },
                new Proyecto()
                {
                    Titulo = "Plataforma E-commerce",
                    Descripcion = "Desarrollo de una plataforma web con PHP y SQL, incluyendo carrito de compras, pasarela de pago y panel de administración.",
                    ImagenURL = "/images/e-commerce.jpeg",
                    Link = "https://github.com/mhm396"
                },

                new Proyecto()
                {
                    Titulo = "Aplicación Android en PlayStore",
                    Descripcion = "App en Android Studio y Firebase para gestión de préstamos, recordatorios y notas colaborativas con sincronización en la nube.",
                    ImagenURL = "/images/REMINDAPP2.jpg",
                    Link = "https://apkcombo.com/es/remind/com.remindApp.miRemind/"
                }

            };
        }
    }
}
