using System;
using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly List<Serveur> _serveurs;
        private readonly Table[] _tables;

        public Restaurant(params Table[] tables)
        {
            _tables = tables;
            _serveurs = new List<Serveur>();
        }

        public void addServeur(Serveur s)
        {
            _serveurs.Add(s);
        }

        public IEnumerable<Serveur> getServeurs()
        {
            return _serveurs;
        }

        public void debuterService()
        {

        }

        public bool estDisponible(Table table)
            => table.estLibre;

        public void TerminerService()
        {
            foreach (var table in _tables)
            {
                table.liberer();
            }
        }

        public IEnumerable<Table> rechercherTablesLibres()
        {
            return _tables.Where(m => m.estLibre);
        }
    }
}
