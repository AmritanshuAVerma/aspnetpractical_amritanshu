
using Album.BusinessLogic.IAlbum;
using Album.BusinessLogic.Model;
using Microsoft.AspNetCore.Mvc;



namespace MusicWebApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumBL _aBL;
        public AlbumsController(IAlbumBL aBL)
        {
            _aBL = aBL;
        }

        // Display Albums List
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //For UI Testing
            AlbumDto albumDto = new AlbumDto();

            albumDto.AlbumId = 1;
            albumDto.AlbumName = "TestAlbum";
            albumDto.TrackName = "Test Track";
            albumDto.IsChecked = false;
            List<AlbumDto> albums = new List<AlbumDto>();

            albums.Add(albumDto);
            return View(albums);
            //return View(await _aBL.GetAllAlbums(cancellationToken));
        }

        // Show Album Edit
        public IActionResult UpdateAlbumData(int albumid, string albumName)
        {
            var data = new AlbumDto();
            data.AlbumName = albumName;
            data.AlbumId = albumid;
            return View("Update", data);
        }

        // Update Album Data
        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(AlbumDto albumDto, CancellationToken cancellationToken)
        {
            var result = await _aBL.UpdateAlbum(albumDto, cancellationToken);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Update", albumDto);
        }
        public async Task<IActionResult> TracksAlbum(List<AlbumDto> albums, CancellationToken cancellationToken)
        {
            var AlbumIds = (from item in albums where item.IsChecked == 
                            true select new AlbumDto() { AlbumId = item.AlbumId }).ToList();

            //var result = await _aBL.GetAlbumTrackList(AlbumIds, cancellationToken);

            //For UI Testing
            List<AlbumDto> albumsTest = new List<AlbumDto>();
            AlbumDto albumDto = new AlbumDto();

            albumDto.AlbumId = 1;
            albumDto.AlbumName = "TestAlbum2";
            albumDto.TrackName = "Test Track2";
            albumDto.IsChecked = false;
            albumsTest.Add(albumDto);

            AlbumDto albumDto2 = new AlbumDto();
            albumDto2.AlbumId = 2;
            albumDto2.AlbumName = "TestAlbum3";
            albumDto2.TrackName = "Test Track3";
            albumDto2.IsChecked = false;
            albumsTest.Add(albumDto2);



            List<AlbumDto> result = albumsTest;
            //List<AlbumDto> result = albums;

            if (result != null)
            {
                return View("Tracks", result);
            }

            return base.View("Tracks", new AlbumDto());


        }

    }
}
