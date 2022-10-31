using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concepto
{
    public class Empleado
    {
        public int Codigo { get; set; }
        public string NombreEmp { get; set; }
        public string CargoEmp { get; set; }

        public Empleado(int codigo)
        {
            Codigo = codigo;
        }

    }
    public class Gerente : Empleado
    {

        public string Departamento { get; set; }
        public Gerente(int codigoG, string departamento) : base(codigoG)
        {
            Departamento = departamento;
        }
    }
}