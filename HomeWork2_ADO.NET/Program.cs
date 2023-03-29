using HomeWork2_ADO.NET.Models;
using HomeWork2_ADO.NET.Services;
using System;
using System.Linq;

namespace HomeWork2_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("0-Exit\n1-Read all Performers\n2-Read Performer for id_performers\n3-Create Performer\n4-Update Performer\n5-Delete Performer\n"
                    + "6-Read All MusicDisk\n7-Read MusicDisk for id_disc\n8-Create MusicDisc\n9-Update MusicDisk\n10-Delete MusicDisk\n11-Read all Tracks\n" +
                    $"12-Read track for id_track\n13-Create track\n14-Update Track\n15-Delete Track\n16-Read Style for id_style\n17-Read Publisher for id_publisher");
                int.TryParse(Console.ReadLine(), out int num);

                MusicCollectionRepository musicCollectionRepository = new MusicCollectionRepository();
                var list = musicCollectionRepository.GetAllPerformers().ToList();
                var listMd = musicCollectionRepository.GetAllMusicDisks().ToList();
                var listS = musicCollectionRepository.GetAllStyle().ToList();
                var listPb = musicCollectionRepository.GetAllPublishers().ToList();
                var listTr = musicCollectionRepository.GetAllTracks().ToList();

                switch (num)
                {
                    case 0:
                          Console.WriteLine("Exit");
                          Environment.Exit(0);
                          break;

                    case 1:
                        for (int i = 0; i < list.Count(); i++) Console.WriteLine($"id: {list[i].id} PerformersName: {list[i].PerformersName}");
                        break;

                    case 2:
                        Console.WriteLine("Size: " + list.Count());
                        Console.WriteLine("Enter id_performers: ");
                        int.TryParse(Console.ReadLine(), out int id_per);
                        Performers performersId = musicCollectionRepository.GetPerformersById(id_per);
                        Console.WriteLine(performersId);
                        break;

                    case 3:
                        Console.WriteLine("Enter  PerformerName:  ");
                        string name = Console.ReadLine();

                        Performers performersCr = new Performers
                        {
                            PerformersName = name
                        };

                        var Id = musicCollectionRepository.Create(performersCr);
                        Performers performer = musicCollectionRepository.GetPerformersById(Id);
                        Console.WriteLine(performer.ToString());
                        break;

                    case 4:
                        Console.WriteLine("Enter id_performers: ");
                        int.TryParse(Console.ReadLine(), out int id_perUp);
                        Performers performersUp = musicCollectionRepository.GetPerformersById(id_perUp);
                        Console.WriteLine("Enter PerformersName");
                        performersUp.PerformersName = Console.ReadLine();
                        musicCollectionRepository.Update(performersUp);
                        Console.WriteLine(performersUp);
                        break;

                    case 5:
                        Console.WriteLine("Size: " + list.Count());
                        Console.WriteLine("Enter id_performers: ");
                        int.TryParse(Console.ReadLine(), out int id);
                        musicCollectionRepository.DeletePerformer(id);
                        list = musicCollectionRepository.GetAllPerformers().ToList();
                        Console.WriteLine("Size: " + list.Count());
                        break;

                    case 6:

                        for (int i = 0; i < listMd.Count(); i++)
                        {
                            for (int j = 0; j < listS.Count(); j++)
                            {
                                for (int k = 0; k < list.Count(); k++)
                                {
                                    for (int m = 0; m < listPb.Count(); m++)
                                    {
                                        if (listS[j].id == listMd[i].idStyle && list[k].id == listMd[i].idPerformer && listPb[m].id == listMd[i].idPublisher)
                                        {
                                            Console.WriteLine($"id: {listMd[i].id} DiscName: {listMd[i].DiskName} | ReleaseDate: {listMd[i].ReleaseDate} | " +
                                            $" id_style: {listMd[i].idStyle} Style: {listS[j].StyleName} | id_performer: {listMd[i].idPerformer} Performer: {list[k].PerformersName} " +
                                            $" | id_publisher: {listMd[i].idPublisher} Publisher: {listPb[m].PublisherName}");
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case 7:
                        Console.WriteLine("Size: " + listMd.Count());
                        Console.WriteLine("Enter id_disc: ");
                        int.TryParse(Console.ReadLine(), out int id_disc);
                        MusicDisk musicDiskId = musicCollectionRepository.GetMusicDiskById(id_disc);
                        Console.WriteLine(musicDiskId);
                        break;

                    case 8:
                        Console.WriteLine("Enter  diskName:  ");
                        string diskName = Console.ReadLine();
                        Console.WriteLine("Enter releaseDate:  ");
                        DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id_style:  ");
                        int.TryParse(Console.ReadLine(), out int _idStyle);
                        Console.WriteLine("Enter id_performer:  ");
                        int.TryParse(Console.ReadLine(), out int _idPerformer);
                        Console.WriteLine("Enter id_publisher:  ");
                        int.TryParse(Console.ReadLine(), out int _idPublisher);

                        MusicDisk musicDiskCr = new MusicDisk
                        {
                            DiskName = diskName,
                            ReleaseDate = releaseDate,
                            idStyle = _idStyle,
                            idPerformer = _idPerformer,
                            idPublisher = _idPublisher
                        };

                        var Id_md = musicCollectionRepository.Create(musicDiskCr);
                        MusicDisk md = musicCollectionRepository.GetMusicDiskById(Id_md);
                        Console.WriteLine(md.ToString());
                        break;

                    case 9:
                        Console.WriteLine("Enter id_dick: ");
                        int.TryParse(Console.ReadLine(), out int id_diskUp);
                        MusicDisk musicDiskUp = musicCollectionRepository.GetMusicDiskById(id_diskUp);
                        Console.WriteLine("Enter DiskName: ");
                        musicDiskUp.DiskName = Console.ReadLine();
                        Console.WriteLine("Enter ReleaseDate: ");
                        musicDiskUp.ReleaseDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id_style: ");
                        int.TryParse(Console.ReadLine(), out int idStyle);
                        musicDiskUp.idStyle = idStyle;
                        Console.WriteLine("Enter id_performer:  ");
                        int.TryParse(Console.ReadLine(), out int idPerformers);
                        musicDiskUp.idPerformer = idPerformers;
                        Console.WriteLine("Enter id_publisher: ");
                        int.TryParse(Console.ReadLine(), out int idPublisher);
                        musicDiskUp.idPublisher = idPublisher;
                        musicCollectionRepository.Update(musicDiskUp);
                        Console.WriteLine(musicDiskUp);
                        break;

                    case 10:
                        Console.WriteLine("Size: " + listMd.Count());
                        Console.WriteLine("Enter id_disc: ");
                        int.TryParse(Console.ReadLine(), out int idDisk);
                        musicCollectionRepository.DeleteMusicDisk(idDisk);
                        listMd = musicCollectionRepository.GetAllMusicDisks().ToList();
                        Console.WriteLine("Size: " + listMd.Count());
                        break;

                    case 11:
                        for (int i = 0; i < listTr.Count(); i++)
                        {
                            for (int j = 0; j < listMd.Count(); j++)
                            {
                                for (int k = 0; k < listS.Count(); k++)
                                {
                                    for (int m = 0; m < list.Count(); m++)
                                    {
                                        if (listMd[j].id == listTr[i].idDisk && listS[k].id == listTr[i].idStyle && list[m].id == listTr[i].idPerformers)
                                        {
                                            Console.WriteLine($"id: {listTr[i].id} TrackName: {listTr[i].TrackName} | TrackTime: {listTr[i].TrackTime}" +
                                            $" | id_disk: {listTr[i].idDisk} Disk: {listMd[j].DiskName} | id_style: {listTr[i].idStyle} Style: {listS[k].StyleName} | " +
                                            $" id_performers: {listTr[i].idPerformers} Performer: {list[m].PerformersName}");
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case 12:
                        Console.WriteLine("Size: " + listTr.Count());
                        Console.WriteLine("Enter id_track: ");
                        int.TryParse(Console.ReadLine(), out int id_track);
                        Track track = musicCollectionRepository.GetTrackById(id_track);
                        Console.WriteLine(track);
                        break;

                    case 13:
                        Console.WriteLine("Enter  TrackName:  ");
                        string trackName = Console.ReadLine();
                        Console.WriteLine("Enter TrackTime:  ");
                        TimeSpan trackTime = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id_disk:  ");
                        int.TryParse(Console.ReadLine(), out int idDiskTr);
                        Console.WriteLine("Enter id_style:  ");
                        int.TryParse(Console.ReadLine(), out int idStyleTr);
                        Console.WriteLine("Enter id_performer:  ");
                        int.TryParse(Console.ReadLine(), out int idPerformerTr);

                        Track trackCr = new Track
                        {
                             TrackName = trackName,
                             TrackTime = trackTime,
                            idDisk = idDiskTr,
                            idStyle = idStyleTr,
                            idPerformers = idPerformerTr
                        };

                        var Id_tr = musicCollectionRepository.Create(trackCr);
                        Track tr = musicCollectionRepository.GetTrackById(Id_tr);
                        Console.WriteLine(tr.ToString());
                        break;

                    case 14:
                        Console.WriteLine("Enter id_track: ");
                        int.TryParse(Console.ReadLine(), out int id_trackUp);
                        Track trackUp = musicCollectionRepository.GetTrackById(id_trackUp);
                        Console.WriteLine("Enter TrackName: ");
                        trackUp.TrackName = Console.ReadLine();
                        Console.WriteLine("Enter TrackTime: ");
                        trackUp.TrackTime = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("Enter id_disk: ");
                        int.TryParse(Console.ReadLine(), out int idDiskUp);
                        trackUp.idDisk = idDiskUp;
                        Console.WriteLine("Enter id_style: ");
                        int.TryParse(Console.ReadLine(), out int idStyleUp);
                        trackUp.idStyle = idStyleUp;
                        Console.WriteLine("Enter id_performer:  ");
                        int.TryParse(Console.ReadLine(), out int idPerformersUp);
                        trackUp.idPerformers = idPerformersUp;
                        musicCollectionRepository.Update(trackUp);
                        Console.WriteLine(trackUp);
                        break;

                    case 15:
                        Console.WriteLine("Size: " + listTr.Count());
                        Console.WriteLine("Enter id_track: ");
                        int.TryParse(Console.ReadLine(), out int idTrack);
                        musicCollectionRepository.DeleteTrack(idTrack);
                        listTr = musicCollectionRepository.GetAllTracks().ToList();
                        Console.WriteLine("Size: " + listTr.Count());
                        break;

                    case 16:
                        Console.WriteLine("Size: " + listS.Count());
                        Console.WriteLine("Enter id_style: ");
                        int.TryParse(Console.ReadLine(), out int id_s);
                        Style style = musicCollectionRepository.GetStyleById(id_s);
                        Console.WriteLine(style);
                        break;

                    case 17:
                        Console.WriteLine("Size: " + listPb.Count());
                        Console.WriteLine("Enter id_publisher: ");
                        int.TryParse(Console.ReadLine(), out int id_pub);
                        Publisher publisher = musicCollectionRepository.GetPublisherById(id_pub);
                        Console.WriteLine(publisher);
                        break;

                    default:
                        Console.WriteLine("Error number!");
                        break;
                }
                Console.WriteLine();
            }
            while (true);
        }
    }
}
