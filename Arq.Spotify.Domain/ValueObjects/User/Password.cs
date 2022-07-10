using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Domain.ValueObjects.User
{
    public class Password
    {
        public Password()
        {

        }
        public Password(string value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; set; }
    }
}
