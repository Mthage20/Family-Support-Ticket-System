using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTicketSupportSystem.Models
{
	public class Ticket
	{

        public enum Status
        {
            Not_In_Progress,
            In_Progress,
            Done
        }

        public enum Priority
        {
            High,
            Medium,
            Low
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for each ticket (primary key)
        public int User_id { get; set; } // ID of the user who submitted the ticket (Foreign key referencing Users.id).
        public string Description { get; set; } // Description  of the issue

        [NotMapped]
        public Status Ticket_status
        {
            get => Enum.Parse<Status>(Ticket_status_string);
            set => Ticket_status_string = value.ToString();
        }

        private string _ticketStatusString;

        [Column("Ticket_status")]
        public string Ticket_status_string
        {
            get => _ticketStatusString;
            set => _ticketStatusString = value;
        }

        [NotMapped]
        public Priority Ticket_priority
        {
            get => Enum.Parse<Priority>(Ticket_priority_string);
            set => Ticket_priority_string = value.ToString();
        }

        private string _ticketPriorityString;

        [Column("Ticket_priority")]
        public string Ticket_priority_string
        {
            get => _ticketPriorityString;
            set => _ticketPriorityString = value;
        }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }


        public static Ticket Create(int user_id, string description, Status status, Priority priority)
        {
            return new Ticket
            {
                User_id = user_id,
                Description = description,
                Ticket_status = status,
                Ticket_priority = priority,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };
        }

    }
}