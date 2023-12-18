using Newtonsoft.Json;
using System.Text.Json;

namespace AdventOfCode2023.HandyHaversacks
{
    public static class HandyHaversacks
    {


        public static void Count()
        {
            //Console.WriteLine("Handy Haversacks!");
            //string[] lines = File.ReadAllLines("handyhaversacks/input-jeroen.txt");
            string[] lines = File.ReadAllLines("handyhaversacks/input-manoe.txt");

            var outerBags = new List<Bag>();

            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                //dull bronze bags contain [2 muted white bags, 2 faded orange bags, 1 plaid blue bag].
                //var bagType = [2 muted white, 2 faded orange, 1 plaid blue].
                // 2mutedwhite
                //mutedwhite
                var bag = new Bag();
                //bag.BagType =
                var splitOnContain = line.Split("contain");
                bag.BagType = splitOnContain[0].Replace("bags", "").Trim();

                foreach (var part in splitOnContain[1].Split(","))
                {
                    var bagType = part.Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
                    if (bagType == "no other")
                    {
                        continue;
                    }
                    //var bagCount = bagType.Substring(0, 1);
                    bagType = bagType.Substring(1).Trim();
                    //Console.WriteLine($"BagType: {bagType} BagCount: {bagCount}");
                    // hier roepen we dalijk iets recursiefs aan om de bags te vullen
                    // check eerst of die al in de lijst staat

                    // first check if bagType already exists in bags



                    //Console.WriteLine($"BagType: {bagType}");
                    bag.Bags.Add(new Bag { BagType = bagType });
                }

                outerBags.Add(bag);
                Console.WriteLine($"BagType: {bag.BagType}, Bags: {bag.ToString()}");

                // loop through the remaining line string


            }
        }
    }
}
