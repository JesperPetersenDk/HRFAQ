using System.Collections;

namespace Helpers.ResponseModel
{
    public class ResponseModel
    {
        public DateTime ResponseDateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public EnumStatusValue Status { get; set; } = EnumStatusValue.Unknown;
        public IEnumerable GetData { get; set; }
    }

    public class ResponseModel<T>
    {
        public DateTime ResponseDateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public EnumStatusValue Status { get; set; } = EnumStatusValue.Unknown;
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

    public enum EnumStatusValue
    {
        Info = 0,
        Success = 1,
        Failed = 2,
        Error = 3,
        Unknown = 10
    }
}
