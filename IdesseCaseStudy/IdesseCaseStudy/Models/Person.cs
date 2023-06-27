namespace IdesseCaseStudy.Models
{
    public class Person
    {
        public int CardId { get; set; }
        public int CardTypeId { get; set; }
        public string CardTypeDescr { get; set; }
        public string CardName { get; set; }
        public bool CardIsMale { get; set; }
        public string CardTitleCode { get; set; }
        public string CardProfessionCode { get; set; }
        public bool CardIsInList { get; set; }
        public string CardMobilePhone { get; set; }
        public string CardStatus { get; set; }
        public bool MsisdnConsent { get; set; }
        public bool SmsConsent { get; set; }
        public bool CallConsent { get; set; }
        public bool EmailConsent { get; set; }
        public string CardIdLocationId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationPhone { get; set; }
        public string LocationBrickDescr { get; set; }
        public int LocationTypeId { get; set; }
        public bool IsPharmacy { get; set; }
        public bool IsInMyList { get; set; }
        public string PropertyFrequency { get; set; }
        public string PropertySegment { get; set; }
        public int ThisMonthPlanCount { get; set; }
        public int ThisMonthRealizedPlanCount { get; set; }
        public int YtdPlanCount { get; set; }
        public int YtdRealizedPlanCount { get; set; }
        public float RealizedCountAvg { get; set; }
    }
}
