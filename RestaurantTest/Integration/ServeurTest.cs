using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTest.Unit
{
	using global::LeGrandRestaurantTest;
	using LeGrandRestaurant;
  using NUnit.Framework;
  using System.Linq;

  namespace LeGrandRestaurantTest
  {
    [TestFixture]
    public partial class ServeurTest
    {

      [Test]
      public void GetServeurChiffreDAffaire_ReturnsZero()
      {
        // etant donné un nouveau serveur
        var serveur = new DB_Serveur("tprenom","tnom");
        var serveurInserted = DB_Serveur.InsertServeur(serveur);


        // quand on récupère son chiffre d'affaire
        var chiffreAffaire = serveur.getChiffreDAffaire();

        // alors celui ci est a 0
        Assert.That(chiffreAffaire, Is.EqualTo(0));
      }

      [Test]
      public void ServeurGetCommande_GetChiffreDAffaireReturnsCommande()
      {
        // etant donné un nouveau serveur
        var serveur = new ServeurBuilder().Build();

        // quand il prend une commande 
        var commande = new Commande(20);
        serveur.PrendCommande(commande);

        // alors son chiffre d'affaire est le montant de celle-ci
        Assert.That(serveur.getChiffreDAffaire(), Is.EqualTo(commande.getMontant()));
      }

    }
  }

}
