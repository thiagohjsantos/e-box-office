using EBoxOffice.Domain.Entities;
using EBoxOffice.Domain.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EBoxOffice.Application.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [MaxLength(250)]
        [DisplayName("Event Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The Date is Required")]
        [DateValidation(ErrorMessage = "Invalid date, selected date precedes the current date")]
        [DisplayName("Date")]
        public string Date { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public TicketDTO Tickets { get; set; }
    }
}
