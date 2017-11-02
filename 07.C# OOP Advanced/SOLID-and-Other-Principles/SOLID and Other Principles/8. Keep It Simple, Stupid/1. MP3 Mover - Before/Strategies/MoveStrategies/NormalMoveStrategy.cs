namespace KISSMp3MoverBefore.Strategies.MoveStrategies
{
    using KISSMp3MoverBefore.Contracts;
    using System.IO;

    public class NormalMoveStrategy : IFileMoveStrategy
    {
        public void Move(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }
    }
}