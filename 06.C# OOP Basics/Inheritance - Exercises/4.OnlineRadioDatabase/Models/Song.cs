namespace _4.OnlineRadioDatabase
{
    public class Song
    {
        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minites = minutes;
            this.Seconds = seconds;
        }

        private string songName;
        private string artistName;
        private int minutes;
        private int seconds;

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public int Minites
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }
}
