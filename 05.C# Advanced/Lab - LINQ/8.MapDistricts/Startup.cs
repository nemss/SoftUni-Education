namespace _8.MapDistricts
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var bound = long.Parse(Console.ReadLine());

            input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(c =>
                {
                    var arguments = c.Split(':');
                    var cityCode = arguments[0];
                    var population = long.Parse(arguments[1]);
                    return new {cityCode, population};
                })
                .GroupBy(c => c.cityCode, c => c.population, 
                (city, popul) => new 
                {
                    CityCode = city, Populations = popul.ToList()
                })
                .Where(x => x.Populations.Sum() >= bound)
                .OrderByDescending(x => x.Populations.Sum())
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.CityCode}: {string.Join(" ", x.Populations.OrderByDescending(o => o).Take(5))}"));
        }
    }
}
