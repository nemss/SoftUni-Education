﻿namespace _2.ClassBoxDataValidation
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                Type boxType = typeof(Box);
                FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields.Count());

                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);
                box.SurfaceArea();
                box.LateralSurfaceArea();
                box.Volume();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }   
}
