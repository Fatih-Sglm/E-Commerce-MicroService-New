using Microsoft.AspNetCore.Mvc.ModelBinding;
using TechBuddy.Extension.Validation.Infrastructure.Models.ModelProviders;

namespace E_Commerce.CatalogService.Application.Models
{
    public class CustomeErrorProvider : IDefaultModelProvider
    {
        public object GetModel(ModelStateDictionary.ValueEnumerable modelStateValues)
        {
            return ResponseDto<NoContent>.Failed(modelStateValues.
                SelectMany(i => i.Errors).Select(i => string.Join(Environment.NewLine, i.ErrorMessage)).ToList());
        }
    }
}
