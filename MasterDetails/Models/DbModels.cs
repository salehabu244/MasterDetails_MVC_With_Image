using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class Client
    {
        public Client()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int ClientId { get; set; }
        [Required, StringLength(50), Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Marital Status")]
        public bool MaritalStatus { get; set; }
        //nev
        public ICollection<BookingEntry> BookingEntries { get; set; }
    }
    public class Spot
    {
        public Spot()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int SpotId { get; set; }
        [Required, StringLength(50), Display(Name = "Spot Name")]
        public string SpotName { get; set; }
        //nev
        public ICollection<BookingEntry> BookingEntries { get; set; }
    }
    public class BookingEntry
    {
        public int BookingEntryId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Spot")]
        public int SpotId { get; set; }
        //nev
        public virtual Client Client { get; set; }
        public virtual Spot Spot { get; set; }

    }
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<BookingEntry> BookingEntries { get; set; }
    }
}