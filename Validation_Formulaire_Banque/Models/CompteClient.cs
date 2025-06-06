using System.ComponentModel.DataAnnotations;
using Validation_Formulaire_Banque.Models.ViewModels;

namespace Validation_Formulaire_Banque.Models;

public class CompteClient : IValidatableObject
{
    public List<ValidationResult> ValidationResults = new List<ValidationResult>();
    private static int _numCompte = 1000;
    public int NumCompte = _numCompte++;

    private Enums.Enums.EtatsMonde _etatMonde;
    public Enums.Enums.EtatsMonde EtatMonde 
    {
        get => _etatMonde;
        set 
        {
            _etatMonde = value;
        }
    }
    //public Enums.Enums.Regions RegionsQuebec {  get; set; }
    /*
     *     [EmailAddress(ErrorMessage = "Doit avoir le format email conventionnel.")]
     *     
     *     [DisplayFormat(DataFormatString = "{0:c}")]
     *     [DataType(DataType.Currency)]
     *     
     *     [DisplayFormat(DataFormatString = "{0:d}")]
     *     [DataType(DataType.Date)]
     */

    [Required(ErrorMessage =
    "Le champ Nom ne peut pas être vide.")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
    "Le champ Nom doit commencer par une majuscule et contenir uniquement des lettres.")]
    public string Nom { get; set; }
    [Required(ErrorMessage =
    "Le champ Prénom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
    "Le champ Prénom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [Display(Name = "Prénom")]
    public string Prenom { get; set; }

    private DateOnly _dateOnly;
    [Display(Name = "Date de naissance")]
    [Required(ErrorMessage = "Vous devez indiquer vôtre date de naissance")]
    public DateOnly DateNaissance 
    {
        get => _dateOnly;
        set 
        {
            if (DateOnly.FromDateTime(DateTime.UtcNow).Year - value.Year >= 18)
            {
                _dateOnly = value;
            }
            else ValidationResults.Add(new("Vous devez avoir 18 ans pour créer un compte", ["DateNaissance"]));
        }
    }

    [Display(Name = "Téléphone")]
    [Required(ErrorMessage = "Le champ téléphone ne peut pas être vide")]
    [Phone(ErrorMessage ="Doit convenir au format téléphone")]
    public string Telephone { get; set; }


    [Required(ErrorMessage = "Le champ adresse ne peut pas être vide")]
    public string Adresse { get; set; }

    [Display(Name = "Code postal")]
    [Required(ErrorMessage = "Le champ ne peut pas être vide ne peut pas être vide")]
    [ValidationCodePostal]
    public string CodePostal { get; set; }


    [Required(ErrorMessage ="Le champ employeur ne peut pas être vide")]
    public string Employeur { get; set; }
    [Range(1, double.MaxValue, ErrorMessage = "Entrez vôtre salaire avec virgule si décimal, doit être plus grand que 1")]
    public decimal? Salaire { get; set; }

    [Display(Name = "Dépôt Initial")]
    [Range(0, double.MaxValue, ErrorMessage = "Entrer un dépôt initial avec virgule si décimal. Si nul, entrez 0")]
    [DataType(DataType.Currency, ErrorMessage = "Erreur dans le type d'entrée")]
    [Required(ErrorMessage = "Si nul, entrez 0")]
    public decimal? DepotInitial { get; set; }
    /*
    public CompteClient() { }
    */
    /*
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
    */
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return ValidationResults;
    }
}
