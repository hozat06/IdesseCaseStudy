using System;

namespace IdesseCaseStudy.Models
{
    public class Period
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int Year { get; set; }
    }

}
