using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace SystemSplit.Models
{
    public static class Command
    {
        public static void RegisterPowerHardware(List<HardwareComponents> computer, string command)
        {
            var tokens = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var name = tokens[0];
            var capacity = int.Parse(tokens[1]);
            var memory = int.Parse(tokens[2]);
            if (!computer.Any(x => x.Name == name))
            {
                computer.Add(new PowerHardwareComponent(name, capacity, memory));
            }
        }

        public static void RegisterHeavyHardware(List<HardwareComponents> computer, string command)
        {
            var tokens = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var name = tokens[0];
            var capacity = int.Parse(tokens[1]);
            var memory = int.Parse(tokens[2]);
            if (!computer.Any(x => x.Name == name))
            {
                computer.Add(new HeavyHardwareComponent(name, capacity, memory));
            }
        }

        public static void RegisterExpressSoftware(List<HardwareComponents> computer, string command)
        {
            var tokens = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var hardwareName = tokens[0];
            var softwareName = tokens[1];
            var capacity = int.Parse(tokens[2]);
            var memory = int.Parse(tokens[3]);

            if (computer.Any(x => x.Name == hardwareName))
            {
                var hardware = computer.FirstOrDefault(x => x.Name == hardwareName);
                if (hardware.MaximumCapacity - hardware.UsedCapacity >= capacity &&
                    hardware.MaximumMemory - hardware.UsedMemory >= memory)
                {
                    SoftwareComponent software = new ExpressSoftwareComponent(softwareName, capacity, memory);
                    hardware.AddSoftwareComponent(software);
                    hardware.UsedCapacity += software.CapacityConsumption;
                    hardware.UsedMemory += software.MemoryConsumption;
                }
            }
        }

        public static void RegisterLightSoftware(List<HardwareComponents> computer, string command)
        {
            var tokens = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var hardwareName = tokens[0];
            var softwareName = tokens[1];
            var capacity = int.Parse(tokens[2]);
            var memory = int.Parse(tokens[3]);

            if (computer.Any(x => x.Name == hardwareName))
            {
                var hardware = computer.FirstOrDefault(x => x.Name == hardwareName);
                if (hardware.MaximumCapacity - hardware.UsedCapacity >= capacity &&
                    hardware.MaximumMemory - hardware.UsedMemory >= memory)
                {
                    SoftwareComponent software = new LightSoftwareComponent(softwareName, capacity, memory);
                    hardware.AddSoftwareComponent(software);
                    hardware.UsedCapacity += software.CapacityConsumption;
                    hardware.UsedMemory += software.MemoryConsumption;
                }
            }
        }

        public static void ReleaseSoftwareComponent(List<HardwareComponents> computer, string command)
        {
            var tokens = command.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var hardwareName = tokens[0];
            var softwareName = tokens[1];

            if (computer.Any(x => x.Name == hardwareName))
            {
                var hardware = computer.FirstOrDefault(x => x.Name == hardwareName);

                if (hardware.Software().Any(x => x.Name == softwareName))
                {
                    SoftwareComponent software = hardware.Software().FirstOrDefault(x => x.Name == softwareName);
                    hardware.RemoveSoftwareComponent(software);
                    hardware.UsedCapacity -= software.CapacityConsumption;
                    hardware.UsedMemory -= software.MemoryConsumption;
                }
                    
            }
        }

        public static void Analyze(List<HardwareComponents> computer)
        {
            var sb = new StringBuilder();
            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {computer.Count}");
            sb.AppendLine($"Software Components: {computer.Sum(x => x.Software().Count)}");
            sb.AppendLine(
                $"Total Operational Memory: {computer.Select(x => x.UsedMemory).Sum()} / {computer.Select(x => x.MaximumMemory).Sum()}");
            sb.Append(
                $"Total Capacity Taken: {computer.Select(x => x.UsedCapacity).Sum()} / {computer.Select(x => x.MaximumCapacity).Sum()}");
            Console.WriteLine(sb.ToString());
        }

        public static void SystemSplit(List<HardwareComponents> computer)
        {
            var sb = new StringBuilder();
            foreach (var hardware in computer.Where(x => x is PowerHardwareComponent))
            {
                sb.AppendLine($"Hardware Component - {hardware.Name}");
                sb.AppendLine(
                    $"Express Software Components - {hardware.Software().Count(x => x is ExpressSoftwareComponent)}");
                sb.AppendLine(
                    $"Light Software Components - {hardware.Software().Count(x => x is LightSoftwareComponent)}");
                sb.AppendLine($"Memory Usage: {hardware.UsedMemory} / {hardware.MaximumMemory}");
                sb.AppendLine($"Capacity Usage: {hardware.UsedCapacity} / {hardware.MaximumCapacity}");
                sb.AppendLine("Type: Power");

                if (hardware.Software().Count > 0)
                {
                    sb.Append($"Software Components: {string.Join(", ", hardware.Software().Select(s => s.Name))}");
                }
                else
                {
                    sb.Append("Software Conponents: None");
                }
            }

            Console.WriteLine(sb.ToString());
            sb.Clear();

            foreach (var  hardware in computer.Where(x => x is HeavyHardwareComponent))
            {
                sb.AppendLine($"Hardware Component - {hardware.Name}");
                sb.AppendLine(
                    $"Express Software Components - {hardware.Software().Count(x => x is ExpressSoftwareComponent)}");
                sb.AppendLine(
                    $"Light Software Components - {hardware.Software().Count(x => x is LightSoftwareComponent)}");
                sb.AppendLine($"Memory Usage: {hardware.UsedMemory} / {hardware.MaximumMemory}");
                sb.AppendLine($"Capacity Usage: {hardware.UsedCapacity} / {hardware.MaximumCapacity}");
                sb.AppendLine("Type: Heavy");

                if (hardware.Software().Count > 0)
                {
                    sb.Append($"Software Components: {string.Join(", ", hardware.Software().Select(x => x.Name))}");
                }
                else
                {
                    sb.Append("Software Components: None");
                }

                Console.WriteLine(sb.ToString());
            }
        }

        public static void Dump(List<HardwareComponents> dump, List<HardwareComponents> computer, string hardwareName)
        {
            if (computer.Any(c => c.Name == hardwareName))
            {
                HardwareComponents hardware = computer.FirstOrDefault(h => h.Name == hardwareName);
                computer.Remove(hardware);
                dump.Add(hardware);
            }
        }

        public static void Restore(List<HardwareComponents> dump, List<HardwareComponents> computer,
            string hardwareName)
        {
            if (dump.Any(d => d.Name == hardwareName))
            {
                HardwareComponents hardware = dump.FirstOrDefault(d => d.Name == hardwareName);
                dump.Remove(hardware);
                computer.Add(hardware);
            }
        }

        public static void Destroy(List<HardwareComponents> dump, string hardwareName)
        {
            if (dump.Any(d => d.Name == hardwareName))
            {
                dump.Remove(dump.FirstOrDefault(d => d.Name == hardwareName));
            }
        }

        public static void DumpAnalyze(List<HardwareComponents> dump)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Dump Analysis");
            sb.AppendLine($"Power Hardware Components: {dump.Count(x => x is PowerHardwareComponent)}");
            sb.AppendLine($"Heavy Hardware Components: {dump.Count(x => x is HeavyHardwareComponent)}");
            sb.AppendLine($"Express Software Components: {dump.Sum(x => x.Software().Count(e => e is ExpressSoftwareComponent))}");
            sb.AppendLine($"Light Software Components: {dump.Sum(x => x.Software().Count(l => l is LightSoftwareComponent))}");
            sb.AppendLine($"Total Dumped Memory: {dump.Select(x => x.UsedMemory).Sum()}");
            sb.Append($"Total Dumped Capacity: {dump.Select(x => x.UsedCapacity).Sum()}");

            Console.WriteLine(sb.ToString());
        }
    }
}
