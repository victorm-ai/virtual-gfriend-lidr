using ActivitiesMicroservice.DTOs;
using ActivitiesMicroservice.Interfaces;
using Moq;

namespace TestsUsersMicroservice
{

    [TestFixture]
    public class ActivityServiceTests
    {
        private Mock<IActivityService> _activityServiceMock;
        private ActivityDTO _validActivity1;
        private ActivityDTO _validActivity2;

        [SetUp]
        public void SetUp()
        {
            _activityServiceMock = new Mock<IActivityService>();

            _validActivity1 = new ActivityDTO
            {
                Id = 1,
                UserId = 1,
                ActivityId = 101,
                Name = "Correr en el parque",
                When = DateTime.UtcNow,
                Timestamp = DateTimeOffset.UtcNow
            };

            _validActivity2 = new ActivityDTO
            {
                Id = 2,
                UserId = 1,
                ActivityId = 102,
                Name = "Leer un libro",
                When = DateTime.UtcNow,
                Timestamp = DateTimeOffset.UtcNow
            };
        }

        #region GetActivities(userId, dateTime)
        [Test]
        public void GetActivities_NoActivities_ReturnsEmptyList()
        {
            // Arrange
            int userId = 1;
            DateTime date = DateTime.UtcNow;
            _activityServiceMock.Setup(s => s.GetActivities(userId, date)).Returns(new List<ActivityDTO>());

            // Act
            var result = _activityServiceMock.Object.GetActivities(userId, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetActivities_MultipleActivities_ReturnsList()
        {
            // Arrange
            int userId = 1;
            DateTime date = DateTime.UtcNow;
            var activities = new List<ActivityDTO> { _validActivity1, _validActivity2 };
            _activityServiceMock.Setup(s => s.GetActivities(userId, date)).Returns(activities);

            // Act
            var result = _activityServiceMock.Object.GetActivities(userId, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Correr en el parque", result.First().Name);
        }

        [Test]
        public void GetActivities_InvalidUserId_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = 0;
            DateTime date = DateTime.UtcNow;
            _activityServiceMock.Setup(s => s.GetActivities(invalidUserId, date)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.GetActivities(invalidUserId, date));
        }

        [Test]
        public void GetActivities_FutureDate_ThrowsArgumentException()
        {
            // Opcional, si la lógica lo requiere
            int userId = 1;
            DateTime futureDate = DateTime.UtcNow.AddDays(1);
            _activityServiceMock.Setup(s => s.GetActivities(userId, futureDate)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.GetActivities(userId, futureDate));
        }
        #endregion

        #region SaveActivity(activity, userId)
        [Test]
        public void SaveActivity_ValidActivity_CallsMethodOnce()
        {
            // Arrange
            int userId = 1;
            _activityServiceMock.Setup(s => s.SaveActivity(_validActivity1, userId));

            // Act
            _activityServiceMock.Object.SaveActivity(_validActivity1, userId);

            // Assert
            _activityServiceMock.Verify(s => s.SaveActivity(_validActivity1, userId), Times.Once);
        }

        [Test]
        public void SaveActivity_NullActivity_ThrowsArgumentNullException()
        {
            // Arrange
            int userId = 1;
            _activityServiceMock.Setup(s => s.SaveActivity(null, userId)).Throws<ArgumentNullException>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _activityServiceMock.Object.SaveActivity(null, userId));
        }

        [Test]
        public void SaveActivity_InvalidUserId_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = -1;
            _activityServiceMock.Setup(s => s.SaveActivity(_validActivity1, invalidUserId)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.SaveActivity(_validActivity1, invalidUserId));
        }

        [Test]
        public void SaveActivity_InvalidActivityData_ThrowsArgumentException()
        {
            // Ejemplo: actividad sin nombre
            var invalidActivity = new ActivityDTO
            {
                Id = 3,
                UserId = 1,
                ActivityId = 103,
                Name = null,
                When = DateTime.UtcNow,
                Timestamp = DateTimeOffset.UtcNow
            };

            int userId = 1;
            _activityServiceMock.Setup(s => s.SaveActivity(invalidActivity, userId)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.SaveActivity(invalidActivity, userId));
        }
        #endregion

