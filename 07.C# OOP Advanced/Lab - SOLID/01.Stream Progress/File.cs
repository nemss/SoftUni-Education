namespace _01.Stream_Progress
{
    public class File : IStreamable
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Lenght = length;
            this.BytesSent = bytesSent;
        }

        public int Lenght { get; }
        public int BytesSent { get; set; }
    }
}