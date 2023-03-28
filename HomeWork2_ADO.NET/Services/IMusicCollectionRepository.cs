using HomeWork2_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Services
{
  public interface IMusicCollectionRepository
    {
        IEnumerable<Performers> GetAllPerformers();
        Performers GetPerformersById(int id);
        IEnumerable<MusicDisk> GetAllMusicDisks();
        MusicDisk GetMusicDiskById(int id);
        IEnumerable<Track> GetAllTracks();
        Track GetTrackById(int id);
        IEnumerable<Style> GetAllStyle();
        Style GetStyleById(int id);
        IEnumerable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
        int Create(Performers performers);
        int Create(MusicDisk musicDisk);
        int Create(Track track);
        void Update(Performers performers);
        void Update(MusicDisk musicDisk);
        void Update(Track track);
        void DeletePerformer(int id);
        void DeleteMusicDisk(int id);
        void DeleteTrack(int id);
    }
}
