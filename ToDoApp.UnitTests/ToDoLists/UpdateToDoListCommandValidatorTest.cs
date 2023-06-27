using Bogus;
using FluentAssertions;
using FluentValidation.TestHelper;
using ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList;
using Xunit;

namespace ToDoApp.UnitTests.ToDoLists
{
    public class UpdateToDoListCommandValidatorTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void UpdateToDoListCommandValidator_IfTextIsNullOrEmpty_ShouldThrowValidationException(string text)
        {
            //arrange
            var validator = new UpdateToDoListCommandValidator();

            var UpdateToDoListCommand = new UpdateToDoListCommand()
            {
                Name = text
            };

            //act
            var result = validator.TestValidate(UpdateToDoListCommand);

            //assert
            result.ShouldHaveValidationErrorFor(list => list.Name);
        }

        [Fact]
        public void UpdateToDoListCommandValidator_IfTextLengthIsMoreThan51_ShouldThrowValidationException()
        {
            //arrange
            string text = new Faker().Random.String2(51);

            var validator = new UpdateToDoListCommandValidator();

            var UpdateToDoListCommand = new UpdateToDoListCommand()
            {
                Name = text
            };


            //act
            var result = validator.TestValidate(UpdateToDoListCommand);

            //assert
            result.ShouldHaveValidationErrorFor(list => list.Name);
        }

        [Fact]
        public void UpdateToDoListCommandValidator_IfTextLengthIsEqualTo50_ShouldSuccess()
        {
            //arrange
            string text = new Faker().Random.String2(50);

            var validator = new UpdateToDoListCommandValidator();

            var UpdateToDoListCommand = new UpdateToDoListCommand()
            {
                Name = text
            };


            //act
            var result = validator.TestValidate(UpdateToDoListCommand);

            //assert
            result.IsValid.Should().BeTrue();
        }
    }
}
