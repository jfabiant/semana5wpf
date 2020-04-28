using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProducto
    {

        private DProducto dProducto = null;

        public List<Producto> Get (int idproducto)
        {
            List<Producto> productoList = null;

            try
            {
                dProducto = new DProducto();
                productoList = dProducto.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productoList;

        }

        public Boolean Insert (Producto producto)
        {
            bool itsok;
            try
            {
                dProducto = new DProducto();
                producto.IdProducto = dProducto.Get().Max(x => x.IdProducto) + 1;
                bool rpt = dProducto.Insert(producto);
                System.Console.WriteLine("#### CAPA DATA "+rpt);
                itsok = true;
            }
            catch (Exception ex)
            {
                itsok = false;
                throw ex;
            }
            return itsok;
        }
        
    }
}
