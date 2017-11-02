using System;

class Hospital
{
    static void Main()
    {
        var period = int.Parse(Console.ReadLine());
        var doctors = 7;
        var treatedPatients = 0;
        var untreadPatients = 0;

        for (int day = 1; day <= period; day++)
        {
            var currentPatients = int.Parse(Console.ReadLine());

            if (day %3==0 && untreadPatients>treatedPatients)
            {
                doctors++;
            }
            if (currentPatients > doctors)
            {
                treatedPatients += doctors;
                untreadPatients += currentPatients - doctors;
            }
            else
            {
                treatedPatients += currentPatients;
            }
        }
        Console.WriteLine("Treated patients: {0}.", treatedPatients);
        Console.WriteLine("Untreated patients: {0}.", untreadPatients);
    }
}

