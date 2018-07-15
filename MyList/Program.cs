using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main()
        {
            myList<int> test = new myList<int>();

            test.Add(1);
            test.Add(2);
            test.Add(5);

            foreach (var i in test)
                Console.Write(i);
        }
    }
}

