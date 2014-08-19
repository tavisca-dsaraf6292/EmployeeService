using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfService5
{
    [DataContract]
    public class ExceptionFaultContract
    {
        [DataMember]
        public string StatusCode{get; set;}    

        [DataMember]
        public string Message{get; set;}

        [DataMember]
        public string Description { get; set; }

    }
}
