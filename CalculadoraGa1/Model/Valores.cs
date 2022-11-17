using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraGa1.Model
{
    internal class Valores
    {
        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public decimal Resultado { get; set; }

        public Valores(string valor1, string valor2)
        {
            this.Valor1 = decimal.Parse(valor1);
            this.Valor2 = decimal.Parse(valor2);
        }

        public Valores(string _Resultado)
        {
            this.Resultado = decimal.Parse(_Resultado);
        }
    }
}
