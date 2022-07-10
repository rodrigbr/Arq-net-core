using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Domain.ValueObjects.User
{
    public class Cpf
    {
        public Cpf()
        {

        }
        public Cpf(string value)
        {
            this.Value = value?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(Cpf));
        }

        public String Value { get; set; }

        public string FormatValue => Format(this.Value);

        private string Format(string value) => Convert.ToInt64(value).ToString(@"000\.000\.000\-00");

    }
}
