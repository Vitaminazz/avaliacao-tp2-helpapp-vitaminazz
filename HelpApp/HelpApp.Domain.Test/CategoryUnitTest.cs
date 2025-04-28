using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Read Category With Valid State")]

        public void ReadCategory_WithValidParameters_ResultObjectValidState()
        {
            var category = new Category(1, "Category Vitas");

            Action action = () => category.Id.Should().Be(1);
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

            Action actionName = () => category.Name.Should().Be("Category Vitas");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Category With Valid State")]

        public void UpdateCategory_WithValidParameters_ResultObjectValidState()
        {
            var category = new Category(1, "Categoria");
            Action action = () => category.Update("Categoria2");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
            category.Name.Should().Be("Categoria2");

        }

        [Fact(DisplayName = "Delete Category With Valid State")]

        public void DeleteCategory_WithValidParameters_ResultObjectDeleted()
        {
            var category = new Category(1, "Categoria");

            Action action = () => { category = null; };
            action.Should().NotThrow<Exception>();

            category.Should().BeNull();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName ="Create Category With Name Empty")]
        public void CreateCategory_WithNameEmpty_ResultObjetcException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        #endregion
    }
}
