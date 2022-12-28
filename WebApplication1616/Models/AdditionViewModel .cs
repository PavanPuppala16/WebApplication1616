using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication1616.Models
{
    public class AdditionViewModel
    {
        public int id { get; set; }
        public int number1 { get; set; }
        public int number2 { get; set; }
        public string action { get; set; }
        public string result { get; set; }
    }
}