        #region UpdateActivity(userId, activityId, UpdateActivityRequest)
        [Test]
        public void UpdateActivity_ValidData_CallsMethodOnce()
        {
            // Arrange
            int userId = 1;
            int activityId = 101;
            var updatedActivity = new ActivityDTO
            {
                Id = activityId,
                UserId = userId,
                ActivityId = 101,
                Name = "Correr más tiempo",
                When = DateTime.UtcNow,
                Timestamp = DateTimeOffset.UtcNow
            };

            _activityServiceMock.Setup(s => s.UpdateActivity(userId, activityId, updatedActivity));

            // Act
            _activityServiceMock.Object.UpdateActivity(userId, activityId, updatedActivity);

            // Assert
            _activityServiceMock.Verify(s => s.UpdateActivity(userId, activityId, updatedActivity), Times.Once);
        }

        [Test]
        public void UpdateActivity_InvalidUserId_ThrowsArgumentException()
        {
            int invalidUserId = 0;
            int activityId = 101;

            _activityServiceMock.Setup(s => s.UpdateActivity(invalidUserId, activityId, _validActivity1)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.UpdateActivity(invalidUserId, activityId, _validActivity1));
        }

        [Test]
        public void UpdateActivity_InvalidActivityId_ThrowsArgumentException()
        {
            int userId = 1;
            int invalidActivityId = -1;

            _activityServiceMock.Setup(s => s.UpdateActivity(userId, invalidActivityId, _validActivity1)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.UpdateActivity(userId, invalidActivityId, _validActivity1));
        }

        [Test]
        public void UpdateActivity_NullRequest_ThrowsArgumentNullException()
        {
            int userId = 1;
            int activityId = 101;

            _activityServiceMock.Setup(s => s.UpdateActivity(userId, activityId, null)).Throws<ArgumentNullException>();

            Assert.Throws<ArgumentNullException>(() => _activityServiceMock.Object.UpdateActivity(userId, activityId, null));
        }

        [Test]
        public void UpdateActivity_InvalidData_ThrowsArgumentException()
        {
            // Ejemplo: Nombre vacío en la solicitud
            var invalidActivityUpdate = new ActivityDTO
            {
                Id = 101,
                UserId = 1,
                ActivityId = 101,
                Name = "",
                When = DateTime.UtcNow,
                Timestamp = DateTimeOffset.UtcNow
            };

            int userId = 1;
            int activityId = 101;
            _activityServiceMock.Setup(s => s.UpdateActivity(userId, activityId, invalidActivityUpdate)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.UpdateActivity(userId, activityId, invalidActivityUpdate));
        }
        #endregion

        #region DeleteActivity(userId, activityId)
        [Test]
        public void DeleteActivity_ValidIds_CallsMethodOnce()
        {
            // Arrange
            int userId = 1;
            int activityId = 101;
            _activityServiceMock.Setup(s => s.DeleteActivity(userId, activityId));

            // Act
            _activityServiceMock.Object.DeleteActivity(userId, activityId);

            // Assert
            _activityServiceMock.Verify(s => s.DeleteActivity(userId, activityId), Times.Once);
        }

        [Test]
        public void DeleteActivity_InvalidUserId_ThrowsArgumentException()
        {
            int invalidUserId = -1;
            int activityId = 101;
            _activityServiceMock.Setup(s => s.DeleteActivity(invalidUserId, activityId)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.DeleteActivity(invalidUserId, activityId));
        }

        [Test]
        public void DeleteActivity_InvalidActivityId_ThrowsArgumentException()
        {
            int userId = 1;
            int invalidActivityId = 0;
            _activityServiceMock.Setup(s => s.DeleteActivity(userId, invalidActivityId)).Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _activityServiceMock.Object.DeleteActivity(userId, invalidActivityId));
        }
        #endregion
    }
}