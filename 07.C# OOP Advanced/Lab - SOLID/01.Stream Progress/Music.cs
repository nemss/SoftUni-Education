namespace _01.Stream_Progress
{
    public class Music : IStreamable
    {
        private string artist;
        private string album;
       
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Lenght = length;
            this.BytesSent = bytesSent;
        }


        public int Lenght { get; }
        public int BytesSent { get; set; }
    }
}