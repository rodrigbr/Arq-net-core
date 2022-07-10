﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Domain.ValueObjects.Music
{
    public class Duration
    {
        public Duration()
        {

        }

        public Duration(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; set; }

        public string FormatValue => Format(Value);

        private string Format(decimal value)
        {
            var hours = Math.Floor(value / 3600);
            var duration = value % 3600;

            var minutes = Math.Floor(value / 60);
            var seconds = duration % 60;

            if (hours > 0)
            {
                return $"{hours.ToString().PadLeft(2, '0')} Hrs {minutes.ToString().PadLeft(2, '0')} Min {seconds.ToString().PadLeft(2, '0')} Seg";
            }

            return $"{minutes.ToString().PadLeft(2, '0')} Min {seconds.ToString().PadLeft(2, '0')} Seg";

        }
        public override string ToString()
        {
            return FormatValue;
        }
    }
}
