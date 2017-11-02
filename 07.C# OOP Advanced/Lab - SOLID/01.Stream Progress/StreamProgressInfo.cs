namespace _01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamble;

        public StreamProgressInfo(IStreamable file)
        {
            this.streamble = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamble.BytesSent * 100) / this.streamble.Lenght;
        }
    }
}