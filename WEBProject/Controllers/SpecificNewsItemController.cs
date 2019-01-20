using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{
    public class SpecificNewsItemController : Controller
    {
        private readonly WebsiteContext C;

        public SpecificNewsItemController(WebsiteContext DB)
        {
            this.C = DB;
        }

        public IActionResult Index(int id)
        {
            ViewData["HeaderBackgroundImg"] = C.Photos.ToList()[58].PhotoPath;
            SpecificNewsItemModel S = new SpecificNewsItemModel();

            News_Item N = C.News_Items.Where(x => x.NewsID == id).FirstOrDefault();
            if (N != null)
            {
                List<string> Content = (from T in C.Text
                                        join TN in C.Text_News on T.TextID equals TN.TextID
                                        join Nn in C.News_Items on TN.NewsID equals Nn.NewsID
                                        where Nn.NewsID == id
                                        select T.Content).ToList();
                S.Content = Content;
                S.Item = N;

                string PhotoPath = (from Nq in C.News_Items
                                    join NP in C.Photo_News on Nq.NewsID equals NP.NewsID
                                    join P in C.Photos on NP.PhotoID equals P.PhotoID
                                    where Nq.NewsID == id
                                    select P.PhotoPath).FirstOrDefault() + "";
                S.PhotoPath = PhotoPath;

            } else
            {
                S.Content = new List<string>();
                S.Item = new News_Item();
                S.PhotoPath = "";
            }

            return View(S);
        }
    }
}