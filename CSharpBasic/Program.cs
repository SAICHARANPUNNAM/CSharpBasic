class Program
{
    int i;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    string s;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    bool b;
   
    static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.i);
        Console.WriteLine(obj.s);
        Console.WriteLine(obj.b);
        Console.ReadLine();
    }
}
