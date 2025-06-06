namespace Validation_Formulaire_Banque.Models.ViewModels;

public static class DB_ComptesClients
{
    public static List<CompteClient> ListeComptesClients { get; set; } = new List<CompteClient>() 
    {
        /*
        new CompteClient("Raymond", "Jean", new(1960,07,07), "819-979-6969", "420 rue des Fleurs, Hull, Québec", "J8J 3G7", "PopcornPlayer.com", 420_069.69m, 420.69m),
        new CompteClient("Dupont", "Marie", new(1985,01,15), "514-123-4567", "123 rue Principale, Montréal, Québec", "H1A 2B3", "TechSolutions Inc.", 3500.00m, 500.00m),
        new CompteClient("Martin", "Sophie", new(1990,05,20), "418-987-6543", "456 avenue des Érables, Québec, Québec", "G1B 4C5", "École de Programmation", 2800.00m, 1000.00m),
        new CompteClient("Lefebvre", "Paul", new(1975,11,30), "450-555-1234", "789 boulevard des Acacias, Laval, Québec", "H7N 3M2", "Banque de Laval", 5000.00m, 1500.00m),
        new CompteClient("Gagnon", "Émilie", new(1988,03,10), "819-555-7890", "321 rue des Pins, Gatineau, Québec", "J9E 5H6", "Consultant Freelance", 3200.00m, 800.00m)
        */
    };
    public static void AjouterCompte(CompteClient compte)
    {
        ListeComptesClients.Add(compte);
    }
    public static void SupprimerCompte(CompteClient compte)
    {
        ListeComptesClients.Remove(compte);
    }

}
