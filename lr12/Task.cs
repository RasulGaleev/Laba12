using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr12
{
    public class Task
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Client { get; set; }

        public string Item { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}