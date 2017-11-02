namespace _8.MilitaryElite.Models
{
    using _8.MilitaryElite.Enum;
    using _8.MilitaryElite.Models.Interfaces;

    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }
        public MissionState State { get; protected set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}