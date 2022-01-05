using NUnit.Framework;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Commande
    {
        private double _montant;
        private List<Commande> commandes;
        private Serveur serveur;

        public Commande(double montant)
        {
            this._montant = montant;
        }

        public Commande(List<Commande> commandes, Serveur serveur)
        {
            this.commandes = commandes;
            this.serveur = serveur;
        }

        public double getMontant()
        {
            return this._montant;
        }
    }
}
