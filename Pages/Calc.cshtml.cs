using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuperShapeCalculator.Pages
{
    public class CalcModel : PageModel
    {
        [BindProperty]
        public string Area {get; set;}

        [BindProperty]
        public string Shape { get; set; }

        [BindProperty]
        public string Radius { get; set; }

        [BindProperty]
        public string vBase { get; set; }

        [BindProperty]
        public string vHeight { get; set; }

        [BindProperty]
        public string vSide { get; set; }

        public void OnGet(string shape, string area, string radius, string vbase, string vheight, string vside)
        {
            Area = Math.Round(Convert.ToDouble(area),2).ToString();
            if (Area == "0")
            {
                Area = "Undefined...";
            }
            Shape = shape;
            Radius = radius;
            vBase = vbase;
            vHeight = vheight;
            vSide = vside;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}
