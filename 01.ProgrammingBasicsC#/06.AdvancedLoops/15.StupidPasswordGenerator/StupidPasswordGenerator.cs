using System;

class StupidPasswordGenerator
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var l = int.Parse(Console.ReadLine());


        for (int i = 1; i <=n; i++)
        {
            for (int j = 1; j <=n; j++)
            {
                for (var k ='a'; k < 'a'+l; k++)
                {
                    for (var o ='a'; o < 'a'+l; o++)
                    {
                        for (int p =Math.Max(i,j)+1; p <= n; p++)
                        {
                            Console.Write("{0}{1}{2}{3}{4} ", i, j, k, o, p);
                            
                        }
                    }
                }
            }          
        } 
    }
}

