using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.Models
{
    public class PageContent
    {
        private readonly WebsiteContext _context;

        public List<PageContent> Pages = new List<PageContent>();
        public List<string> Photos = new List<string>();
        public List<string> Texts = new List<string>();

        public PageContent(WebsiteContext context)
        {
            _context = context;
        }

        public PageContent(int[] photoList, int[] textList, WebsiteContext context)
        {
            _context = context;
            this.Photos = _context.Photos.Where(i => photoList.Contains(i.PhotoID)).Select(s => s.PhotoPath).ToList();
            this.Texts = _context.Text.Where(i => textList.Contains(i.TextID)).Select(s =>s.Content).ToList();
        }

        public void addPage(PageContent page)
        {
            Pages.Add(page);
        }

    }
}


    
