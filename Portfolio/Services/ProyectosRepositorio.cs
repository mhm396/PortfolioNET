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
                },
                new Proyecto()
                {
                    Titulo = "Proyecto 4",
                    Descripcion = "Descripcion del proyecto 4",
                    ImagenURL = "/images/habanero-red.jpg",
                    Link = "https://www.google.com"
                }
            };
        }
    }
}
