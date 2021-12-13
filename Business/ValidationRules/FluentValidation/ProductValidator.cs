using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty(); // productName boş olamaz
            RuleFor(p => p.ProductName).Length(2, 30); // 2 ila 30 karakter arasında olabilir.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1); // unitprice min 1 olabilir
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1); // categoryIdsi 1 olan ürünün unitPrice si en az 10 olabilir.
            RuleFor(p => p.ProductName).Must(StartWithWithA); // kuralını kendimiz aşağıda metod halinde yazdık
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A"); // A ile başlamak zorundadır.
        }
    }
}
