using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.DTOs.Spotify;
using MediatR;

namespace Arq.Spotify.Application.Handler.Commands
{
    public class CreateAlbumCommand : IRequest<CreateAlbumCommandResponse>
    {
        public AlbumInputDTO Album { get; set; }

        public CreateAlbumCommand(AlbumInputDTO album)
        {
            Album = album;
        }
    }
}
