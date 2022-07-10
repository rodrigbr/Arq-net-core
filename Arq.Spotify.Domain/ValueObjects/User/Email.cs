using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Domain.ValueObjects.User
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string email)
        {
            this.Value = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Value { get; set; }
    }
}
