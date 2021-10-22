using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraGa1.Model
{
    public class ListItem
    {
        public string Operation { get; set; }
        public string Result { get; set; }

        public ListItem(string operation, string result)
        {
            Operation = operation;
            Result = result;
        }
    }
}
