namespace SystemSplit.Models
{
    public class ExpressSoftwareComponent : SoftwareComponent
    {
        public ExpressSoftwareComponent(string name, int capacityConsumption, int memoryConsumption) 
            : base(name, capacityConsumption, memoryConsumption)
        {
            this.MemoryConsumption = memoryConsumption;
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption; }
            set { base.MemoryConsumption = value * 2; }
        }
    }
}
