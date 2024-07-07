using System;
using System.Collections.Generic;
using System.ServiceModel;
using UserService.DTO;

namespace UserServiceHost {
    internal class Program {
        static void Main(string[] args) {
            using (var host = new ServiceHost(typeof(UserService.UserService)))
            {

                host.Open();
                Console.ReadLine();
            }
        }
    }
}
