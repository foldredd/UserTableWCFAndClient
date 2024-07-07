using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UserService.Interfaces;

namespace UserService.DTO {
    [DataContract]
    public class User: IUser {
        public User() { }
         public User(int id, string fullName, string tin, string email, string contactPhone){
            ID = id;
            FullName = fullName;
            TIN = tin;
            Email = email;
            ContactPhone = contactPhone;
        }
        public User(string fullName, string tin, string email, string contactPhone) {
            FullName = fullName;
            TIN = tin;
            Email = email;
            ContactPhone = contactPhone;
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string TIN { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string ContactPhone { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public DateTime LastModifiedDate { get; set; }
    }
}