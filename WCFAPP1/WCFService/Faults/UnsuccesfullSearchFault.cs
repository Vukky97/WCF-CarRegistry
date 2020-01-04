using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFService.Faults
{
    [DataContract]
    public class UnsuccesfullSearchFault
    {
        [DataMember]
        public string Uid { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}