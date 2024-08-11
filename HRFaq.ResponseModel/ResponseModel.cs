﻿using Helpers.ResponseModel.Enum;
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
}
