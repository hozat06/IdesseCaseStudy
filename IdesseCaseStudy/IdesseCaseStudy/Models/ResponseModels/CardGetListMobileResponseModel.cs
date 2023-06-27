using System.Collections.Generic;

namespace IdesseCaseStudy.Models.ResponseModels
{
    public class CardGetListMobileResponseModel : BaseResponseListModel<Person>
    {
        public int TotalRowCount { get; set; }
    }
}
