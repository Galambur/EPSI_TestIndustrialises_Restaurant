using System;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Serveur
    {

        private readonly List<Commande> _commandes;

        public Serveur()
        {
            this._commandes = new List<Commande>();
        }

        public double getChiffreDAffaire()
        {
            double chiffreDaffaire = 0;
            foreach(var commande in _commandes)
            {
                chiffreDaffaire = chiffreDaffaire + commande.getMontant();
            }
            return chiffreDaffaire;
        }

        public void prendCommande(Commande commande)
        {
            this._commandes.Add(commande);
        }
    }
}
