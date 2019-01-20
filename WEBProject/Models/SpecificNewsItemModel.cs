using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBProject.Models
{
    public class SpecificNewsItemModel
    {
        public List<string> Content { get; set; }
        public News_Item Item { get; set; }
        public string PhotoPath { get; set; }
    }
}
