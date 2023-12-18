namespace AdventOfCode2023.HandyHaversacks
{
    public static class HandyHaversacks
    {
        public static void Count()
        {
            Console.WriteLine("Handy Haversacks!");
            //string[] lines = File.ReadAllLines("handyhaversacks/input-jeroen.txt");
            string[] lines = File.ReadAllLines("handyhaversacks/input-manoe.txt");

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
