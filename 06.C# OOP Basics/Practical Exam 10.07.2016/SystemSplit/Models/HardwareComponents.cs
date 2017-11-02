using System.Collections.Generic;

namespace SystemSplit.Models
{
    public abstract class HardwareComponents
    {
        public HardwareComponents(string name, int maximumCapacity, int maximumMemory)
        {
            this.Name = name;
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.softwareComponents = new List<SoftwareComponent>();
        }

        private string name;
        private int maximumCapacity;
        private int maximumMemory;
        private int usedMemory;
        private int usedCapacity;
        private List<SoftwareComponent> softwareComponents;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual int MaximumCapacity
        {
            get { return this.maximumCapacity; }
            set { this.maximumCapacity = value; }
        }

        public virtual int MaximumMemory
        {
            get { return this.maximumMemory; }
            set { this.maximumMemory = value; }
        }

        public int UsedCapacity
        {
            get { return this.usedCapacity; }
            set { this.usedCapacity = value; }
        }

        public int UsedMemory
        {
            get { return this.usedMemory; }
            set { this.usedMemory = value; }
        }



        public void AddSoftwareComponent(SoftwareComponent software)
        {
            this.softwareComponents.Add(software);
        }

        public void RemoveSoftwareComponent(SoftwareComponent software)
        {
            this.softwareComponents.Remove(software);
        }

        public List<SoftwareComponent> Software()
        {
            return this.softwareComponents;
        }
    }
}
