using Album.Data.IRepositories;
using Album.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Data.Repositories
{
    public class TrackRepository : BaseReporitory<Album.Data.Models.Album>, ITrackRepository
    {

        private readonly AlbumContext albumContext;

        public TrackRepository(AlbumContext albumContext) : base(albumContext)
        {
            this.albumContext = albumContext;
        }
        public async Task<List<ArtistAlbumTracks>> GetAlbumTrack(List<Data.Models.Album> album, CancellationToken cancellationToken = default)
        {
            var albumIds = album.Select(x => x.AlbumId).ToList();

            return await albumContext.Track
                                       .Include(x => x.Album)
                                       .Where(x => albumIds.Contains(x.AlbumId))
                                       .Select(x => new ArtistAlbumTracks()
                                       {
                                           AlbumId = x.AlbumId,
                                           TrackName = x.Name,
                                           AlbumName = x.Album.Title
                                       }).ToListAsync(cancellationToken);
        }
    }
}
