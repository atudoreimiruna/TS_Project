using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.DAL.Entities
{
    public class Reader
    {
        public int Id { get; set; }

        public int BooksRead { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
