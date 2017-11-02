using System.Security.AccessControl;

namespace SystemSplit.Models
{
    public class HeavyHardwareComponent : HardwareComponents
    {
        public HeavyHardwareComponent(string name, int maximumCapacity, int maximumMemory)
            : base(name, maximumCapacity, maximumMemory)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity; }
            set { base.MaximumCapacity = value * 2; }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory; }
            set { base.MaximumMemory = value - value / 4; }
        }
    }
}
