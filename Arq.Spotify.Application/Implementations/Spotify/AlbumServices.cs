using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.Contracts.Spotify;
using Arq.Spotify.Application.DTOs.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.Spotify;
using Arq.Spotify.Domain.Entities.Spotify;
using AutoMapper;

namespace Arq.Spotify.Application.Implementations.Spotify
{
    public class AlbumServices : IAlbumServices
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumServices(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<AlbumOutputDTO> Create(AlbumInputDTO dto)
        {
            var album = this._mapper.Map<Album>(dto);

            await this._albumRepository.Add(album);

            return this._mapper.Map<AlbumOutputDTO>(album);
        }

        public async Task<List<AlbumOutputDTO>> GetAll()
        {
            return this._mapper.Map<List<AlbumOutputDTO>>(await _albumRepository.GetAll());
        }
    }
}
