using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Validation_Formulaire_Banque.Models.ViewModels;

public class ValidationDepotAttribute : ValidationAttribute, IClientValidatable
{
    public override bool IsValid(object value)
    {
        if (value == null) return true; // Laisse Required s’en charger
        return (decimal)value >= 0;
    }
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        yield return new ModelClientValidationRule
        {
            ValidationType = "validationdepotvalide",
            ErrorMessage = FormatErrorMessage(metadata.DisplayName)

        };

    }
}
