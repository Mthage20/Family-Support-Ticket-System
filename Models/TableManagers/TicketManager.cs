
namespace FamilyTicketSupportSystem.Models.TableManagers
{
	public class TicketManager
	{
		public void CreateTicket(MyDbContext context, Ticket ticket)
		{
			context.Add(ticket);
			context.SaveChanges();
		}

		public void DeleteTicket(MyDbContext context, int id)
		{
			Ticket ticket = context.Tickets.First(x => x.Id == id);
			context.Remove(ticket);
			context.SaveChanges();
		}
	}
}

