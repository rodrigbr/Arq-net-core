using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.DTOs.Spotify;
using MediatR;

namespace Arq.Spotify.Application.Handler.Commands
{
    public class CreateAlbumCommandResponse
    {
        public AlbumOutputDTO Album { get; set; }

        public CreateAlbumCommandResponse(AlbumOutputDTO album)
        {
            Album = album;
        }
    }
}
