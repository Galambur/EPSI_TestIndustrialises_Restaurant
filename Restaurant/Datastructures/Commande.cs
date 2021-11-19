namespace LeGrandRestaurant
{
    public class Commande
    {
        private double _montant;

        public Commande(double montant)
        {
            this._montant = montant;
        }

        public double getMontant()
        {
            return this._montant;
        }
    }
}
