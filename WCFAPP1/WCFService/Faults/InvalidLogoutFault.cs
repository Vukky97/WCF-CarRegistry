using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFService.Faults
{
    [DataContract]
    public class InvalidLogoutFault
    {
        [DataMember]
        public string Username { get; set; }
    }
}