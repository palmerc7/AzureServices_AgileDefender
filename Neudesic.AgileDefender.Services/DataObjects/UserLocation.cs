using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neudesic.AgileDefender.Services.DataObjects
{
    public class UserLocation: BaseClass
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
