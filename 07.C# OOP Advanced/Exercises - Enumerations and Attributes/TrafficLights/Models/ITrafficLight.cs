using TrafficLights.Enums;

namespace TrafficLights.Models
{
    public interface ITrafficLight
    {
        TrafficLight Light { get; }

        void Change();
    }
}