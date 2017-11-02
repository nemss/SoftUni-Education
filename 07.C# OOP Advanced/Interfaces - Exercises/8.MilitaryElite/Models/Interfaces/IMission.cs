namespace _8.MilitaryElite.Models.Interfaces
{
    using _8.MilitaryElite.Enum;

    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }

        void CompleteMission();
    }
}