using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;
using WEBProject.SearchEngine;
using Microsoft.EntityFrameworkCore;

namespace WEBProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly WebsiteContext DBC;
        public List<DatabaseObject> DBO { get; } // This list gets the correct result at the end of the queries.

        public SearchController(WebsiteContext context)
        {
            this.DBC = context;
            DBO = new List<DatabaseObject>();
        }

        public async Task<IActionResult> Index(string q, int? i)
        {
            SearchModel SearchModel = new SearchModel();
            if (q != null)
            {
                SearchModel.DBOList = await SearchEngine(q);
                SearchModel.DisplayedItems = i ?? 20;
            } else
            {
                SearchModel.DBOList = new List<DatabaseObject>();
            }
            SearchModel.SearchString = q;
            return View(SearchModel);
        }

        public async Task<List<DatabaseObject>> SearchEngine(string Input)
        // At first we wanted to use a priorityqueue, but because we wanted to use the data from four tables it was not possible to use a priority queue(dictionary).
        // This method splits the string input into individual words and then proceeds to search through all four tables on these words.
        // After each query the data will be added through a for loop to the DBO list.
        {
            string[] Inputs = Input.Split(" ");

            for (int i = 0; i < Inputs.Count(); i++)
            {
                IEnumerable<Product> P = await DBC.Products.Where(p => p.Name.ToLower().Contains(Inputs.ElementAt(i).ToLower())).ToListAsync(); // Search through Products -> Name (without capitals)
                for (int p = 0; p < P.Count(); p++)
                {
                    AddDBO(P.ElementAt(p), new ProductSearch(DBC));
                }
                IEnumerable<Recipe> R = await DBC.Recipes.Where(p => p.Name.ToLower().Contains(Inputs.ElementAt(i).ToLower())).ToListAsync(); // Search through Recipes -> Name (without capitals)
                for (int r = 0; r < R.Count(); r++)
                {
                    AddDBO(R.ElementAt(r), new RecipeSearch(DBC));
                }
                IEnumerable<News_Item> I = await DBC.News_Items.Where(p => p.Title.ToLower().Contains(Inputs.ElementAt(i).ToLower())).ToListAsync(); // Search through News_Items -> Title (without capitals)
                for (int ix = 0; ix < I.Count(); ix++)
                {
                    AddDBO(I.ElementAt(ix), new NewsSearch(DBC));
                }
                IEnumerable<Employee_Profile> E = await DBC.Employee_Profiles.Where(p => p.Name.ToLower().Contains(Inputs.ElementAt(i).ToLower())).ToListAsync(); // Search through Emloyee_Profiles -> Name (without capitals)
                for (int e = 0; e < E.Count(); e++)
                {
                    AddDBO(E.ElementAt(e), new EmployeeSearch(DBC));
                }
            }

            // This order by statement sorts the result on the amount of hits found with the previous search.
            // How the counter works can be found in the DatabaseObject class and its children.
            DBO.OrderBy(f => f.GetCounter());
            return DBO;
        }

        public void AddDBO(object Uknown, DatabaseObject O)
        // This method checks if an object is already in the DBO list or not.
        // Whenever the object already exists, it won't be added.
        // The counter event happens within the Count() method of DBO.
        {
            bool Exists = false;
            for (int i = 0; i < DBO.Count(); i++)
            {
                if (DBO.ElementAt(i).Check(Uknown))
                {
                    Exists = true;
                    break;
                }
            }
            if (Exists == false)
            {
                O.SetObject(Uknown);
                DBO.Add(O);
            }
        }
    }
}