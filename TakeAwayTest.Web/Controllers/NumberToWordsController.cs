using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TakeAwayTest.Utility;
using TakeAwayTest.Web.Models;

namespace TakeAwayTest.Web.Controllers
{
    public class NumberToWordsController : Controller
    {
     
        public IActionResult Index(PersonResultDto resultDto)
        {
            return View(resultDto);
        }
        public IActionResult PersonTransformer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonTransformer(PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                var data = Util.ConvertNumberToMoney(personDto.Number.ToString());
                if (data != null)
                {
                    var result = new PersonResultDto
                    {
                        Name = personDto.Name,
                        Words = data
                    };
                    return RedirectToAction(nameof(Index), result);
                }
               
                ModelState.AddModelError("", "Transfer number out of range");
                
            }
            
            return View(personDto);
        }
    }
}
