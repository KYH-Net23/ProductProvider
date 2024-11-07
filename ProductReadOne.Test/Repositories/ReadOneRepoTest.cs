using Shared.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReadOne.Test.Repositories
{
    internal class ReadOneRepoTest
    {
        private readonly ProductDbContext _context;
        public ReadOneRepoTest(ProductDbContext context)
        {
            _context = context;
        }
    }
}
