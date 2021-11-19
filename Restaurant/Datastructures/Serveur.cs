using System;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Serveur
    {

        private readonly List<Commande> _commandes;

        public Serveur()
        {

        }

        public double getChiffreDAffaire()
        {
            double chiffreDaffaire = 0;
            foreach(var commande in _commandes)
            {
                chiffreDaffaire = chiffreDaffaire + commande.montant;
            }
            return chiffreDaffaire;
        }

        public void prendCommande(Commande commande)
        {
            this._commandes.Add(commande);
        }
    }
}
