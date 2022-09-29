using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicWebApp.Data;
using MusicWebApp.Models;
using Newtonsoft.Json;

namespace MusicWebApp.Controllers
{
    public class AlbumDataViewController : Controller
    {
       
        private readonly IConfiguration Configuration;

        public AlbumDataViewController(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public async Task<IActionResult> AlbumList()
        { 

            ViewGenerator viewGenerator = new ViewGenerator();
            List<Album> albums = await viewGenerator.AlbumListAsync(Configuration);
            return View(albums);
        }
    }

    public class ViewGenerator
    {
        public async Task<List<Album>> AlbumListAsync(IConfiguration Configuration)
        {
            List<Album> albums = new List<Album>();
            Album album = new Album();
            album.AlbumId = 1;
            album.Title = "TestAlbum";
            albums.Add(album);
            string AlbumListURL = Configuration["AlbumList"];

            try
            {
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("http://localhost:7283/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(AlbumListURL);
                    if (response.IsSuccessStatusCode)
                    {
                        var rawData = await response.Content.ReadAsStringAsync();

                        albums = (JsonConvert.DeserializeObject<List<Album>>(rawData) == null) ? albums : JsonConvert.DeserializeObject<List<Album>>(rawData);

                    }
                }
            }
            catch (Exception ex)
            {
                
                return albums;
            }
        


            return albums;
        }

        public List<Track> SelectedTrackList(IConfiguration Configuration)
        {
            List<Track> selectedtracks = new List<Track>();
            string SelectedTrackListURL = Configuration["TrackList"];

            return selectedtracks;
        }

        public List<Track> TrackList(IConfiguration Configuration)
        {
            List<Track> tracks = new List<Track>();
            string TrackListURL = Configuration["TrackList"];

            return tracks;
        }
    }
}
