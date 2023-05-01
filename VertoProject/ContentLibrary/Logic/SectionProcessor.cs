using ContentLibrary.DataAccess;
using ContentLibrary.Models;

namespace ContentLibrary.Logic
{
    public class SectionProcessor
    {
        private SqlDataAccess _sqlDataAccess = new("");

        public SectionProcessor(string connectionString)
        {
            _sqlDataAccess = new(connectionString);
        }

        public List<SectionOneCardModel> LoadSectionOne()
        {
            string sql = @"SELECT Id, cardNumber, cardHeading, cardBody, cardButton from dbo.SectionOne";
            return _sqlDataAccess.LoadData<SectionOneCardModel>(sql);
        }

        public List<SectionTwoCardModel> LoadSectionTwo()
        {
            string sql = @"SELECT Id, cardNumber, cardLabel, cardOffer from dbo.SectionTwo";

            return _sqlDataAccess.LoadData<SectionTwoCardModel>(sql);
        }

        public List<SectionThreeCardModel> LoadSectionThree()
        {
            string sql = @"SELECT Id, cardNumber, cardName from dbo.SectionThree";

            return _sqlDataAccess.LoadData<SectionThreeCardModel>(sql);
        }

        public int updateSectionOne(int cardNumber, string cardHeading, string cardBody, string cardButton)
        {
            SectionOneCardModel data = new SectionOneCardModel
            {
                cardNumber = cardNumber,
                cardHeading = cardHeading,
                cardBody = cardBody,
                cardButton = cardButton
            };
            
            string sql = @"UPDATE dbo.SectionOne SET cardHeading = @cardHeading, cardBody = @cardBody, cardButton = @cardButton Where cardNumber = @cardNumber;";
            return _sqlDataAccess.SaveData(sql, data);
        }

        public int updateSectionTwo(int cardNumber, string cardLabel, string cardOffer)
        {
            SectionTwoCardModel data = new SectionTwoCardModel
            {
                cardNumber = cardNumber,
                cardLabel = cardLabel,
                cardOffer = cardOffer
            };

            string sql = @"UPDATE dbo.SectionTwo SET cardLabel = @cardLabel, cardOffer = @cardOffer Where cardNumber = @cardNumber;";
            return _sqlDataAccess.SaveData(sql, data);
        }

        public int updateSectionThree(int cardNumber, string cardName)
        {
            SectionThreeCardModel data = new SectionThreeCardModel
            {
                cardNumber = cardNumber,
                cardName = cardName
            };

            string sql = @"UPDATE dbo.SectionThree SET cardName = @cardName Where cardNumber = @cardNumber;";
            return _sqlDataAccess.SaveData(sql, data);
        }
    }
}
