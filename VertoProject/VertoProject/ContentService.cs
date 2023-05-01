using ContentLibrary.Logic;
using VertoProject.Models;

namespace VertoProject
{
    public class ContentService
    {
        public ContentModel LoadModel(SectionProcessor sectionProcessor)
        {
            ContentModel model = new();

            model.sectionOne = LoadSectionOne(sectionProcessor);
            model.sectionTwo = LoadSectionTwo(sectionProcessor);
            model.sectionThree= LoadSectionThree(sectionProcessor);

            return model;
        }

        private List<SectionOneCard> LoadSectionOne(SectionProcessor sectionProcessor)
        {
            var sectionOne = sectionProcessor.LoadSectionOne();
            List<SectionOneCard> sectionOneCards = new List<SectionOneCard>();
            foreach (var item in sectionOne)
            {
                sectionOneCards.Add(new SectionOneCard()
                {
                    cardNumber = item.cardNumber,
                    cardHeading = item.cardHeading,
                    cardBody = item.cardBody,
                    cardButton = item.cardButton,
                });
            }
            return sectionOneCards;
        }

        private List<SectionTwoCard> LoadSectionTwo(SectionProcessor sectionProcessor)
        {
            var sectionTwo = sectionProcessor.LoadSectionTwo();
            List<SectionTwoCard> sectionTwoCards = new List<SectionTwoCard>();
            foreach (var item in sectionTwo)
            {
                sectionTwoCards.Add(new SectionTwoCard()
                {
                    cardNumber = item.cardNumber,
                    cardLabel = item.cardLabel,
                    cardOffer = item.cardOffer,
                });
            }
            return sectionTwoCards;
        }

        private List<SectionThreeCard> LoadSectionThree(SectionProcessor sectionProcessor)
        {
            var sectionThree = sectionProcessor.LoadSectionThree();
            List<SectionThreeCard> sectionThreeCards = new List<SectionThreeCard>();
            foreach (var item in sectionThree)
            {
                sectionThreeCards.Add(new SectionThreeCard()
                {
                    cardNumber = item.cardNumber,
                    cardName = item.cardName,
                });
            }
            return sectionThreeCards;
        }

        public void UpdateSectionOne(SectionProcessor sectionProcessor, SectionOneCard card)
        {
            sectionProcessor.updateSectionOne(card.cardNumber, card.cardHeading, card.cardBody, card.cardButton);
        }

        public void UpdateSectionTwo(SectionProcessor sectionProcessor, SectionTwoCard card)
        {
            sectionProcessor.updateSectionTwo(card.cardNumber, card.cardLabel, card.cardOffer);
        }

        public void UpdateSectionThree(SectionProcessor sectionProcessor, SectionThreeCard card)
        {
            sectionProcessor.updateSectionThree(card.cardNumber, card.cardName);
        }


    }
}
