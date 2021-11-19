namespace LeGrandRestaurant
{
    public class Commande
    {
        public int montant;

        public Commande(int montant)
        {
            this.montant = montant;
        }

        public int getMontant()
        {
            return this.montant;
        }

        public void setMontant(int montant)
        {
            this.montant = montant;
        }
    }
}
