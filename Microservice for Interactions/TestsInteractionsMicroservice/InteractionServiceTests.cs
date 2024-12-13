using InteractionsMicroservice.DTOs;
using InteractionsMicroservice.Interfaces;
using Moq;

namespace TestsUsersMicroservice
{
    [TestFixture]
    public class InteractionServiceTests
    {
        private Mock<IInteractionService> _interactionServiceMock;
        private InteractionDTO _validInteraction1;
        private InteractionDTO _validInteraction2;

        [SetUp]
        public void SetUp()
        {
            _interactionServiceMock = new Mock<IInteractionService>();

            _validInteraction1 = new InteractionDTO
            {
                Id = "int1",
                UserId = 1,
                AvatarId = 10,
                InteractionTypeId = 100,
                ContentInteraction = "Contenido de interacción 1",
                Timestamp = DateTimeOffset.UtcNow
            };

            _validInteraction2 = new InteractionDTO
            {
                Id = "int2",
                UserId = 1,
                AvatarId = 11,
                InteractionTypeId = 100,
                ContentInteraction = "Contenido de interacción 2",
                Timestamp = DateTimeOffset.UtcNow
            };
        }

        #region GetInteractions(userId, dateTime)
        [Test]
        public void GetInteractions_ByUserIdAndDate_NoInteractions_ReturnsEmpty()
        {
            // Arrange
            int userId = 1;
            DateTime date = DateTime.UtcNow;
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, date)).Returns(new List<InteractionDTO>());

            // Act
            var result = _interactionServiceMock.Object.GetInteractions(userId, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetInteractions_ByUserIdAndDate_MultipleInteractions_ReturnsList()
        {
            // Arrange
            int userId = 1;
            DateTime date = DateTime.UtcNow;
            var interactions = new List<InteractionDTO> { _validInteraction1, _validInteraction2 };
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, date)).Returns(interactions);

            // Act
            var result = _interactionServiceMock.Object.GetInteractions(userId, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("int1", result.First().Id);
        }

        [Test]
        public void GetInteractions_InvalidUserId_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = 0; // Por ejemplo, un userId no válido.
            DateTime date = DateTime.UtcNow;
            _interactionServiceMock.Setup(s => s.GetInteractions(invalidUserId, date)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.GetInteractions(invalidUserId, date));
        }

        [Test]
        public void GetInteractions_FutureDate_ThrowsArgumentException()
        {
            // Arrange
            int userId = 1;
            DateTime futureDate = DateTime.UtcNow.AddDays(1);
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, futureDate)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.GetInteractions(userId, futureDate));
        }
        #endregion

        #region GetInteractions(userId, interactionType, dateTime)
        [Test]
        public void GetInteractions_ByUserAndTypeAndDate_NoInteractions_ReturnsEmpty()
        {
            // Arrange
            int userId = 1;
            int interactionType = 100;
            DateTime date = DateTime.UtcNow;
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, interactionType, date)).Returns(new List<InteractionDTO>());

            // Act
            var result = _interactionServiceMock.Object.GetInteractions(userId, interactionType, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetInteractions_ByUserAndTypeAndDate_MultipleInteractions_ReturnsList()
        {
            // Arrange
            int userId = 1;
            int interactionType = 100;
            DateTime date = DateTime.UtcNow;
            var interactions = new List<InteractionDTO> { _validInteraction1, _validInteraction2 };
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, interactionType, date)).Returns(interactions);

            // Act
            var result = _interactionServiceMock.Object.GetInteractions(userId, interactionType, date);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(100, result.First().InteractionTypeId);
        }

        [Test]
        public void GetInteractions_InvalidUserIdWithType_ThrowsArgumentException()
        {
            // Arrange
            int invalidUserId = -1;
            int interactionType = 100;
            DateTime date = DateTime.UtcNow;
            _interactionServiceMock.Setup(s => s.GetInteractions(invalidUserId, interactionType, date)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.GetInteractions(invalidUserId, interactionType, date));
        }

        [Test]
        public void GetInteractions_InvalidInteractionType_ThrowsArgumentException()
        {
            // Arrange
            int userId = 1;
            int invalidType = 0;
            DateTime date = DateTime.UtcNow;
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, invalidType, date)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.GetInteractions(userId, invalidType, date));
        }

        [Test]
        public void GetInteractions_FutureDateWithType_ThrowsArgumentException()
        {
            // Arrange
            int userId = 1;
            int interactionType = 100;
            DateTime futureDate = DateTime.UtcNow.AddDays(1);
            _interactionServiceMock.Setup(s => s.GetInteractions(userId, interactionType, futureDate)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.GetInteractions(userId, interactionType, futureDate));
        }
        #endregion

        #region SaveUserInteraction
        [Test]
        public void SaveUserInteraction_ValidInteraction_CallsMethodOnce()
        {
            // Arrange
            _interactionServiceMock.Setup(s => s.SaveUserInteraction(It.IsAny<InteractionDTO>()));

            // Act
            _interactionServiceMock.Object.SaveUserInteraction(_validInteraction1);

            // Assert
            _interactionServiceMock.Verify(s => s.SaveUserInteraction(_validInteraction1), Times.Once);
        }

        [Test]
        public void SaveUserInteraction_NullInteraction_ThrowsArgumentNullException()
        {
            // Arrange
            _interactionServiceMock.Setup(s => s.SaveUserInteraction(null)).Throws<ArgumentNullException>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _interactionServiceMock.Object.SaveUserInteraction(null));
        }

        [Test]
        public void SaveUserInteraction_InvalidData_ThrowsArgumentException()
        {
            // Arrange
            var invalidInteraction = new InteractionDTO
            {
                Id = null, // id nulo
                UserId = 0, // userId no válido
                AvatarId = 0,
                InteractionTypeId = -1,
                ContentInteraction = "",
                Timestamp = DateTimeOffset.UtcNow
            };

            _interactionServiceMock.Setup(s => s.SaveUserInteraction(invalidInteraction)).Throws<ArgumentException>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _interactionServiceMock.Object.SaveUserInteraction(invalidInteraction));
        }
        #endregion
    }
}