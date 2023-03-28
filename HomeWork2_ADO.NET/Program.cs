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
                    + "6-Read All MusicDisk\n7-Read MusicDisk for id_disc\n8-Create MusicDisc\n9-Update MusicDisk\n10-Delete MusicDisk");
                int.TryParse(Console.ReadLine(), out int num);

                MusicCollectionRepository musicCollectionRepository = new MusicCollectionRepository();
                var list = musicCollectionRepository.GetAllPerformers().ToList();
                var listMd = musicCollectionRepository.GetAllMusicDisks().ToList();
                var listS = musicCollectionRepository.GetAllStyle().ToList();
                var listPb = musicCollectionRepository.GetAllPublishers().ToList();

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
                        for (int i = 0; i < listMd.Count(); i++) Console.WriteLine($"id: {listMd[i].id} DiscName: {listMd[i].DiskName} ReleaseDate: {listMd[i].ReleaseDate}" +
                            $"id_style: {listMd[i].idStyle} id_performer: {listMd[i].idPerformer} id_publisher: {listMd[i].idPublisher}");
                        Console.WriteLine("Style List: ");
                        for (int i = 0; i < listS.Count(); i++) Console.WriteLine($"id_style: {listS[i].id} StyleName: {listS[i].StyleName}");
                        Console.WriteLine("Performers List:");
                        for (int i = 0; i < list.Count(); i++) Console.WriteLine($"id_performer: {list[i].id} PerformersName: {list[i].PerformersName}");
                        Console.WriteLine("Publishers List:");
                        for (int i = 0; i < listPb.Count(); i++) Console.WriteLine($"id_publisher: {listPb[i].id} PerformersName: {listPb[i].PublisherName}");
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
