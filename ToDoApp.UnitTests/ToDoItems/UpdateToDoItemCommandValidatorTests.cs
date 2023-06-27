using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.UpdateToDoItem;
using Xunit;

namespace ToDoApp.UnitTests.ToDoItems
{
    public class UpdateToDoItemCommandValidatorTests
    {
        [Fact]
        public void UpdateToDoItemCommandValidator_IfIdIsNotEmpty_ShouldSuccess()
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void UpdateToDoItemCommandValidator_IfIdIsEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.Empty,
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateToDoItemCommandValidator_IfTitleIsNullOrEmpty_ShouldThrowValidationException(string title)
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Title);
        }

        [Fact]
        public void UpdateToDoItemCommandValidator_IfTitleLengthIsMoreThan50_ShouldThrowValidationException()
        {
            // Arrange
            string title = new Faker().Random.String2(51);

            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Title);
        }

        [Fact]
        public void UpdateToDoItemCommandValidator_IfTitleLengthIsEqualTo50_ShouldSuccess()
        {
            string title = new Faker().Random.String2(50);

            var validator = new UpdateToDoItemCommandValidator();

            var updateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(updateToDoItemCommand);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateToDoItemCommandValidator_IfDescriptionIsNullOrEmpty_ShouldThrowValidationException(string description)
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = "Sample title",
                Description = description,
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Description);
        }

        // Write similar tests for DescriptionLengthIsMoreThan50 and DescriptionLengthIsEqualTo50

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateToDoItemCommandValidator_IfNoteIsNullOrEmpty_ShouldThrowValidationException(string note)
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.Empty,
                Title = "Sample title",
                Description = "Sample description",
                Note = note,
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.Note);
        }

        [Fact]
        public void UpdateToDoItemCommandValidator_IfDueDateIsDefault_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = default,
                ToDoListId = Guid.NewGuid()
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.DueDate);
        }

        [Fact]
        public void UpdateToDoItemCommandValidator_IfToDoListIdIsDefault_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.NewGuid(),
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = default
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.ToDoListId);
        }


        [Fact]
        public void UpdateToDoItemCommandValidator_IfToDoListIdIsEmpty_ShouldThrowValidationException()
        {
            // Arrange
            var validator = new UpdateToDoItemCommandValidator();

            var UpdateToDoItemCommand = new UpdateToDoItemCommand()
            {
                Id = Guid.Empty,
                Title = "Sample title",
                Description = "Sample description",
                Note = "Sample note",
                DueDate = DateTime.Now.AddDays(1),
                ToDoListId = Guid.Empty
            };

            // Act
            var result = validator.TestValidate(UpdateToDoItemCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(item => item.ToDoListId);
        }
    }
}
