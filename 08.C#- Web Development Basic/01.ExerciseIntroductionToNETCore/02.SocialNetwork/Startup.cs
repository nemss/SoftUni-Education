using System.Runtime.CompilerServices;
using _02.SocialNetwork.Data.Logic;
using __02.SocialNetwork.Data;

namespace _02.SocialNetwork
{
    using _02.SocialNetwork.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (var db = new SocialNetworkDbContext())
            {
                db.Database.Migrate();

                //SeedUsers(db);
                //SeedAlbumsAndPictures(db);
                //SeedTags(db);

                //PrintUsersWithFriends(db);
                //PrintUserIsActive(db);
                //PrintAlbumWithTotalPicture(db);
                //PrintPicturesInfo(db);
                //PrintAlbumByUser(db);
                //PrintTagsByAlbum(db);
                PrintUserWithMoreThanTreeALlbums(db);
            }
        }

        private static void PrintUserWithMoreThanTreeALlbums(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Where(u => u.Albums.Any(a => a.Tags.Count > 3))
                .Select(u => new
                {
                    u.Username,
                    Albums = u
                        .Albums
                        .Where(a => a.Tags.Count > 3)
                        .Select(a => new
                        {
                            a.Name,
                            Tags = a.Tags.Select(t => t.Tag.Name)
                        })
                })
                .OrderByDescending(u => u.Albums.Count())
                .ThenByDescending(u => u.Albums.Sum(a => a.Tags.Count()))
                .ThenBy(u => u.Username)
                .ToList();

        }

        private static void PrintTagsByAlbum(SocialNetworkDbContext db)
        {
            var tag = "#tag0";

            var result = db
                .Albums
                .Where(a => a.Tags.Any(t => t.Tag.Name == tag))
                .OrderByDescending(a => a.Tags.Count)
                .ThenBy(a => a.Name)
                .Select(a => new
                {
                    Title = a.Name,
                    Owner = a.User.Username
                })
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Title} - {album.Owner}");
            }
        }

        private static void SeedTags(SocialNetworkDbContext db)
        {
            var totalTags = db.Albums.Count() * 20;

            var tags = new List<Tag>();

            var albumIds = db.Albums.Select(a => a.Id).ToList();

            for (int i = 0; i < totalTags; i++)
            {
                var tag = new Tag
                {
                    Name = TagTransform.Transform($"tag{i}")
                };

                db.Tags.Add(tag);
                tags.Add(tag);
            }

            db.SaveChanges();

            foreach (var tag in tags)
            {
                var totalAlbums = random.Next(0, 20);

                for (int i = 0; i < totalAlbums; i++)
                {
                    var albumId = albumIds[random.Next(0, albumIds.Count)];

                    var tagExistForAlbum = db
                        .Albums
                        .Any(a => a.Id == albumId && a.Tags.Any(t => t.TagId == tag.Id));

                    if (tagExistForAlbum)
                    {
                        i--;
                        continue;

                    }

                    tag.Albums.Add(new AlbumTag
                    {
                        AlbumId = albumId
                    });

                    db.SaveChanges();
                }
            }
        }

        private static void PrintAlbumByUser(SocialNetworkDbContext db)
        {
            var userId = 1;

            var result = db
                .Albums
                .Where(a => a.UserId == userId)
                .Select(a => new
                {
                    Owner = a.User.Username,
                    a.IsPublic,
                    a.Name,
                    Pictires = a.Pictures.Select(p => new
                    {
                        p.Picture.Title,
                        p.Picture.Path
                    })
                })
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Name}");
                if (album.IsPublic)
                {
                    foreach (var picture in album.Pictires)
                    {
                        Console.WriteLine($"---- {picture.Title} - {picture.Path}");
                    }
                }
                else
                {
                    Console.WriteLine("Private content!");
                }

                Console.WriteLine(new string('-', 20));
            }
        }

        private static void PrintPicturesInfo(SocialNetworkDbContext db)
        {
            var result = db
                .Pictures
                .Where(p => p.Albums.Count > 2)
                .Select(p => new
                {
                    p.Title,
                    Albums = p.Albums.Select(a => a.Album.Name),
                    Owners = p.Albums.Select(a => a.Album.User.Username)
                })
                .OrderByDescending(p => p.Albums.Count())
                .ThenBy(p => p.Title)
                .ToList();
            foreach (var pictire in result)
            {
                Console.WriteLine($"{pictire.Title}");
                Console.WriteLine($"--Albums: {string.Join(", ", pictire.Albums)}");
                Console.WriteLine($"---Owners: {string.Join(", ", pictire.Owners)}");
            }
        }

        private static void PrintAlbumWithTotalPicture(SocialNetworkDbContext db)
        {
            var result = db
                .Albums
                .Select(a => new
                {
                    Title = a.Name,
                    Owner = a.User.Username,
                    TotalPicture = a.Pictures.Count
                })
                .OrderByDescending(a => a.TotalPicture)
                .ThenBy(a => a.Owner)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine($"{album.Title} - {album.TotalPicture} - {album.Owner}");
            }
        }

        private static void SeedUsers(SocialNetworkDbContext db)
        {
            const int totalUser = 50;

            var biggestUserId = db.Users
                                    .OrderByDescending(u => u.Id)
                                    .Select(u => u.Id)
                                    .FirstOrDefault() + 1;

            var allUser = new List<User>();

            for (int i = biggestUserId; i < biggestUserId + totalUser; i++)
            {
                var user = new User
                {
                    Username = $"Username {i}",
                    Password = $"PassW0rd#$",
                    Email = "email@email.com",
                    RegisteredOn = DateTime.Now.AddDays(100 + i * 10),
                    LastTimeLoggetIn = DateTime.Now.AddDays(i),
                    IsDeleted = false,
                    Age = i
                };

                db.Users.Add(user);
                allUser.Add(user);
            }

            db.SaveChanges();

            var userIds = allUser.Select(u => u.Id).ToList();

            for (int i = 0; i < userIds.Count; i++)
            {
                var currentUserId = userIds[i];

                var totallFriends = random.Next(5, 11);

                for (int j = 0; j < totallFriends; j++)
                {
                    var friendId = userIds[random.Next(0, userIds.Count)];

                    var validFriendShip = true;

                    if (friendId == currentUserId)
                    {
                        validFriendShip = false;
                    }

                    var friendShip = db
                        .FriendShips
                        .Any(f =>
                            (f.FromUserId == currentUserId && f.ToUserId == friendId) ||
                            (f.FromUserId == friendId && f.ToUserId == currentUserId));

                    if (friendShip)
                    {
                        validFriendShip = false;
                    }

                    if (!validFriendShip)
                    {
                        j--;
                        continue;
                    }

                    db.FriendShips.Add(new FriendShip
                    {
                        FromUserId = currentUserId,
                        ToUserId = friendId
                    });

                    db.SaveChanges();
                }
            }
        }

        private static void PrintUsersWithFriends(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Select(u => new
                {
                    Name = u.Username,
                    Friends = u.FromFriends.Count + u.ToFriends.Count,
                    Status = u.IsDeleted ? "Inactive" : "Active"
                })
                .OrderByDescending(u => u.Friends)
                .ThenBy(u => u.Name)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.Friends} - {user.Status}");
            }
        }

        private static void PrintUserIsActive(SocialNetworkDbContext db)
        {
            var result = db
                .Users
                .Where(u => !u.IsDeleted)
                .Where(u => (u.FromFriends.Count + u.ToFriends.Count) > 5)
                .OrderBy(u => u.RegisteredOn)
                .ThenBy(u => u.FromFriends.Count + u.ToFriends.Count)
                .Select(u => new
                {
                    Name = u.Username,
                    TotalFriends = u.FromFriends.Count + u.ToFriends.Count,
                    Period = DateTime.Now.Subtract(u.RegisteredOn.Value)
                })
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Name} - {user.TotalFriends} - {user.Period.Days}");
            }
        }

        private static void SeedAlbumsAndPictures(SocialNetworkDbContext db)
        {
            const int totalAlbums = 100;
            const int totallPictures = 500;

            var biggestAlbumId = db
                                     .Albums
                                     .OrderByDescending(a => a.Id)
                                     .Select(a => a.Id)
                                     .FirstOrDefault() + 1;
            var userIds = db
                .Users
                .Select(u => u.Id)
                .ToList();

            var albums = new List<Album>();

            for (int i = biggestAlbumId; i < biggestAlbumId + totalAlbums; i++)
            {
                var album = new Album
                {
                    Name = $"Album {i}",
                    Background = $"Color {i}",
                    IsPublic = random.Next(0, 1) == 0 ? true : false,
                    UserId = userIds[random.Next(0, userIds.Count)]
                };

                db.Albums.Add(album);
                albums.Add(album);
            }

            db.SaveChanges();

            var biggestPictureId = db
                .Pictures
                .OrderByDescending(p => p.Id)
                .Select(u => u.Id)
                .FirstOrDefault() + 1;

            var pictures = new List<Picture>();

            for (int i = biggestPictureId; i < biggestPictureId + totallPictures; i++)
            {
                var picture = new Picture
                {
                    Title = $"Picture {i}",
                    Caption = $"Caption {i}",
                    Path = $"Path {i}"
                };

                pictures.Add(picture);
                db.Pictures.Add(picture);
            }

            db.SaveChanges();


            var albumIds = albums.Select(a => a.Id).ToList();

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var numberOfAlbums = random.Next(1, 20);

                for (int j = 0; j < numberOfAlbums; j++)
                {
                    var albumId = albumIds[random.Next(0, albumIds.Count)];

                    var pictureExist = db
                        .Pictures
                        .Any(p => p.Id == picture.Id && p.Albums.Any(a => a.AlbumId == albumId));

                    if (pictureExist)
                    {
                        j--;
                        continue;

                    }
                    picture.Albums.Add(new AlbumPicture
                    {
                        AlbumId = albumId,
                    });
                    db.SaveChanges();
                }
            }
        }

    }
}
