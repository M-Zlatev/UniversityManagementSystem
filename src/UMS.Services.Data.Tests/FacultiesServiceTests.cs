namespace UMS.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using Contracts;
    using Implementations;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Faculties;
    using UMS.Data.Repositories.Implementations;
    using UMS.Web.ViewModels;

    public class FacultiesServiceTests
    {
        private List<Faculty> faculties;
        private List<FacultyAddress> facultyAddress;
        private Faculty faculty;
        private FacultiesService service;

        [Fact]
        public async Task CheckIfFacultyIsSuccessfullyAdded()
        {
            // Arrange
            this.Setup();
            var beforeAddCount = this.faculties.Count();

            var faculty = new CreateFacultyInputForm();
            this.FillingInCreateFormWithData(faculty);

            // Act
            await this.service.CreateAsync(faculty);

            var actual = this.faculties.Count();
            var expected = beforeAddCount + 1;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task CheckIfFacultyIsSuccessfullyRemoved()
        {
            // Arrange
            this.Setup();

            this.faculty = this.faculties
                .Where(f => f.Id == 1)
                .FirstOrDefault();

            var beforeRemoveCount = this.faculties.Count();

            // Act
            await this.service.DeleteAsync(this.faculty.Id);

            var actual = this.faculties.Count();
            var expected = beforeRemoveCount - 1;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckIfFacultyDataUponCreationIsCorrect()
        {
            // Arrange
            this.Setup();

            // Act
            var faculty = this.faculties.FirstOrDefault();

            var expectedName = "Test Faculty";
            var actualName = faculty.Name;

            var expectedDescription = "Some test faculty";
            var actualDescription = faculty.Description;

            var expectedEmail = "test-faculty@university.com";
            var actualEmail = faculty.Email;

            var expectedPhoneNumber = "+359-7 920 920";
            var actualPhoneNumber = faculty.PhoneNumber;

            var expectedFax = "2 999 7878";
            var actualFax = faculty.Fax;

            var expectedAddressStreetName = "Test street";
            var actualAddressStreetName = faculty.Address.StreetName;

            var expectedAddressDistrictName = "Test district";
            var actualAddressDistrictName = faculty.Address.District;

            var expectedAddressTownName = "Test town";
            var actualAddressTownName = faculty.Address.Town;

            var expectedAddressPostalCode = "1987";
            var actualAddressPostalCode = faculty.Address.PostalCode;

            var expectedAddressCountryName = "Some country";
            var actualAddressCountryName = faculty.Address.Country;

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedDescription, actualDescription);
            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedPhoneNumber, actualPhoneNumber);
            Assert.Equal(expectedFax, actualFax);
            Assert.Equal(expectedAddressStreetName, actualAddressStreetName);
            Assert.Equal(expectedAddressDistrictName, actualAddressDistrictName);
            Assert.Equal(expectedAddressTownName, actualAddressTownName);
            Assert.Equal(expectedAddressPostalCode, actualAddressPostalCode);
            Assert.Equal(expectedAddressCountryName, actualAddressCountryName);
        }

        [Fact]
        public async Task CheckIfFacultyDataIsSuccessfullyUpdated()
        {
            // Arrange
            this.Setup();

            var facultyEditForm = new EditFacultyInputForm();
            this.FillingInEditFormWithData(facultyEditForm, this.faculties, this.facultyAddress);

            var faculty = this.faculties
                .Where(f => f.Id == 1)
                .FirstOrDefault();

            // Act
            facultyEditForm.Name = "Edited name of faculty";
            await this.service.EditAsync(faculty.Id, facultyEditForm);

            var expected = "Edited name of faculty";
            var actual = faculty.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        private async void Setup()
        {
            this.faculties = new List<Faculty>();
            this.facultyAddress = new List<FacultyAddress>();

            var mockRepoFaculty = new Mock<IDeletableEntityRepository<Faculty>>();
            var mockRepoFacultyAddress = new Mock<IRepository<FacultyAddress>>();

            mockRepoFaculty.Setup(x => x.All()).Returns(this.faculties.AsQueryable());
            mockRepoFaculty.Setup(x => x.AddAsync(It.IsAny<Faculty>()))
                .Callback((Faculty faculty) => this.faculties.Add(faculty));
            mockRepoFaculty.Setup(x => x.Delete(It.IsAny<Faculty>()))
                .Callback((Faculty faculty) => this.faculties.Remove(faculty));

            mockRepoFacultyAddress.Setup(x => x.All()).Returns(this.facultyAddress.AsQueryable());

            this.service = new FacultiesService(mockRepoFaculty.Object, mockRepoFacultyAddress.Object);

            var facultyCreateForm = new CreateFacultyInputForm();
            this.FillingInCreateFormWithData(facultyCreateForm);

            await this.service.CreateAsync(facultyCreateForm);

            for (int i = 0; i < this.faculties.Count; i++)
            {
                this.faculties[i].Id = i + 1;
            }
        }

        private void FillingInCreateFormWithData(CreateFacultyInputForm faculty)
        {
            faculty.Name = "Test Faculty";
            faculty.Description = "Some test faculty";
            faculty.Email = "test-faculty@university.com";
            faculty.PhoneNumber = "+359-7 920 920";
            faculty.Fax = "2 999 7878";
            faculty.AddressStreetName = "Test street";
            faculty.AddressDistrictName = "Test district";
            faculty.AddressTownName = "Test town";
            faculty.AddressPostalCode = "1987";
            faculty.AddressCountryName = "Some country";
            faculty.AddressContinentName = Continent.Europe;
        }

        private void FillingInEditFormWithData(
            EditFacultyInputForm facultyForm, List<Faculty> faculties, List<FacultyAddress> facultyAddressesDb)
        {
            var faculty = faculties.FirstOrDefault();

            facultyForm.Name = faculty.Name;
            facultyForm.Description = faculty.Description;
            facultyForm.Email = faculty.Email;
            facultyForm.Fax = faculty.Fax;
            facultyForm.AddressStreetName = faculty.Address.StreetName;
            facultyForm.AddressDistrictName = faculty.Address.District;
            facultyForm.AddressTownName = faculty.Address.Town;
            facultyForm.AddressPostalCode = faculty.Address.PostalCode;
            facultyForm.AddressCountryName = faculty.Address.Country;
            facultyForm.AddressContinentName = faculty.Address.Continent;

            var facultyAddress = new FacultyAddress();
            facultyAddress.Id = faculty.Id;
            facultyAddress.FacultyId = facultyAddressesDb.Count + 1;
            facultyAddress.StreetName = facultyForm.AddressStreetName;
            facultyAddress.District = facultyForm.AddressDistrictName;
            facultyAddress.Town = facultyForm.AddressTownName;
            facultyAddress.PostalCode = facultyForm.AddressPostalCode;
            facultyAddress.Country = facultyForm.AddressCountryName;
            facultyAddress.Continent = facultyForm.AddressContinentName;

            facultyAddressesDb.Add(facultyAddress);
        }
    }
}
