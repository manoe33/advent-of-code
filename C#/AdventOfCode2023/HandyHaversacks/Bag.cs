using System.Text;

namespace AdventOfCode2023.HandyHaversacks
{
    public class Bag
    {
        public string BagType { get; set; }

        public List<Bag> Bags { get; set; } = new();

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach(var bag in Bags)
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
