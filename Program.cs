using FamilyTicketSupportSystem.Models;
using FamilyTicketSupportSystem.Models.TableManagers;

class Program
{
    static void Main()
    {

        using (var context = new MyDbContext())
        {
            context.Database.EnsureCreated();
            TicketManager manager = new TicketManager();
            var ticket1 = Ticket.Create(
                user_id:1,
                description: "blabla",
                status: Ticket.Status.Not_In_Progress,
                priority: Ticket.Priority.Medium
                );
            manager.CreateTicket(context, ticket1);
        }

        Console.WriteLine("Database schema created successfully!");
        Console.ReadLine();
    }
}