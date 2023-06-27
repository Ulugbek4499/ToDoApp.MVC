using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList;
using Xunit;

namespace ToDoApp.UnitTests.ToDoLists
{
    public class CreateToDoListCommandValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateToDoListCommandValidator_IfTextIsNullOrEmpty_ShouldThrowValidationException(string text)
        {
            //arrange
            var validator = new CreateToDoListCommandValidator();

            var createToDoListCommand = new CreateToDoListCommand()
            {
                Name = text
            };

            //act
            var result = validator.TestValidate(createToDoListCommand);

            //assert
            result.ShouldHaveValidationErrorFor(list => list.Name);
        }

        [Fact]
        public void CreateToDoListCommandValidator_IfTextLengthIsMoreThan51_ShouldThrowValidationException()
        {
            //arrange
            string text = new Faker().Random.String2(51);

            var validator = new CreateToDoListCommandValidator();

            var createToDoListCommand = new CreateToDoListCommand()
            {
                Name = text
            };


            //act
            var result = validator.TestValidate(createToDoListCommand);

            //assert
            result.ShouldHaveValidationErrorFor(list => list.Name);
        }

        [Fact]
        public void CreateToDoListCommandValidator_IfTextLengthIsEqualTo50_ShouldSuccess()
        {
            //arrange
            string text = new Faker().Random.String2(50);

            var validator = new CreateToDoListCommandValidator();

            var createToDoListCommand = new CreateToDoListCommand()
            {
                Name = text
            };


            //act
            var result = validator.TestValidate(createToDoListCommand);

            //assert
            result.IsValid.Should().BeTrue();
        }
    }
}
