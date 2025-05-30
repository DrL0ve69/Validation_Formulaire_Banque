namespace Validation_Formulaire_Banque.Models;

public class CompteClient
{
    private static int _numCompte = 1000;
    public int NumCompte = _numCompte++;
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateOnly DateNaissance { get; set; }
    public string Telephone { get; set; }
    public string Adresse { get; set; }
    public string CodePostal { get; set; }
    public string Employeur { get; set; }
    public decimal Salaire { get; set; }
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
}
