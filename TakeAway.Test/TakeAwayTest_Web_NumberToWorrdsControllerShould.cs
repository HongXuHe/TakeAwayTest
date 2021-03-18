using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TakeAwayTest.Web.Controllers;
using TakeAwayTest.Web.Models;
using Xunit;

namespace TakeAway.Test
{
    public class TakeAwayTest_Web_NumberToWorrdsControllerShould
    {
        [Fact]
        public void IndexTest()
        {
            var controller = new NumberToWordsController();
            var actionRes = controller.Index(null);
            Assert.IsType<ViewResult>(actionRes);
        }

        [Fact]
        public void PersonTransformerGetTest()
        {
            var controller = new NumberToWordsController();
            var actionRes = controller.PersonTransformer();
            Assert.IsType<ViewResult>(actionRes);
        }

        [Fact]
        public void PersonTransformerPostValidTest()
        {
            var controller = new NumberToWordsController();
            var actionRes = controller.PersonTransformer(new PersonDto(){ Name = "test", Number = 1});
            Assert.IsType<RedirectToActionResult>(actionRes);
        }
        [Fact]
        public void PersonTransformerPostNotValidTest()
        {
            var controller = new NumberToWordsController();
            controller.ModelState.AddModelError("", "ModelError");
            var actionRes = controller.PersonTransformer(new PersonDto() { Name = "test", Number = 1 });
            Assert.IsType<ViewResult>(actionRes);
        }
    }
}
