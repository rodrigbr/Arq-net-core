using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.DTOs.Spotify;
using MediatR;

namespace Arq.Spotify.Application.Handler.Query
{
    public class AlbumGetAllQueryCommand : IRequest<AlbumGetAllQueryCommandResponse>
    {

    }

    public class AlbumGetAllQueryCommandResponse
    {
        public List<AlbumOutputDTO> Albums { get; set; }

        public AlbumGetAllQueryCommandResponse()
        {

        }

        public AlbumGetAllQueryCommandResponse(List<AlbumOutputDTO> albums)
        {
            this.Albums = albums;
        }
    }
}
