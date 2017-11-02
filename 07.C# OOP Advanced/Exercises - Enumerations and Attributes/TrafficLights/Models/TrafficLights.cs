namespace TrafficLights.Models
{
    using Enums;
    using System;

    public class TrafficLights : ITrafficLight
    {
        public TrafficLights(string light)
        {
            this.Light = (TrafficLight)Enum.Parse(typeof(TrafficLight), light);
        }

        public TrafficLight Light { get; protected set; }

        public void Change()
        {
            this.Light += 1;

            if ((int)this.Light > 2)
            {
                this.Light = 0;
            }
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }
    }
}