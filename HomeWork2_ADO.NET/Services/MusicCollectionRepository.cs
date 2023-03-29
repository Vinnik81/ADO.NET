using HomeWork2_ADO.NET.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HomeWork2_ADO.NET.Services
{
    public class MusicCollectionRepository : IMusicCollectionRepository
    {
        private readonly string connectionString = @"Data Source=DESKTOP-A3B51L5\SQLEXPRESS;Initial Catalog=MusicCollection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Create(Performers performers)
        {
            int id;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO Performers (PerformersName)" +
                "VALUES (@performersName)" +
                "SET @id_performers = SCOPE_IDENTITY()";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@performersName", performers.PerformersName));

            var IdParam = new SqlParameter()
            {
                ParameterName = "@id_performers",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IdParam);
            command.ExecuteNonQuery();
            id = (int)IdParam.Value;
            return id;
        }

        public int Create(MusicDisk musicDisk)
        {
            int id;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO MusicDisc (DiscName, ReleaseDate, id_style, id_performers, id_publisher)" +
                "VALUES (@discName, @releaseDate, @idStyle, @idPerformers, @idPublisher)" +
                "SET @id_disc = SCOPE_IDENTITY()";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@discName", musicDisk.DiskName));
            command.Parameters.Add(new SqlParameter("@releaseDate", musicDisk.ReleaseDate));
            command.Parameters.Add(new SqlParameter("@idStyle", musicDisk.idStyle));
            command.Parameters.Add(new SqlParameter("@idPerformers", musicDisk.idPerformer));
            command.Parameters.Add(new SqlParameter("@idPublisher", musicDisk.idPublisher));

            var IdParam = new SqlParameter()
            {
                ParameterName = "@id_disc",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IdParam);
            command.ExecuteNonQuery();
            id = (int)IdParam.Value;
            return id;
        }

        public int Create(Track track)
        {
            int id;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = @"INSERT INTO Track (TrackName, TrackTime, id_disc, id_style, id_performers)" +
                "VALUES (@trackName, @trackTime, @idDisk, @idStyle, @idPerformers)" +
                "SET @id_track = SCOPE_IDENTITY()";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@trackName", track.TrackName));
            command.Parameters.Add(new SqlParameter("@trackTime", track.TrackTime));
            command.Parameters.Add(new SqlParameter("@idDisk", track.idDisk));
            command.Parameters.Add(new SqlParameter("@idStyle", track.idStyle));
            command.Parameters.Add(new SqlParameter("@idPerformers", track.idPerformers));

            var IdParam = new SqlParameter()
            {
                ParameterName = "@id_track",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(IdParam);
            command.ExecuteNonQuery();
            id = (int)IdParam.Value;
            return id;
        }

        public void DeleteMusicDisk(int id)
        {
            var query = "DELETE FROM MusicDisc WHERE id_disc = @id";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", id));
            command.ExecuteNonQuery();
        }

        public void DeletePerformer(int id)
        {
            var query = "DELETE FROM Performers WHERE id_performers = @id";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", id));
            command.ExecuteNonQuery();
        }

        public void DeleteTrack(int id)
        {
            var query = "DELETE FROM Track WHERE id_track = @id";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", id));
            command.ExecuteNonQuery();
        }

        public IEnumerable<MusicDisk> GetAllMusicDisks()
        {
            List<MusicDisk> list = new List<MusicDisk>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM MusicDisc" ;
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var musicDisk = new MusicDisk()
                    {
                        id = reader.GetInt32(0),
                        DiskName = reader.GetString(1),
                        ReleaseDate = reader.GetDateTime(2),
                        idStyle = reader.GetInt32(3),
                        idPerformer = reader.GetInt32(4),
                        idPublisher = reader.GetInt32(5)
                    };


                    list.Add(musicDisk);
                }
            }
            return list;
        }

        public IEnumerable<Performers> GetAllPerformers()
        {
            List<Performers> list = new List<Performers>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Performers";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var performers = new Performers()
                    {
                        id = reader.GetInt32(0),
                        PerformersName = reader.GetString(1)
                    };

                    list.Add(performers);
                }
            }
            return list;
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            List<Publisher> list = new List<Publisher>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Publisher";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var publishers = new Publisher()
                    {
                        id = reader.GetInt32(0),
                        PublisherName = reader.GetString(1)
                    };

                    list.Add(publishers);
                }
            }
            return list;
        }

        public IEnumerable<Style> GetAllStyle()
        {
            List<Style> list = new List<Style>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Style";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var styles = new Style()
                    {
                        id = reader.GetInt32(0),
                        StyleName = reader.GetString(1)
                    };

                    list.Add(styles);
                }
            }
            return list;
        }

        public IEnumerable<Track> GetAllTracks()
        {
            List<Track> list = new List<Track>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Track";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var track = new Track()
                    {
                        id = reader.GetInt32(0),
                        TrackName = reader.GetString(1),
                        TrackTime = reader.GetTimeSpan(2),
                        idDisk = reader.GetInt32(3),
                        idStyle = reader.GetInt32(4),
                        idPerformers = reader.GetInt32(5),
                    };


                    list.Add(track);
                }
            }
            return list;
        }

        public MusicDisk GetMusicDiskById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            MusicDisk musicDisk = null;
            var query = "SELECT * FROM MusicDisc WHERE id_disc = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    musicDisk = new MusicDisk()
                    {
                        id = reader.GetInt32(0),
                        DiskName = reader.GetString(1),
                        ReleaseDate = reader.GetDateTime(2),
                        idStyle = reader.GetInt32(3),
                        idPerformer = reader.GetInt32(4),
                        idPublisher = reader.GetInt32(5)
                    };
                }
            }
            else throw new Exception("MusicDisk not found");

            return musicDisk;
        }

        public Performers GetPerformersById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
           Performers performers = null;
            var query = "SELECT * FROM Performers WHERE id_performers = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    performers = new Performers()
                    {
                        id = reader.GetInt32(0),
                        PerformersName = reader.GetString(1)
                    };
                }
            }
            else throw new Exception("Performers not found");

            return performers;
        }

        public Publisher GetPublisherById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Publisher publisher = null;
            var query = "SELECT * FROM Publisher WHERE id_publisher = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    publisher = new Publisher()
                    {
                        id = reader.GetInt32(0),
                        PublisherName = reader.GetString(1),
                        Country = reader.GetString(2)
                    };
                }
            }
            else throw new Exception("Publisher not found");

            return publisher;
        }

        public Style GetStyleById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Style style = null;
            var query = "SELECT * FROM Style WHERE id_style = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    style = new Style()
                    {
                        id = reader.GetInt32(0),
                        StyleName = reader.GetString(1)
                    };
                }
            }
            else throw new Exception("Style not found");

            return style;
        }

        public Track GetTrackById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Track track = null;
            var query = "SELECT * FROM Track WHERE id_track = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    track = new Track()
                    {
                        id = reader.GetInt32(0),
                        TrackName = reader.GetString(1),
                        TrackTime = reader.GetTimeSpan(2),
                        idDisk = reader.GetInt32(3),
                        idStyle = reader.GetInt32(4),
                        idPerformers = reader.GetInt32(5),
                    };
                }
            }
            else throw new Exception("Track not found");

            return track;
        }

        public void Update(Performers performers)
        {
            var query = @"UPDATE Performers
                      SET PerformersName = @name
                      WHERE id_performers = @id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", performers.id));
            command.Parameters.Add(new SqlParameter("name", performers.PerformersName));
            command.ExecuteNonQuery();
        }

        public void Update(MusicDisk musicDisk)
        {
            var query = @"UPDATE MusicDisc
                      SET DiscName = @name, ReleaseDate = @releaseDate, id_style = @idStyle, id_performers = @idPerformers, id_publisher = @idPublisher
                      WHERE id_disc = @id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", musicDisk.id));
            command.Parameters.Add(new SqlParameter("name", musicDisk.DiskName));
            command.Parameters.Add(new SqlParameter("releaseDate", musicDisk.ReleaseDate));
            command.Parameters.Add(new SqlParameter("idStyle", musicDisk.idStyle));
            command.Parameters.Add(new SqlParameter("idPerformers", musicDisk.idPerformer));
            command.Parameters.Add(new SqlParameter("idPublisher", musicDisk.idPublisher));
            command.ExecuteNonQuery();
        }

        public void Update(Track track)
        {
            var query = @"UPDATE Track
                      SET TrackName = @name, TrackTime = @trackTime, id_disc = @idDisc, id_style = @idStyle, id_performers = @idPerformers
                      WHERE id_track = @id";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("id", track.id));
            command.Parameters.Add(new SqlParameter("name", track.TrackName));
            command.Parameters.Add(new SqlParameter("trackTime", track.TrackTime));
            command.Parameters.Add(new SqlParameter("idDisc", track.idDisk));
            command.Parameters.Add(new SqlParameter("idStyle", track.idStyle));
            command.Parameters.Add(new SqlParameter("idPerformers", track.idPerformers));
            command.ExecuteNonQuery();
        }
    }
}
