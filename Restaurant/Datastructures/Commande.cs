using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Commande
    {
        private double _montant;
        private IList<Plat> _listePlat;

        public Commande(double montant)
        {
            this._montant = montant;
        }

        public double getMontant()
        {
            return this._montant;
        }
        public void setListPLat(IList<Plat> plats)
        {
            this._listePlat = plats;
        }
        public IList<Plat> getListePlats()
        {
            return this._listePlat;
        } 
    }
}
