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
            var user = new User();
            try
            {
                // TODO returning fake data for now
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Chris Palmer",
                    Email = "chris.palmer@neudesic.com"
                };
            }
            catch
            {
                throw;
            }

            return user;
        }

    }
}
