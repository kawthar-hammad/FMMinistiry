using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Collections.Generic;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.Extensions
{
    public static class DrawerExtensions
    {
        public static IEnumerable<DrawerGridRow> ToGrid(this IEnumerable<Drawer> Drawers)
           => Drawers.Select(d => new DrawerGridRow()
           {
               DrawerId = d.DrawerId,
               DrawerNumber = d.DrawerNumber
           });
        public static IEnumerable<DrawerListItem> ToList(this IEnumerable<Drawer> Drawers)
            => Drawers.Select(d => new DrawerListItem()
            {
                DrawerNumber = d.DrawerNumber,
                DrawerId = d.DrawerId
            });
    }
}