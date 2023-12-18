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
    }
}
