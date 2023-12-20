using Moq;
using System.Runtime.InteropServices;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Application.Services.AllergyServices;
using TheRestaurant.Contracts.Requests.Allergy;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.AllergyTests
{

    public class AllergyServiceTests
    {

        public static IEnumerable<object[]> AllergyRequestData =>
       new List<object[]>
       {
            new object[]{new AllergyRequest("Muppets", true) },
            new object[]{new AllergyRequest("Deadly", false) }
       };

        public static IEnumerable<object[]> IdAndAllergyRequestData =>
      new List<object[]>
      {
            new object[]{1,new AllergyRequest("Muppets", true) },
            new object[]{2,new AllergyRequest("Deadly", false) }
      };

        public static IEnumerable<object[]> AllergyData =>
     new List<object[]>
     {
            new object[]{ new Allergy() {Id = 1, IsDeleted = false, Name = "test1" } },
            new object[]{ new Allergy() {Id = 2, IsDeleted = false, Name = "test2" } },
            new object[]{ new Allergy() {Id = 3, IsDeleted = false, Name = "test3" } },
            new object[]{ new Allergy() {Id = 4, IsDeleted = false, Name = "test4" } },
     };
        

        [Theory]
        [MemberData(nameof(AllergyRequestData))]
        public async Task CreateAllergyAsync_Should_NotBeNull(AllergyRequest request)
        {

            var _mockRepo = new Mock<IAllergyRepository>();
            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Allergy>()));
            var allergyService = new AllergyService(_mockRepo.Object);

            var createdAllergy = await allergyService.CreateAllergyAsync(request);

            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Allergy>()), Times.Once());
            Assert.NotNull(createdAllergy);

        }

        [Theory]
        [MemberData(nameof(AllergyData))]
        public async Task DeleteAllergyAsync_Should_Delete(Allergy allergy)
        {
            var _mockRepo = new Mock<IAllergyRepository>();
            _mockRepo.Setup(r => r.GetByIdAsync(allergy.Id)).ReturnsAsync(allergy);
            var allergyService = new AllergyService(_mockRepo.Object);

            await allergyService.DeleteAllergyAsync(allergy.Id);

            _mockRepo.Verify(r => r.DeleteAsync(allergy), Times.Once());
        }

        [Fact]
        public async Task GetAllAllergies_Should_Return_List_Of_Allergies()
        {
            var expected = new List<Allergy>()
            {
                { new Allergy() {Id = 1, IsDeleted = false, Name = "test1" } },
                { new Allergy() {Id = 2, IsDeleted = false, Name = "test2" } },
                { new Allergy() {Id = 3, IsDeleted = false, Name = "test3" } },
                { new Allergy() {Id = 4, IsDeleted = false, Name = "test4" } }
            };

            var _mockRepo = new Mock<IAllergyRepository>();
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expected);
            var allergyService = new AllergyService(_mockRepo.Object);

            var actual = await allergyService.GetAllAllergies();

            Assert.Equal(expected, actual);

        }

        [Theory]
        [MemberData(nameof(AllergyData))]
        
        public async Task GetAllergyById_Should_Return_Allergy(Allergy allergy)
        {
            var expected = allergy;
            var _mockRepo = new Mock<IAllergyRepository>();
            _mockRepo.Setup(r => r.GetByIdAsync(allergy.Id).Result).Returns(expected);
            var allergyService = new AllergyService(_mockRepo.Object);

            var actual = await allergyService.GetAllergyById(allergy.Id);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(IdAndAllergyRequestData))]
        public async Task UpdateAllergyAsync_Should_Return_Allergy(int id, AllergyRequest request)
        {
            var expected = new Allergy()
            {
                Id = id,
                IsDeleted = false,
                Name = "test1"
            };
            
            var _mockRepo = new Mock<IAllergyRepository>();
            _mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(expected);
            var allergyService = new AllergyService(_mockRepo.Object);

            var actual = await allergyService.UpdateAllergyAsync(id, request);

            Assert.Equal(expected, actual);
        }



    }
}
