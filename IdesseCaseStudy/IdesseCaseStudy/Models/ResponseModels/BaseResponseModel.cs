using System.Collections.Generic;

namespace IdesseCaseStudy.Models.ResponseModels
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class BaseResponseModel<T> : BaseResponseModel
    {
        public T Data { get; set; }

    }

    public class BaseResponseListModel<T> : BaseResponseModel
    {
        public List<T> Data { get; set; }

    }
}
