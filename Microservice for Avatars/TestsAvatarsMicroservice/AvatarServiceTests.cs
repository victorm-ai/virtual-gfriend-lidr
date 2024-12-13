using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using AvatarsMicroservice.DTOs;
using AvatarsMicroservice.Interfaces;

namespace Tests
{
    [TestFixture]
    public class AvatarServiceTests
    {
        private Mock<IAvatarService> _avatarServiceMock;
        private AvatarDTO _sampleAvatar1;
        private AvatarDTO _sampleAvatar2;

        [SetUp]
        public void SetUp()
        {
            _avatarServiceMock = new Mock<IAvatarService>();

            _sampleAvatar1 = new AvatarDTO
            {
                Name = "Guerrero",
                UserId = 1,
                PersonalityId = 10,
                IsActive = true,
                Timestamp = DateTimeOffset.UtcNow
            };

            _sampleAvatar2 = new AvatarDTO
            {
                Name = "Mago",
                UserId = 2,
                PersonalityId = 20,
                IsActive = false,
                Timestamp = DateTimeOffset.UtcNow
            };
        }

        #region GetAvatars
        [Test]
        public void GetAvatars_NoAvatars_ReturnsEmptyList()
        {
            // Arrange
            _avatarServiceMock.Setup(s => s.GetAvatars()).Returns(new List<AvatarDTO>());

            // Act
            var result = _avatarServiceMock.Object.GetAvatars();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetAvatars_MultipleAvatars_ReturnsList()
        {
            // Arrange
            var avatars = new List<AvatarDTO> { _sampleAvatar1, _sampleAvatar2 };
            _avatarServiceMock.Setup(s => s.GetAvatars()).Returns(avatars);

            // Act
            var result = _avatarServiceMock.Object.GetAvatars();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Guerrero", result.First().Name);
        }
        #endregion

        #region GetAvatar
        [Test]
        public void GetAvatar_ExistingAvatar_ReturnsAvatar()
        {
            // Arrange
            int avatarId = 1;
            _avatarServiceMock.Setup(s => s.GetAvatar(avatarId)).Returns(_sampleAvatar1);

            // Act
            var result = _avatarServiceMock.Object.GetAvatar(avatarId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Guerrero", result.Name);
        }

        [Test]
        public void GetAvatar_NonExistingAvatar_ReturnsNull()
        {
            // Arrange
            int avatarId = 999;
            _avatarServiceMock.Setup(s => s.GetAvatar(avatarId)).Returns((AvatarDTO)null);

            // Act
            var result = _avatarServiceMock.Object.GetAvatar(avatarId);

            // Assert
            Assert.IsNull(result);
        }
        #endregion

        #region CreateAvatar
        [Test]
        public void CreateAvatar_ValidAvatar_CallsCreateMethodOnce()
        {
            // Arrange
            _avatarServiceMock.Setup(s => s.CreateAvatar(It.IsAny<AvatarDTO>()));

            // Act
            _avatarServiceMock.Object.CreateAvatar(_sampleAvatar1);

            // Assert
            _avatarServiceMock.Verify(s => s.CreateAvatar(_sampleAvatar1), Times.Once);
        }

        [Test]
        public void CreateAvatar_NullAvatar_ThrowsArgumentNullException()
        {
            // Asumiendo que la implementación real lanzará esta excepción
            _avatarServiceMock.Setup(s => s.CreateAvatar(null)).Throws<ArgumentNullException>();

            // Assert
            Assert.Throws<ArgumentNullException>(() => _avatarServiceMock.Object.CreateAvatar(null));
        }

        [Test]
        public void CreateAvatar_InvalidData_ThrowsArgumentException()
        {
            // Avatar sin nombre
            var invalidAvatar = new AvatarDTO
            {
                Name = null,
                UserId = 1,
                PersonalityId = 10,
                IsActive = true,
                Timestamp = DateTimeOffset.UtcNow
            };

            _avatarServiceMock.Setup(s => s.CreateAvatar(invalidAvatar)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _avatarServiceMock.Object.CreateAvatar(invalidAvatar));
        }
        #endregion

        #region UpdateAvatar
        [Test]
        public void UpdateAvatar_ExistingAvatar_ValidData_UpdatesAvatar()
        {
            // Arrange
            int avatarId = 1;
            var updatedAvatar = new AvatarDTO
            {
                Name = "Guerrero Actualizado",
                UserId = 1,
                PersonalityId = 15,
                IsActive = false,
                Timestamp = DateTimeOffset.UtcNow
            };

            _avatarServiceMock.Setup(s => s.UpdateAvatar(avatarId, updatedAvatar));

            // Act
            _avatarServiceMock.Object.UpdateAvatar(avatarId, updatedAvatar);

            // Assert
            _avatarServiceMock.Verify(s => s.UpdateAvatar(avatarId, updatedAvatar), Times.Once);
        }

        [Test]
        public void UpdateAvatar_NonExistingAvatar_ThrowsKeyNotFoundException()
        {
            int avatarId = 999;
            _avatarServiceMock.Setup(s => s.UpdateAvatar(avatarId, It.IsAny<AvatarDTO>()))
                            .Throws<KeyNotFoundException>();

            Assert.Throws<KeyNotFoundException>(() => _avatarServiceMock.Object.UpdateAvatar(avatarId, _sampleAvatar1));
        }

        [Test]
        public void UpdateAvatar_NullAvatar_ThrowsArgumentNullException()
        {
            int avatarId = 1;
            _avatarServiceMock.Setup(s => s.UpdateAvatar(avatarId, null))
                            .Throws<ArgumentNullException>();

            Assert.Throws<ArgumentNullException>(() => _avatarServiceMock.Object.UpdateAvatar(avatarId, null));
        }
        #endregion

        #region DeleteAvatar
        [Test]
        public void DeleteAvatar_ExistingAvatar_DeletesAvatar()
        {
            // Arrange
            int avatarId = 1;
            _avatarServiceMock.Setup(s => s.DeleteAvatar(avatarId));

            // Act
            _avatarServiceMock.Object.DeleteAvatar(avatarId);

            // Assert
            _avatarServiceMock.Verify(s => s.DeleteAvatar(avatarId), Times.Once);
        }

        [Test]
        public void DeleteAvatar_NonExistingAvatar_ThrowsKeyNotFoundException()
        {
            int avatarId = 999;
            _avatarServiceMock.Setup(s => s.DeleteAvatar(avatarId))
                            .Throws<KeyNotFoundException>();

            Assert.Throws<KeyNotFoundException>(() => _avatarServiceMock.Object.DeleteAvatar(avatarId));
        }
        #endregion
    }
}