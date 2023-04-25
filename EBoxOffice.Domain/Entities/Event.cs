using EBoxOffice.Domain.Validation;
using System;
using System.Collections.Generic;

namespace EBoxOffice.Domain.Entities
{
    public sealed class Event : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public DateTime Date { get; private set; } = DateTime.Now;

        public ICollection<Ticket> Tickets { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Event(string name, string description, string image, DateTime date)
        {
            ValidateDomain(name, description, image, date);
        }

        public Event(int id, string name, string description, string image, DateTime date)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, image, date);
        }

        public void Update(string name, string description, string image, DateTime date, int categoryId)
        {
            ValidateDomain(name, description, image, date);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, string image, DateTime date)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
               "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
               "Invalid description, too short, minimum 3 characters");

            DomainExceptionValidation.When(image?.Length > 250,
               "Invalid image name, too long, maximum 250 characters");

            DomainExceptionValidation.When(date == DateTime.MinValue,
              "Invalid date. Date is required");

            DomainExceptionValidation.When(date <  DateTime.Now,
               "Invalid date, selected date precedes the current date");

            Name = name;
            Description = description;
            Image = image;
            Date = date;
        }
    }
}
