using System.Threading.Tasks;
using Arq.Spotify.Application.Contracts.Spotify;
using Arq.Spotify.Application.DTOs.Spotify;
using Arq.Spotify.Application.Handler.Commands;
using Arq.Spotify.Application.Handler.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arq.Spotify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        public IMediator Handler { get; set; }

        public AlbumController(IAlbumServices albumServices, IMediator handler)
        {
            Handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlbumInputDTO dto)
        {
            var result = await Handler.Send(new CreateAlbumCommand(dto));
            return Created($"/{result.Album.Id}", result.Album);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Handler.Send(new AlbumGetAllQueryCommand());
            return Ok(result.Albums);
        }
    }
}
