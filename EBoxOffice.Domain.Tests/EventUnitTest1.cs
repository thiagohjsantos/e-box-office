using EBoxOffice.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace EBoxOffice.Domain.Tests
{
    public class EventUnitTest1
    {
        [Fact(DisplayName = "Create Event With Valid State")]
        public void CreateEvent_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Event(1, "Event Name", "Event Description", "Event Image", DateTime.Now);
            action.Should()
                 .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateEvent_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Event(-1, "Event Name", "Event Description", "Event Image", DateTime.Now);

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateEvent_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Event("Pr", "Event Description", "Event Image", DateTime.Now);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }
    }
}
