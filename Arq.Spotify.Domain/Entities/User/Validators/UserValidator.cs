﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Arq.Spotify.Domain.Entities.User.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.Cpf).SetValidator(new CpfValidator());
        }
    }
}
