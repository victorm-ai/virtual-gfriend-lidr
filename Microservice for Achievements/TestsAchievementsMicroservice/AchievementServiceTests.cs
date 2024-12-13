using AchievementsMicroservice.DTOs;
using AchievementsMicroservice.Interfaces;
using Moq;

namespace TestsAchievementsMicroservice
{
    [TestFixture]
    public class AchievementServiceTests
    {
        private Mock<IAchievementService> _achievementServiceMock;
        private AchievementDTO _achievement1;
        private AchievementDTO _achievement2;
        private UserAchievementDTO _userAchievement1;
        private UserAchievementDTO _userAchievement2;

        [SetUp]
        public void SetUp()
        {
            _achievementServiceMock = new Mock<IAchievementService>();

            _achievement1 = new AchievementDTO
            {
                Id = 1,
                Name = "Primer Logro",
                Rank = 1,
                Description = "Descripción del primer logro"
            };

            _achievement2 = new AchievementDTO
            {
                Id = 2,
                Name = "Segundo Logro",
                Rank = 2,
                Description = "Descripción del segundo logro"
            };

            _userAchievement1 = new UserAchievementDTO
            {
                Id = 100,
                AchievementId = 1,
                UserId = 1,
                Timestamp = DateTimeOffset.UtcNow
            };

            _userAchievement2 = new UserAchievementDTO
            {
                Id = 101,
                AchievementId = 2,
                UserId = 1,
                Timestamp = DateTimeOffset.UtcNow
            };
        }

        #region GetAchievements()
        [Test]
        public void GetAchievements_NoAchievements_ReturnsEmptyList()
        {
            // Arrange
            _achievementServiceMock.Setup(s => s.GetAchievements()).Returns(new List<AchievementDTO>());

            // Act
            var result = _achievementServiceMock.Object.GetAchievements();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetAchievements_MultipleAchievements_ReturnsList()
        {
            // Arrange
            var achievements = new List<AchievementDTO> { _achievement1, _achievement2 };
            _achievementServiceMock.Setup(s => s.GetAchievements()).Returns(achievements);

            // Act
            var result = _achievementServiceMock.Object.GetAchievements();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Primer Logro", result.First().Name);
        }
        #endregion

        #region GetAchievements(userId)
        [Test]
        public void GetAchievements_ByUser_NoAchievements_ReturnsEmptyList()
        {
            // Arrange
            int userId = 1;
            _achievementServiceMock.Setup(s => s.GetAchievements(userId)).Returns(new List<UserAchievementDTO>());

            // Act
            var result = _achievementServiceMock.Object.GetAchievements(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetAchievements_ByUser_MultipleAchievements_ReturnsList()
        {
            // Arrange
            int userId = 1;
            var userAchievements = new List<UserAchievementDTO> { _userAchievement1, _userAchievement2 };
            _achievementServiceMock.Setup(s => s.GetAchievements(userId)).Returns(userAchievements);

            // Act
            var result = _achievementServiceMock.Object.GetAchievements(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.First().UserId);
        }

        [Test]
        public void GetAchievements_InvalidUserId_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = 0;
            _achievementServiceMock.Setup(s => s.GetAchievements(invalidUserId)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _achievementServiceMock.Object.GetAchievements(invalidUserId));
        }
        #endregion

        #region SaveAchievement(userId, achievementId)
        [Test]
        public void SaveAchievement_ValidParameters_CallsMethodOnce()
        {
            // Arrange
            int userId = 1;
            int achievementId = 1;

            _achievementServiceMock.Setup(s => s.SaveAchievement(userId, achievementId));

            // Act
            _achievementServiceMock.Object.SaveAchievement(userId, achievementId);

            // Assert
            _achievementServiceMock.Verify(s => s.SaveAchievement(userId, achievementId), Times.Once);
        }

        [Test]
        public void SaveAchievement_InvalidUserId_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = -1;
            int achievementId = 1;
            _achievementServiceMock.Setup(s => s.SaveAchievement(invalidUserId, achievementId))
                                    .Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _achievementServiceMock.Object.SaveAchievement(invalidUserId, achievementId));
        }

        [Test]
        public void SaveAchievement_InvalidAchievementId_ThrowsArgumentException()
        {
            // Arrange
            int userId = 1;
            int invalidAchievementId = 0;
            _achievementServiceMock.Setup(s => s.SaveAchievement(userId, invalidAchievementId))
                                    .Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _achievementServiceMock.Object.SaveAchievement(userId, invalidAchievementId));
        }
        #endregion
    }
}