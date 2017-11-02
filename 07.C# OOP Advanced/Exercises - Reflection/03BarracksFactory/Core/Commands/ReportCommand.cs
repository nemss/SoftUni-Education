using _03BarracksFactory.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
