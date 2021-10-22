using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraGa1.Model
{
    public class Item
    {
        public string Operation { get; set; }
        public string Result { get; set; }

        public Item(string operation, string result)
        {
            Operation = operation;
            Result = result;
        }
    }
}
