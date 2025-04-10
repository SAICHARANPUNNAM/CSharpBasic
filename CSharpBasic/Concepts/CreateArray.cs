namespace C_SharpBasic.Concepts
{
    class CreateArray
    {
       public static void Main()
        {
            string[] characters = { "sai", "charan", "pavan", "sahith" };
            string[] name = new string[4];
            Console.WriteLine(characters[0]);
            for (int i = 0; i<characters.Length; i++)
            {
                Console.WriteLine(characters[i]);
                if (characters[i] == "pavan")
                {
                    Console.WriteLine("Match Found");
                    break;
                }
                else
                {
                    Console.WriteLine("There is no Match");
                }
            }
        }
    }
}
