using System.Text;

namespace AdventOfCode._2020
{
    public static class Day7_HandyHaversacks
    {
        public static List<Bag> OuterBags { get; set; } = new();

        public static void Count()
        {
            //Console.WriteLine("Handy Haversacks!");
            //string[] lines = File.ReadAllLines("inputs/day1-jeroen.txt");
            string[] lines = File.ReadAllLines("inputs/day1.txt");

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

                foreach (var existingBag in existingBags)
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

    public class Bag
    {
        public string BagType { get; set; }

        public List<Bag> Bags { get; set; } = new();

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var bag in Bags)
            {
                builder.Append($"{bag.BagType}, ");
            }

            return builder.ToString();
        }

        //public bool ContainsBagType(string bagType)
        //{
        //    foreach (var bag in Bags)
        //    {
        //        if (bag.Bags.Count > 0)
        //        {
        //            return bag.ContainsBagType(bagType);
        //        }
        //    }

        //    return false;
        //}


        public bool ContainsBagType(string bagType)
        {
            // nu check voor iedere outerbag of die een innerbag heeft met bagtype shiny gold of een van zn kinderen.
            // dit moet dus recursief
            //var bla = Bags.Any(x => x.BagType == bagType.Any(y => y.);

            if (bagType == BagType) { return true; }

            if (Bags.Any())
            {
                var blas = Bags.Select(x => x.ContainsBagType(x.BagType));
                return blas.ToList().Any(x => x == true);
            }

            return false;
        }

        public List<Bag> GetInnerBags()
        {
            // Bag.BagType = "posh brown", has 4 inner bags with the following bagTypes ["dim coral", "plaid blue", "faded bronze", "light black"]
            // at the point where the child bag does not have any more bags, a new list is returned instead of what was already created. Is it overwritten?
            var innerBags = new List<Bag>();

            if (Bags.Any())
            {
                // dim coral returns an empty list
                // plaid blue returns an empty list
                // faded bronze returns an empty list
                // light black returns an empty list
                // All the empty lists are now concatenated into one empty list

                // I forgot the outer bag itself
                //return Bags.SelectMany(x => x.GetInnerBags()).ToList();
                innerBags.AddRange(Bags.SelectMany(x => x.GetInnerBags()).ToList());
            }
            //} else
            //{
            //    return new List<Bag>();
            //}

            innerBags.Add(this);

            return innerBags;
        }

        public Bag DeepCopy(Bag bag)
        {
            return new() { BagType = bag.BagType, Bags = bag.Bags.ConvertAll(x => DeepCopy(x)) };
        }
    }
}
