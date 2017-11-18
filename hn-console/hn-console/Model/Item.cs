using System.Collections.Generic;

namespace hn_console.Model
{
    public class Item
    {
        public int id { get; set; }
        public bool deleted { get; set; }
        public string type { get; set; }
        public string by { get; set; }
        public string time { get; set; } // Unix time string
        public string text { get; set; }
        public bool dead { get; set; }
        public int parent { get; set; }
        public int poll { get; set; }
        public int[] kids { get; set; }
        public List<Item> children { get; set; }
        public string url { get; set; }
        public int score { get; set; }
        public string title { get; set; }
        public int[] parts { get; set; }
        public int descendents { get; set; }
    }
}
