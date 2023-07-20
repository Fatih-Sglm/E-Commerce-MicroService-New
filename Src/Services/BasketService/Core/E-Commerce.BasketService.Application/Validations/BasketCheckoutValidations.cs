using E_Commerce.BasketService.Domain.Models;
using FluentValidation;

namespace E_Commerce.BasketService.Application.Validations
{
    public class BasketCheckoutValidations : AbstractValidator<BasketCheckout>
    {
        public BasketCheckoutValidations()
        {
            #region Adress
            RuleFor(i => i.City).NotNull().NotEmpty().WithMessage("Şehir boş geçilemez");
            RuleFor(i => i.Street).NotNull().NotEmpty().WithMessage("Mahalle boş geçilemez");
            RuleFor(i => i.State).NotNull().NotEmpty().WithMessage("ilçe boş geçilemez");
            RuleFor(i => i.Country).NotNull().NotEmpty().WithMessage("Ülke boş geçilemez");
            RuleFor(i => i.ZipCode).NotNull().NotEmpty().WithMessage("Cvc boş geçilemez");

            #endregion
            #region CredidCart
            RuleFor(i => i.CardNumber).NotEmpty().WithMessage("Posta No Boş Geçilemez").CreditCard().WithMessage("Geçersiz Kart Numarası");
            RuleFor(i => i.CardHolderName).NotNull().NotEmpty().WithMessage("Kart Üzerinde isim boş geçilemez");
            RuleFor(i => i.ExpirationMonth).NotNull().NotEmpty().WithMessage("Son tarih boş geçilemez")
               .Length(2).WithMessage("Ay kısmı 2 haneli olmak zorundadır. Lütfen Başına 0 koyarak tekrar deneyiniz");
            RuleFor(i => i.ExpirationYear).NotNull().NotEmpty().WithMessage("Son tarih boş geçilemez")
              .Length(2).WithMessage("yıl kısmı 2 haneli olmak zorundadır. Lütfen son iki haneyi giriniz");
            RuleFor(i => i.CardSecurityNumber).NotNull().NotEmpty().WithMessage("Cvc boş geçilemez").Length(3);
            #endregion
        }
    }
}
