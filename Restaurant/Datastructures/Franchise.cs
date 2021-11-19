using System;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        private readonly List<Restaurant> _restaurants;

        public Franchise(List<Restaurant> restaurants)
        {
            this._restaurants = restaurants;
        }

        public IEnumerable<Restaurant> getRestaurants()
        {
            return this._restaurants;
        }

        public double getChiffreDAffaire()
        {
            double chiffreDAffaire = 0;
            foreach(Restaurant restaurant in _restaurants)
            {
                foreach(Serveur serveur in restaurant.getServeurs())
                {
                    chiffreDAffaire = chiffreDAffaire + serveur.getChiffreDAffaire();
                }
            }
            return chiffreDAffaire;
        }
    }
}
