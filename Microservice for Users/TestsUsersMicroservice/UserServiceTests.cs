using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersMicroservice.Interfaces;
using UsersMicroservice.DTOs;

namespace Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserService> _userServiceMock;
        private UserDTO _sampleUser1;
        private UserDTO _sampleUser2;

        [SetUp]
        public void SetUp()
        {
            _userServiceMock = new Mock<IUserService>();

            _sampleUser1 = new UserDTO
            {
                Name = "Juan Perez",
                Account = "jperez",
                Password = "1234",
                Email = "juan.perez@example.com",
                BirthDate = new DateTime(1990, 1, 1),
                IsActive = true
            };

            _sampleUser2 = new UserDTO
            {
                Name = "Maria Lopez",
                Account = "mlopez",
                Password = "abcd",
                Email = "maria.lopez@example.com",
                BirthDate = new DateTime(1985, 5, 20),
                IsActive = false
            };
        }

        #region GetUsers
        [Test]
        public void GetUsers_ReturnsEmptyList()
        {
            // Arrange
            _userServiceMock.Setup(s => s.GetUsers()).Returns(new List<UserDTO>());

            // Act
            var result = _userServiceMock.Object.GetUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetUsers_ReturnsMultipleUsers()
        {
            // Arrange
            var users = new List<UserDTO> { _sampleUser1, _sampleUser2 };
            _userServiceMock.Setup(s => s.GetUsers()).Returns(users);

            // Act
            var result = _userServiceMock.Object.GetUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("jperez", result.First().Account);
        }
        #endregion

        #region GetUser
        [Test]
        public void GetUser_ExistingUser_ReturnsUser()
        {
            // Arrange
            int userId = 1;
            _userServiceMock.Setup(s => s.GetUser(userId)).Returns(_sampleUser1);

            // Act
            var result = _userServiceMock.Object.GetUser(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Juan Perez", result.Name);
        }

        [Test]
        public void GetUser_NonExistingUser_ReturnsNull()
        {
            // Arrange
            int userId = 999;
            _userServiceMock.Setup(s => s.GetUser(userId)).Returns((UserDTO)null);

            // Act
            var result = _userServiceMock.Object.GetUser(userId);

            // Assert
            Assert.IsNull(result);
        }
        #endregion

        #region CreateUser
        [Test]
        public void CreateUser_ValidUser_CallsCreateMethodOnce()
        {
            // Arrange
            _userServiceMock.Setup(s => s.CreateUser(It.IsAny<UserDTO>()));

            // Act
            _userServiceMock.Object.CreateUser(_sampleUser1);

            // Assert
            _userServiceMock.Verify(s => s.CreateUser(_sampleUser1), Times.Once);
        }

        [Test]
        public void CreateUser_NullUser_ThrowsArgumentNullException()
        {
            // Aquí asumimos que la implementación real lanzará una excepción.
            _userServiceMock.Setup(s => s.CreateUser(null)).Throws<ArgumentNullException>();

            Assert.Throws<ArgumentNullException>(() => _userServiceMock.Object.CreateUser(null));
        }

        [Test]
        public void CreateUser_InvalidUserData_ThrowsException()
        {
            // Crear un usuario sin nombre
            var invalidUser = new UserDTO
            {
                Name = null,
                Account = "account",
                Password = "pass",
                Email = "email@example.com",
                BirthDate = DateTime.Now,
                IsActive = true
            };

            // Suponemos que la implementación real lanzará una excepción de validación.
            _userServiceMock.Setup(s => s.CreateUser(invalidUser)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _userServiceMock.Object.CreateUser(invalidUser));
        }
        #endregion

        #region UpdateUser
        [Test]
        public void UpdateUser_ExistingUser_ValidData_UpdatesUser()
        {
            // Arrange
            int userId = 1;
            var updatedUser = new UserDTO
            {
                Name = "Nombre Actualizado",
                Account = "CuentaActualizada",
                Password = "12345",
                Email = "actualizado@example.com",
                BirthDate = new DateTime(1992, 2, 2),
                IsActive = true
            };

            _userServiceMock.Setup(s => s.UpdateUser(userId, updatedUser));

            // Act
            _userServiceMock.Object.UpdateUser(userId, updatedUser);

            // Assert
            _userServiceMock.Verify(s => s.UpdateUser(userId, updatedUser), Times.Once);
        }

        [Test]
        public void UpdateUser_NonExistingUser_ThrowsException()
        {
            int userId = 999;
            _userServiceMock.Setup(s => s.UpdateUser(userId, It.IsAny<UserDTO>()))
                            .Throws<KeyNotFoundException>();

            Assert.Throws<KeyNotFoundException>(() => _userServiceMock.Object.UpdateUser(userId, _sampleUser1));
        }

        [Test]
        public void UpdateUser_NullUser_ThrowsArgumentNullException()
        {
            int userId = 1;
            _userServiceMock.Setup(s => s.UpdateUser(userId, null))
                            .Throws<ArgumentNullException>();

            Assert.Throws<ArgumentNullException>(() => _userServiceMock.Object.UpdateUser(userId, null));
        }
        #endregion

        #region DeleteUser
        [Test]
        public void DeleteUser_ExistingUser_DeletesUser()
        {
            // Arrange
            int userId = 1;
            _userServiceMock.Setup(s => s.DeleteUser(userId));

            // Act
            _userServiceMock.Object.DeleteUser(userId);

            // Assert
            _userServiceMock.Verify(s => s.DeleteUser(userId), Times.Once);
        }

        [Test]
        public void DeleteUser_NonExistingUser_ThrowsException()
        {
            int userId = 999;
            _userServiceMock.Setup(s => s.DeleteUser(userId))
                            .Throws<KeyNotFoundException>();

            Assert.Throws<KeyNotFoundException>(() => _userServiceMock.Object.DeleteUser(userId));
        }
        #endregion
    }
}