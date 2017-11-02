namespace BashSoft.Commands
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.Attributes;

    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}