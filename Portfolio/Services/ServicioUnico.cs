using System.Runtime.CompilerServices;

namespace Portfolio.Services
{

    public class ServicioUnico
    {
        public ServicioUnico()
        {
            ObtenerGuid = Guid.NewGuid(); //String aleatorio que ejecutara cada vez que instanciemos la clase
        }

        public Guid ObtenerGuid { get; private set; }

    }

    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid(); //String aleatorio que ejecutara cada vez que instanciemos la clase
        }

        public Guid ObtenerGuid { get; private set; }
    }

    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid(); //String aleatorio que ejecutara cada vez que instanciemos la clase
        }

        public Guid ObtenerGuid { get; private set; }

    }

}
