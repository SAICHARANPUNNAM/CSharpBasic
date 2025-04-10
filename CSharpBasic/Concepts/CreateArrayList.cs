using System.Collections;

namespace C_SharpBasic.Concepts
{
    class CreateArrayList
    {
        static void Main()
        {
            Console.WriteLine("Hii All just now creating a Arraylist");
            ArrayList items = new ArrayList();
            items.Add("Sai");
            items.Add("charan");
            items.Add("pavan");
            items.Add("sahith");
            items.Add("maharish");
            items.Add("basava");
            
            
            Console.WriteLine(items[1]);
            foreach(string names in items)
            {
                Console.WriteLine(names);
            }
            Console.WriteLine(items.Contains("sahith"));
            items.Sort();
            foreach (string names in items)
            {
                Console.WriteLine(names);
            }

        }
    }
}
