namespace KISSMp3MoverBefore.Strategies.RenameStrategies
{
    using KISSMp3MoverBefore.Contracts;
    using System.IO;

    public class RemoveArtistRenameStrategy : IFileRenameStrategy
    {
        public void Rename(string fileName)
        {
            File.Move(fileName, fileName.Substring(fileName.IndexOf(" - ") + 3));
        }
    }
}