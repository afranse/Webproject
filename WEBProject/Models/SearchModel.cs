using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.SearchEngine;

namespace WEBProject.Models
{
    public class SearchModel
    {
        public List<DatabaseObject> DBOList { get; set; }
        public int DisplayedItems { get; set; }
        public string SearchString { get; set; }
    }
}
