namespace IdesseCaseStudy.Models.RequestModels
{
    public class CardGetListMobileRequestModel
    {
        public int Limit { get; set; }
        public int Start { get; set; }
        public bool IncludeVisitStats { get; set; }

        public CardGetListMobileRequestModel()
        {
            Limit = 1;
            Start = 10;
        }

        public CardGetListMobileRequestModel(int limit, int start, bool includeVisitStats)
        {
            Limit = limit;
            Start = start;
            IncludeVisitStats = includeVisitStats;
        }
    }
}
