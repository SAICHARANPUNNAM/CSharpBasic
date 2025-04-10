namespace C_SharpBasic.Concepts
{
    class CreateConstructor
    {
        string name;

        public CreateConstructor(string name)
        {
            this.name = name; // in constructor class assign name to base class using this keyword instlaize the variable
        }
        public void getData()
        {
            Console.WriteLine(this.name);// this keyword is used for call the name in same class in this method.
        }
        public static void Main()
        {
            CreateConstructor obj = new CreateConstructor("Sai Charan");


            obj.getData();
        }
    }


}
