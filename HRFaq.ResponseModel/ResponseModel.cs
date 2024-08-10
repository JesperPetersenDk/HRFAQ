using System.Collections;

namespace HRFaq.ResponseModel
{
    public class ResponseModel
    {
        public DateTime ResponseDateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public EnumStatusValue Status { get; set; } = EnumStatusValue.Error;
        public IEnumerable GetData { get; set; }
    }

    public class ResponseModel<T>
    {
        public DateTime ResponseDateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public EnumStatusValue Status { get; set; } = EnumStatusValue.Error;
        public IEnumerable<T> GetData { get; set; }
    }

    public class ResponseDataModel
    {
        public ResponseModel Data { get; set; }
    }
    public class ResponseDataModel<T>
    {
        public ResponseModel<T> Data { get; set; }
    }
}
