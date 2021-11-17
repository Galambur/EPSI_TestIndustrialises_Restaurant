using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private int nombreServeurs;
        private Table table;
        public Restaurant(int nbServeurs, Table t = null)
        {
            this.nombreServeurs = nbServeurs;
            if (t != null)
                this.table = t;
        }

        public void debuterService()
        {

        }

        public Boolean estDisponible(Table table)
        {
            return true;
        }
    }
}
