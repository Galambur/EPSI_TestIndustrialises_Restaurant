using LeGrandRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Text_xUnit_LeGranRestaurant
{
	  public class MenuTest
    {
        [Fact]
        public void CarteFranchise()
        {
            // ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant> { restaurant });

            // QUAND la franchise modifie le prix du plat
            var plat = new Plat();
            var prix = new decimal(12.50);
            franchise.fixerPrix(plat, prix);

            // ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            var nouveauPrix = restaurant.obtenirPrix(plat);
            Assert.Equal(nouveauPrix, prix);
        }

        [Fact]
        public void ConflitRestaurantFranchise()
        {
            //ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant>() { restaurant });
            var plat = new Plat();
            var prixPlat = new decimal(14.20);
            restaurant.fixerPrix(plat, prixPlat);

            //QUAND la franchise modifie le prix du plat
            var nouveauPrixPlat = new decimal(14.20);
            franchise.fixerPrix(plat, nouveauPrixPlat);

            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            var prixPlatActuel = restaurant.obtenirPrix(plat);
            Assert.Equal(prixPlatActuel, prixPlat);
        }

        [Fact]
        public void PlatsIdentiquesFranchiseRestaurant()
        {
            // ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var restaurant = new Restaurant();
            var franchise = new Franchise(new List<Restaurant>() { restaurant });
            var platRestaurant = new Plat();
            var prixPlatRestaurant = new decimal(14.20);
            restaurant.fixerPrix(platRestaurant, prixPlatRestaurant);

            // QUAND la franchise ajoute un nouveau plat
            var platFranchise = new Plat();
            var prixPlatFranchise = new decimal(21.3);
            franchise.fixerPrix(platFranchise, prixPlatFranchise);

            //ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise
            var prixRestaurantFinal = restaurant.obtenirPrix(platRestaurant);
            var prixFranchiseFinal = restaurant.obtenirPrix(platFranchise);
            Assert.Equal(prixPlatRestaurant, prixRestaurantFinal);
            Assert.Equal(prixPlatFranchise, prixFranchiseFinal);
            Assert.NotEqual(prixRestaurantFinal, prixFranchiseFinal);
        }
    }
}
