using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServidores
{
    public abstract class ComandoGenerico
    {
        public abstract void Ejecutar();
        public abstract void Borrar();
        public void Log(string mensaje)
        {
            Console.WriteLine($"Log: {mensaje}");
        }
    }
}
