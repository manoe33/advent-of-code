namespace AdventOfCode2023.HandyHaversacks
{
    public static class HandyHaversacks
    {
        public static List<Bag> OuterBags { get; set; } = new();

        public static void Count()
        {
            //Console.WriteLine("Handy Haversacks!");
            string[] lines = File.ReadAllLines("handyhaversacks/input-jeroen.txt");
            //string[] lines = File.ReadAllLines("handyhaversacks/input-manoe.txt");

            foreach (var line in lines)
            {
                var bag = new Bag();
                var splitOnContain = line.Split("contain");
                // For example: new Bag { BagType = "light red" }
                bag.BagType = splitOnContain[0].Replace("bags", "").Trim();

                foreach (var part in splitOnContain[1].Split(","))
                {
                    // For example: part = " 2 muted yellow bags"
                    // For example: bagType = "2 muted yellow"
                    var bagType = part.Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
                    if (bagType == "no other")
                    {
                        continue;
                    }
                    // For example: bagType = "muted yellow"
                    bagType = bagType.Substring(1).Trim();

                    // Add new bag to list of innerBags, and set the type
                    bag.Bags.Add(new Bag { BagType = bagType });
                }

                // Add the outerbag to the list of outerbags
                OuterBags.Add(bag);

                var processedBags = OuterBags.SelectMany(bag => bag.GetInnerBags());
                var existingBags = processedBags.Where(x => x.BagType == bag.BagType).ToList();
                //existingBag.Bags = bag.Bags.ConvertAll<Bag>();

                foreach(var existingBag in existingBags)
                {
                    existingBag.Bags = bag.Bags.ConvertAll<Bag>(x => new Bag { BagType = x.BagType, Bags = x.Bags });
                }


                // todo: check if bag.BagType already exists
                //OuterBags.SelectMany(x => x.)

                // todo: de kinderen hebben nog geen bags. Deze moet je nog toevoegen, hoe dan?
                // Ofja, de kinderen hebben wel bags, maar die zit nog in de outerbags.
                // Dus dan moet je in de outerbags zoeken of die er al bijzit en dan de kinderen overnemen. Gaat nergens meer v
                Console.WriteLine($"BagType: {bag.BagType}, Bags: {bag}");
            }

            var count = (from bag in OuterBags
                         where bag.ContainsBagType("shiny gold")
                         select bag).Count();

            var count2 = OuterBags.Select(x => x.ContainsBagType("shiny gold")).Count();

            Console.WriteLine($"Answer: {count}");
            Console.WriteLine($"Answer2: {count2}"); // 594 = wrong
        }
    }
}
