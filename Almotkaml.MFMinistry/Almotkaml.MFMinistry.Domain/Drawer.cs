using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class Drawer //الأدراج
    {
        public static Drawer New(string drawerNumber)
        {
            Check.NotEmpty(drawerNumber, nameof(drawerNumber));

            var Drawer = new Drawer()
            {
                DrawerNumber = drawerNumber,
            };


            return Drawer;
        }

        private Drawer()
        {

        }

        public int DrawerId { get; private set; }
        public string DrawerNumber { get; private set; }
        public ICollection<FormsMFM> FormsMFM { get; set; } = new HashSet<FormsMFM>();
        public void Modify(string drawerNumber)
        {
            Check.NotEmpty(drawerNumber, nameof(drawerNumber));

            DrawerNumber = drawerNumber;

        }
    }
}
