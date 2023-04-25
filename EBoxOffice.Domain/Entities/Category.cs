using EBoxOffice.Domain.Validation;
using System.Collections.Generic;

namespace EBoxOffice.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Event> Events { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. Too short, minimum 3 characters");

            Name = name;
        }
    }
}
