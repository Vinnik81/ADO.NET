USE MusicCollection
GO
SELECT * FROM Style;
SELECT * FROM Performers;
SELECT md.DiscName, md.ReleaseDate, s.StyleName, p.PerformersName, pb.PublisherName 
FROM MusicDisc md, Style s, Performers p, Publisher pb 
WHERE s.id_style = md.id_style AND p.id_performers = md.id_performers AND pb.id_publisher = md.id_publisher;
SELECT * FROM MusicDisc;
SELECT * FROM Publisher;
SELECT * FROM Track;