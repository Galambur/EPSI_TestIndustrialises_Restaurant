using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Serveur
    {
        private readonly IList<Commande> _commandes;

        public Serveur()
        {
            this._commandes = new List<Commande>();
        }

        public Serveur(IList<Commande> commandes)
        {
            this._commandes = commandes;
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

        public IList<Commande> GetCommandes()
        {
            return _commandes;
        }
    }
}
