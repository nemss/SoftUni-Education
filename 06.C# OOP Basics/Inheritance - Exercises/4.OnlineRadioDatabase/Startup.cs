namespace _4.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var listOfSong = new List<Song>();
            var numberOfEntries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEntries; i++)
            {
                var info = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var artistName = info[0];
                var songName = info[1];
                var lenght = info[2].Split(':');
                try
                {
                    var minutes = 0;
                    var seconds = 0;
                    if (int.TryParse(lenght[0], out minutes) && int.TryParse(lenght[1], out seconds))
                    {
                        listOfSong.Add(new Song(artistName, songName, minutes, seconds));
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new InvalidSongLengthException();
                    }
                }
                catch (InvalidSongException e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Songs added: {listOfSong.Count}");
            var totalMinutes = listOfSong.Sum(x => x.Minites);
            var totalSeconds = listOfSong.Sum(x => x.Seconds);
            totalSeconds += totalMinutes * 60;

            var minute = totalSeconds / 60;
            var second = totalSeconds % 60;
            var hour = minute / 60;
            minute %= 60;

            Console.WriteLine($"Playlist length: {hour}h {minute}m {second}s");
        }
    }
}
