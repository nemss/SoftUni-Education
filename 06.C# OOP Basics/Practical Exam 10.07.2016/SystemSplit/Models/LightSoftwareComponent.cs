namespace SystemSplit.Models
{
    public class LightSoftwareComponent : SoftwareComponent
    {
        public LightSoftwareComponent(string name, int capacityConsumption, int memoryConsumption) 
            : base(name, capacityConsumption, memoryConsumption)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        public override int CapacityConsumption
        {
            get { return base.CapacityConsumption; }
            set { base.CapacityConsumption = value + value / 2; }
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption; }
            set { base.MemoryConsumption = value - value / 2; }
        }
    }
}
