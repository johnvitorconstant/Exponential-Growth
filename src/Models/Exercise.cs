using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExponentialGrowth.Models
{
    internal class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), NotNull]
        public String Name { get; set; }
        
        [MaxLength(250), NotNull]
        public String Category { get; set; }
        public double MinimumLoad { get; set; }
        public double MaximumLoad { get; set; }
        public string ImagePath { get; set; }


        public Exercise()
        {

        }

        public Exercise(string name, string category, double minimumLoad, double maximumLoad)
        {
            Name = name;
            Category = category;
            MinimumLoad = minimumLoad;
            MaximumLoad = maximumLoad;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
