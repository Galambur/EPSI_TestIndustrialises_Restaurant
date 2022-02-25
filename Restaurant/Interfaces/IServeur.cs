using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
	interface IServeur
	{
    public IList<Commande> Commandes { get; set; }

    public double getChiffreDAffaire();

    public void PrendCommande(Commande commande);

    public IList<Commande> GetCommandes();
  }
}
