using Microsoft.AspNetCore.Mvc;
using Validation_Formulaire_Banque.Models;
using Validation_Formulaire_Banque.Models.ViewModels;

namespace Validation_Formulaire_Banque.Controllers;

public class AccueilController : Controller
{
    public List<CompteClient> ListeComptesClients => DB_ComptesClients.ListeComptesClients;
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CompteClient nouveauCompte) 
    {
        if (ModelState.IsValid)
        {
            // Ajouter le nouveau compte à la base de données
            DB_ComptesClients.AjouterCompte(nouveauCompte);
            return RedirectToAction("Details",nouveauCompte);
        }
        // Si le modèle n'est pas valide, retourner à la vue avec les erreurs
        return View("Index", nouveauCompte);
    }
    public IActionResult Details(CompteClient compte)
    {
        // Vérifier si le compte existe dans la base de données
        var compteTrouve = DB_ComptesClients.ListeComptesClients.FirstOrDefault(c => c.Nom == compte.Nom && c.Prenom == compte.Prenom && c.DateNaissance == compte.DateNaissance);
        if (compteTrouve != null)
        {
            return View(compteTrouve);
        }
        // Si le compte n'est pas trouvé, retourner une erreur 404
        return NotFound();
    }
    [HttpPost]
    public IActionResult Connecter(int numCompte)
    {
        var compte = DB_ComptesClients.ListeComptesClients.FirstOrDefault(c => c.NumCompte == numCompte);
        if (ModelState.IsValid && compte != null)
        {
            return RedirectToAction("Details", compte);
        }
        // Si le modèle n'est pas valide, retourner à la vue avec les erreurs
        return View("Index");
    }
}
