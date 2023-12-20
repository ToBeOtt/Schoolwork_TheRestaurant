using System.ComponentModel.DataAnnotations;
using TheRestaurant.Contracts.DTOs;

namespace TheRestaurant.Testing.ValidationTests
{
    public class AllergyDtoValidationTests
    {
        [Theory]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("Allergy")]
        [InlineData("allergy")]
        //30 chars
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        
        public void NameInput_Should_Be_True(string value)
        {
            var newAllergy = new AllergyDto()
            {
                Id = 1,
                IsDeleted = false,
                Name = value
            };

            var validationContext = new ValidationContext(newAllergy);
            var validationResults = new List<ValidationResult>();
            var isValid= Validator.TryValidateObject(newAllergy, validationContext, validationResults, true);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        //30 chars
        [InlineData("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]

        public void NameInput_Should_Not_Be_True(string value)
        {
            var newAllergy = new AllergyDto()
            {
                Id = 1,
                IsDeleted = false,
                Name = value
            };

            var validationContext = new ValidationContext(newAllergy);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(newAllergy, validationContext, validationResults, true);

            Assert.False(isValid);
        }

    }
}
