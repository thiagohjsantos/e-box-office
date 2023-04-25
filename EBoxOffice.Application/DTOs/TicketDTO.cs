using EBoxOffice.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBoxOffice.Application.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        public Event Event { get; set; }

        [DisplayName("Events")]
        public int EventId { get; set; }
    }
}
