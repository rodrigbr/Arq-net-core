using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.DTOs.Spotify;

namespace Arq.Spotify.Application.Contracts.Spotify
{
    public interface IAlbumServices
    {
        Task<AlbumOutputDTO> Create(AlbumInputDTO dto); 
        Task<List<AlbumOutputDTO>> GetAll();
    }
}
