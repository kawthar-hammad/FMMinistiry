using Almotkaml.MFMinistry.Domain.TrainingCenterFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almotkaml.MFMinistry.Domain
{
    public class Corporation
    {
        public static INameHolder New()
        {
            return new CorporationBuilder();
        }
        public int CorporationId { get; internal set; }
        public string Name { get; internal set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
        public string Address { get; internal set; }
        public int CityId { get; internal set; }
        public City City { get; internal set; }
        public string Note { get; internal set; }
        //public DonorFoundationType DonorFoundationType { get; internal set; }// نوع الجهة المانحة
        public CorporationModifier Modify()
        {
            return new CorporationModifier(this);
        }
    }
}
