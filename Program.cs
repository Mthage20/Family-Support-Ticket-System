class Program
{
    static void Main()
    {

        using (var context = new MyDbContext())
        {
            context.Database.EnsureCreated();
        }

        Console.WriteLine("Database schema created successfully!");
        Console.ReadLine();
    }
}
