using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arq.Spotify.Application.Contracts.Spotify;
using Arq.Spotify.Application.Handler.Commands;
using Arq.Spotify.Application.Handler.Query;
using MediatR;

namespace Arq.Spotify.Application.Handler
{
    public class AlbumHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>,
                                IRequestHandler<AlbumGetAllQueryCommand, AlbumGetAllQueryCommandResponse>
    {
        public IAlbumServices AlbumService { get; set; }

        public AlbumHandler(IAlbumServices albumService)
        {
            AlbumService = albumService;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var dto = await AlbumService.Create(request.Album);
            return new CreateAlbumCommandResponse(dto);
        }
        public async Task<AlbumGetAllQueryCommandResponse> Handle(AlbumGetAllQueryCommand request, CancellationToken cancellationToken)
        {
            var dto = await AlbumService.GetAll();
            return new AlbumGetAllQueryCommandResponse(dto);
        }
    }
}
