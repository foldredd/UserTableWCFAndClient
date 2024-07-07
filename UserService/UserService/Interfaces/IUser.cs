using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Interfaces {
    [ServiceContract]
    public interface IUser {

        [DataMember]
        int ID { get; set; }
        [DataMember]
        string FullName { get; set; }

        [DataMember]
        string TIN { get; set; }

        [DataMember]
        string Email { get; set; }

        [DataMember]
        string ContactPhone { get; set; }

        [DataMember]
        DateTime CreationDate { get; set; }

        [DataMember]
        DateTime LastModifiedDate { get; set; }
    }
}
