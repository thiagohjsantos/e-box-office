using EBoxOffice.Domain.Validation;

namespace EBoxOffice.Domain.Entities
{
    public sealed class Ticket : Entity
    {

        public decimal Price { get; private set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public Ticket(decimal price)
        {
            ValidateDomain(price);
        }

        public Ticket(int id, decimal price)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(price);
        }

        private void ValidateDomain(decimal price)
        {
            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            Price = price;
        }
    }
}
