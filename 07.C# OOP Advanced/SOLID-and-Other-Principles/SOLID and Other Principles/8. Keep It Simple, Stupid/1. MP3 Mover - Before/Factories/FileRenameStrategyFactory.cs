namespace KISSMp3MoverBefore.Factories
{
    using KISSMp3MoverBefore.Contracts;
    using KISSMp3MoverBefore.Strategies.RenameStrategies;
    using System;

    public class FileRenameStrategyFactory : IFileRenameStrategyFactory
    {
        public IFileRenameStrategy Get(string type)
        {
            switch (type)
            {
                case "RemoveArtist": return new RemoveArtistRenameStrategy();
                default: throw new ArgumentException("Invalid move strategy");
            }
        }
    }
}