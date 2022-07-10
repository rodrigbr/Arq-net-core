using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Entities.User.Validators;
using Arq.Spotify.Domain.ValueObjects.User;
using FluentValidation;

namespace Arq.Spotify.Domain.Entities.User
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public virtual IList<UserFavoriteMusic> FavoriteMusics { get; set; }

        public void Validate() => new UserValidator().ValidateAndThrow(this);
    }
}
