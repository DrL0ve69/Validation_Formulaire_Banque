using System.ComponentModel.DataAnnotations;

namespace Validation_Formulaire_Banque.Models;

public class CompteClient : IValidatableObject
{
    private List<ValidationResult> _validationResults = new List<ValidationResult>();

    private static int _numCompte = 1000;
    public int NumCompte = _numCompte++;

    [Required(ErrorMessage =
    "Le champ Nom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
    "Le champ Nom doit commencer par une majuscule et contenir uniquement des lettres.")]
    public string Nom { get; set; }
    [Required(ErrorMessage =
    "Le champ Prénom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
    "Le champ Prénom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [Display(Name = "Prénom")]
    public string Prenom { get; set; }
    [Display(Name = "Date de naissance")]
    [Required(ErrorMessage = "Vous devez indiquer vôtre date de naissance")]
    public DateOnly DateNaissance { get; set; }

    [Display(Name = "Téléphone")]
    public string Telephone { get; set; }
    public string Adresse { get; set; }

    [Display(Name = "Code postal")]
    public string CodePostal { get; set; }
    public string Employeur { get; set; }
    public decimal Salaire { get; set; }

    [Display(Name = "Dépôt Initial")]
    public decimal DepotInitial { get; set; }
    public CompteClient() {  }
    public CompteClient(string nom, string prenom, DateOnly dateNaissance,string telephone, string adresse, string codePostal, string employeur, decimal salaire, decimal depotInitial)
    {
        
        Nom = nom;
        Prenom = prenom;
        DateNaissance = dateNaissance;
        Telephone = telephone;
        Adresse = adresse;
        CodePostal = codePostal;
        Employeur = employeur;
        Salaire = salaire;
        DepotInitial = depotInitial;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return _validationResults;
    }
}
