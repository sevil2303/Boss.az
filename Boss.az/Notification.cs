using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    public class Notification
    {
        public int Number { get; set; }
        public string Message { get; set; }
        public void Show()
        {
            Console.WriteLine(Message);
        }
    }
}
