using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuperShapeCalculator
{
    public class ShapeDataEntryModel : PageModel
    {
        [BindProperty]
        public string Shape { get; set; }
        
        [BindProperty]
        public string Area { get; set; }

        [BindProperty]
        public string Radius { get; set; }

        [BindProperty]
        public string vBase {get; set;}

        [BindProperty]
        public string vHeight { get; set; }

        [BindProperty]
        public string vSide { get; set; }

        public void OnGet(string shape)
        {
            Shape = shape;
        }

        public string calcArea (string shape)
        {
            Shape = shape;
            double calcShape = 0;
            switch (shape)
            {
                case "circle":
                    double cRadius = Convert.ToDouble(Radius);
                    calcShape = Math.PI * (Math.Pow(cRadius, 2));
                    Area = calcShape.ToString();
                    break;

                case "triangle":
                    double cBase = Convert.ToInt32(vBase);
                    double cHeight = Convert.ToInt32(vHeight);
                    calcShape = ((cBase * cHeight) / 2);
                    Area = calcShape.ToString();
                    break;

                case "square":
                    cBase = Convert.ToInt32(vBase);
                    cHeight = Convert.ToInt32(vHeight);
                    calcShape = (cBase * cHeight);
                    Area = calcShape.ToString();
                    break;

                case "pentagon":
                    double cSide = Convert.ToDouble(vSide);
                    calcShape = (0.25 * (Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5)))) * Math.Pow(cSide, 2));
                    Area = calcShape.ToString();
                    break;

                default:
                    Area = "";
                    break;                
            }
            return Area;
        }

        public IActionResult OnPost(string shape)
        {
            Area = calcArea(Shape);
            return RedirectToPage("./calc", new { shape = Shape, area = Area, radius = Radius, vbase = vBase, vheight = vHeight, vside = vSide });
        }
        
    }
}
