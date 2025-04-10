using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpBasic.Concepts
{
    class CreateClass
    {
        public void getData()
        {
            Console.WriteLine("Hello Sai Charan, We are created object Successfully...!");
        }
        static void Main()
        {
            var number = 6545;
            Console.WriteLine(number);
            dynamic name = "Sai charan";
            Console.WriteLine(name);
            name = 554654;
            Console.WriteLine(name);
        }
    }
}
