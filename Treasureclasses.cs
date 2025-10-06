using System.Collections;

namespace Treasure_Grabber
{
    public struct Treasure
    {
        public string name;
        public int value;
        public int weight;
        public double weightedValue;

        public Treasure(string name, int value, int weight)
        {
            this.name = name;
            this.value = value;
            this.weight = weight;
            this.weightedValue = (double)value/weight;
        }
    }
    public struct Bag
    {
        public int maxWeight;
        public ArrayList container;

        public Bag(int weight)
        {
            maxWeight = weight;
            container = new ArrayList();
        }
    }
}

