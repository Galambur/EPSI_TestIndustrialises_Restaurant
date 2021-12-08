﻿using Xunit;
using LeGrandRestaurant;
using System.Collections.Generic;

namespace Text_xUnit_LeGranRestaurant
{
    
    class FranchiseTest
    {
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 0)]
        public void CheckChiffreDAffaireFranchise(int nbRestaurants, int nbServeurs, int montant)
        {
            // ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacun
            var restaurants = new List<Restaurant>();
            for(int i = 0; i < nbRestaurants; i++)
            {
                var restaurant = new Restaurant();
                for (int j = 0; j < nbServeurs; j++)
                {
                    var s = new Serveur();
                    restaurant.addServeur(s);
                }
                restaurants.Add(restaurant);
            }
            var franchise = new Franchise(restaurants);

            // QUAND tous les serveurs prennent une commande d'un montant Z
            foreach (Restaurant restaurant in franchise.getRestaurants())
            {
                foreach (Serveur serveur in restaurant.getServeurs())
                {
                    serveur.prendCommande(new Commande(montant));
                }
            }

            // ALORS le chiffre d'affaires de la franchise est X * Y * Z

            Assert.Equal(franchise.getChiffreDAffaire(), nbRestaurants * nbServeurs * montant);
        }
    }
}
