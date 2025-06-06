using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Validation_Formulaire_Banque.Models.ViewModels;

public class ValidationCodePostalAttribute : ValidationAttribute, IClientValidatable
{
    public override bool IsValid(object value)
    {
        if (value == null) return true; // Laisse Required s’en charger
        var str = value.ToString();
        return str.Count() <= 7;
    }
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        yield return new ModelClientValidationRule
        {
            ValidationType = "validationcodepostal",
            ErrorMessage = FormatErrorMessage(metadata.DisplayName)

        };

    }
}
