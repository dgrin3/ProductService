using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Dto.Product
{
    public class ChangeProductValidator : AbstractValidator<ChangeProductCommand>
    {
        public ChangeProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Für ein Produkt ist ein Id erforderlich");
            RuleFor(p => p.Name.Length)
                .GreaterThan(5)
                .WithMessage("Der Produktname muss mehr als fünf Zeichen enthalten");
            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Der Produktpreis muss > 0 sein");
            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .WithMessage("Ein Produkt muss einer Kategorie zugeordnet sein");
        }
    }
}
