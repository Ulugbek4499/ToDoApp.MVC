using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem;
using Xunit;

namespace ToDoApp.UnitTests.ToDoItems
{
    public class CreateToDoItemCommandValidatorTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateToDoItemCommandValidator_IfTitleIsNullOrEmpty_ShouldThrowValidationException(string title)
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Title);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfTitleLengthIsMoreThan50_ShouldThrowValidationException()
        {
            // Arrange
            string title = new Faker().Random.String2(51);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Title);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfTitleLengthIsEqualTo50_ShouldSuccess()
        {
            // Arrange
            string title = new Faker().Random.String2(50);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateToDoItemCommandValidator_IfDescriptionIsNullOrEmpty_ShouldThrowValidationException(string description)
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = description,
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Description);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfDescriptionLengthIsMoreThan300_ShouldThrowValidationException()
        {
            // Arrange
            string description = new Faker().Random.String2(301);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample Title",
                Description = description,
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Description);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfDescriptionLengthIsEqualTo300_ShouldSuccess()
        {
            // Arrange
            string description = new Faker().Random.String2(300);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample Title",
                Description = description,
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateToDoItemCommandValidator_IfNoteIsNullOrEmpty_ShouldThrowValidationException(string note)
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = "Sample description",
                Note = note,
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Note);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfNoteLengthIsMoreThan300_ShouldThrowValidationException()
        {
            // Arrange
            string note = new Faker().Random.String2(301);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample Title",
                Description = "Sample Description",
                Note = note,
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Note);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfNoteLengthIsEqualTo300_ShouldSuccess()
        {
            // Arrange
            string note = new Faker().Random.String2(300);

            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample Title",
                Description = "Sample Description",
                Note = note,
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfDueDateIsDefault_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = default,
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.DueDate);
        }
        
        [Fact]
        public void CreateToDoItemCommandValidator_IfDueDateIsToday_ShouldSuccess()
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.Date,
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfToDoListIdIsDefault_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = default
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.ToDoListId);
        }

        [Fact]
        public void CreateToDoItemCommandValidator_IfToDoListIdIsGiven_ShouldSuccess()
        {
            // Arrange
            var validator = new CreateToDoItemCommandValidator();

            var createToDoItemCommand = new CreateToDoItemCommand()
            {
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(createToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
