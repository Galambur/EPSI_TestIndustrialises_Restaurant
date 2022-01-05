using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le_Grand_Restaurant
{
    public class Table
    {
        public bool EstLibre { get; private set; } = true;

        public void InstallerClient()
        {
            if (!EstLibre) throw new InvalidOperationException();
            EstLibre = false;
        }

        public void Libérer()
        {
            EstLibre = true;
        }
    }
}
