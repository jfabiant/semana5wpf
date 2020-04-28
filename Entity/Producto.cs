using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreCompañia { get; set; }
        public string NombreCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public double PrecioUnidad { get; set; }
        public int UnidadesEnExistencia { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelNuevoPedido { get; set; }
        public int Suspendido { get; set; }
        public string CategoriaProducto { get; set; }

    }
}
