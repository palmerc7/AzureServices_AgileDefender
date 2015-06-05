using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neudesic.AgileDefender.Services.DataObjects;

namespace Neudesic.AgileDefender.Services.Processors
{
    public class UserProcessor
    {
        public User GetUserByEmail(string emailAddress)
        {
            // TODO returning fake data for now
            var user = new User
            {
                Name = "Chris Palmer",
                Email = "chris.palmer@neudesic.com",
                IsSuccess = true
            };

            return user;
        }
    }
}
