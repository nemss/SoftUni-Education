namespace KISSMp3MoverBefore.Factories
{
    using KISSMp3MoverBefore.Contracts;
    using KISSMp3MoverBefore.Strategies.SelectStrategies;
    using System;

    public class FileSelectStrategyFactory : IFileSelectStrategyFactory
    {
        public IFileSelectStrategy Get(string type)
        {
            switch (type)
            {
                case "ArtistDashSong": return new ArtistDashSongStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}