using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VertoProject.Models;
using ContentLibrary.Logic;
using ContentLibrary.Models;

namespace VertoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly SectionProcessor _sectionProcessor;
        private readonly ContentService _contentService;

        public HomeController(IConfiguration config)
        {
            _sectionProcessor = new(config.GetValue<string>("ConnectionStrings:SQLDbConnection"));
            _contentService = new ContentService();
        }

        public IActionResult Index()
        {
            ContentModel Content = _contentService.LoadModel(_sectionProcessor);

            return View(Content);
        }

        public IActionResult Cms()
        {

            ContentModel Content = _contentService.LoadModel(_sectionProcessor);

            return View(Content);
        }

        public ActionResult SectionOne(IFormCollection values)
        {
            SectionOneCard temp = new SectionOneCard();
            string card = values["cards"];
            temp.cardNumber = int.Parse(card[card.Length-1].ToString());
            temp.cardHeading = values["cardHeading"];
            temp.cardBody = values["cardBody"];
            temp.cardButton = values["buttonText"];

            _contentService.UpdateSectionOne(_sectionProcessor, temp);

            return View("Cms");
        }

        public ActionResult SectionTwo(IFormCollection values)
        {
            SectionTwoCard temp = new SectionTwoCard();
            string card = values["cardsOffer"];
            temp.cardNumber = int.Parse(card[card.Length - 1].ToString());
            temp.cardLabel = values["cardLabel"];
            temp.cardOffer = values["cardOffer"];

            _contentService.UpdateSectionTwo(_sectionProcessor, temp);

            return View("Cms");
        }

        public ActionResult SectionThree(IFormCollection values)
        {
            SectionThreeCard temp = new SectionThreeCard();
            string card = values["cardsCategories"];
            temp.cardNumber = int.Parse(card[card.Length - 1].ToString());
            temp.cardName = values["cardName"];

            _contentService.UpdateSectionThree(_sectionProcessor, temp);

            return View("Cms");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}