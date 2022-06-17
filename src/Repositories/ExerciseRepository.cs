using ExponentialGrowth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExponentialGrowth.Repositories
{
    public class ExerciseRepository : Repository<Exercise>
    {
        public ExerciseRepository(string dbPath) : base(dbPath)
        {
        }

    }
}

