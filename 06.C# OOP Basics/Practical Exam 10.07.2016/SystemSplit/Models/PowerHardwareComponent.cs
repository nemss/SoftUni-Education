namespace SystemSplit.Models
{
    public class PowerHardwareComponent : HardwareComponents
    {
        public PowerHardwareComponent(string name, int maximumCapacity, int maximumMemory)
            : base(name, maximumCapacity, maximumMemory)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity; }
            set { base.MaximumCapacity = value - ((value * 3) / 4); }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory; }
            set { base.MaximumMemory = value + (value * 3) / 4; }
        }
    }
}
