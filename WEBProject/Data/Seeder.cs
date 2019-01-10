using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBProject.Data
{
    public class Seeder
    {
        private readonly WebsiteContext _context;

        public Seeder(WebsiteContext context)
        {
            _context = context;
            Seed();
        }

        private void Seed()
        {
            List<WEBProject.Models.Branch_Category> Branches = new List<Models.Branch_Category>
            {
                new Models.Branch_Category(){ Name = "Aardappel, Groente, Fruit"},
                new Models.Branch_Category(){ Name = "Kant-en-Klaar, Salades"},
                new Models.Branch_Category(){ Name = "Vlees, Kip, Vis, Vega"},
                new Models.Branch_Category(){ Name = "Kaas, Vleeswaren, Delicatessen"},
                new Models.Branch_Category(){ Name = "Zuivel, Eieren"},
                new Models.Branch_Category(){ Name = "Bakkerij"},
                new Models.Branch_Category(){ Name = "Ontbijtgranen, broodbeleg, Tussendoor"},
                new Models.Branch_Category(){ Name = "Frisdrank, Sappen, Koffie, Thee"},
                new Models.Branch_Category(){ Name = "Bier, Sterke drank, Apperatieven"},
                new Models.Branch_Category(){ Name = "Pasta, Rijst, Internationale keuken"},
                new Models.Branch_Category(){ Name = "Soepen, Conserven, Sauzen, Smaakmakers"},
                new Models.Branch_Category(){ Name = "Sneop, Koek, Chips"},
                new Models.Branch_Category(){ Name = "Diepvries"},
                new Models.Branch_Category(){ Name = "Bewuste voeding"},
        };
            if (_context.Branch_Categories.Count() == 0)
            {
                foreach(Models.Branch_Category B in Branches)
                {
                    _context.Branch_Categories.Add(B);
                }
            }
            else
            {
                for (int i = 0; i < Branches.Count(); i++)
                {
                    if (i > _context.Branch_Categories.Count() - 1)
                    {
                        _context.Branch_Categories.Add(Branches[i]);
                    }
                    else
                    {
                        if (!_context.Branch_Categories.ToList()[i].Name.Equals(Branches[i].Name))
                        {
                            _context.Branch_Categories.ToList()[i].Name = Branches[i].Name;
                        }
                    }
                }
            }
            List<WEBProject.Models.Type_Category> Types = new List<Models.Type_Category>
            {
                new Models.Type_Category(){Name = "Vegetable", BranchID = _context.Branch_Categories.ToList()[0].BranchID, BranchCategory = _context.Branch_Categories.ToList()[0]},
                new Models.Type_Category(){Name = "Fruit", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "1", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "2", BranchID = _context.Branch_Categories.ToList()[3].BranchID, BranchCategory = _context.Branch_Categories.ToList()[3]},
                new Models.Type_Category(){Name = "3", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "4", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "5", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "6", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "7", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "8", BranchID = _context.Branch_Categories.ToList()[1].BranchID, BranchCategory = _context.Branch_Categories.ToList()[1]},
                new Models.Type_Category(){Name = "9", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "10", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "11", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "12", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "13", BranchID = _context.Branch_Categories.ToList()[2].BranchID, BranchCategory = _context.Branch_Categories.ToList()[2]},
                new Models.Type_Category(){Name = "Hello there", BranchID = _context.Branch_Categories.ToList()[4].BranchID, BranchCategory = _context.Branch_Categories.ToList()[4]}

            };
            if (_context.Type_Categories.Count() == 0)
            {
                foreach (Models.Type_Category T in Types)
                {
                    _context.Type_Categories.Add(T);
                }
            }
            else
            {
                for (int i = 0; i < Types.Count(); i++)
                {
                    if (i > _context.Type_Categories.Count() - 1)
                    {
                        _context.Type_Categories.Add(Types[i]);
                    }
                    else
                    {
                        if (!_context.Type_Categories.ToList()[i].Name.Equals(Types[i].Name))
                        {
                            _context.Type_Categories.ToList()[i].Name = Types[i].Name;
                        }
                    }
                }
            }


            _context.SaveChanges();
        }
    }
}

