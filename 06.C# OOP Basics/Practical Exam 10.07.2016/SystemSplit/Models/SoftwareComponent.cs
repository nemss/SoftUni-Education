namespace SystemSplit.Models
{
    public class SoftwareComponent
    {
        public SoftwareComponent(string name, int capacityConsumption, int memoryConsumption)
        {
            this.Name = name;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        private string name;
        private int capacityConsumption;
        private int memoryConsumption;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual int CapacityConsumption
        {
            get { return this.capacityConsumption; }
            set { this.capacityConsumption = value; }
        }

        public virtual int MemoryConsumption
        {
            get { return this.memoryConsumption; }
            set { this.memoryConsumption = value; }
        }


    }
}
