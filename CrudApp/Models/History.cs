using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApp.Models
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Action")]
        public int ActionId { get; set; }
        
        public HistoryAction Action { get; set; }

        public DateTime ActionDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public User User { get; set; }

        [ForeignKey("OldEntity")]
        public int? OldEntityId { get; set; }
        
        public Model OldEntity { get; set; }

        [ForeignKey("NewEntity")]
        public int? NewEntityId { get; set; }

        public Model NewEntity { get; set; }
    }
}
