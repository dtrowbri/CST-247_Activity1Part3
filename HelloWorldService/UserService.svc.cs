using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private List<UserModel> users;

        public UserService()
        {
            users = new List<UserModel>();
            users.Add(new UserModel(1, "Donny", true, 60000f, new List<int> { 234, 634, 235, 123 }));
            users.Add(new UserModel(2, "Brydon", false, 70000f, new List<int> { 1234, 123, 734, 462 }));
            users.Add(new UserModel(3, "Joshua", true, 75000f, new List<int> { 734, 6346, 2346, 234 }));
        }
        public DTO GetAllUsers()
        {
            DTO dto = new DTO();
            dto.ErrorCode = 0;
            dto.ErrorMessage = "OK";
            dto.Users = users;
            return dto;
        }

        public string GetData(string value)
        {
            return "This is the value you passed in " + value + ".";
        }

        public CompositeType GetObjectModel(string id)
        {
            CompositeType composite = new CompositeType();
            composite.StringValue = id;
            composite.BoolValue = true;
            return composite;
        }

        public DTO GetUser(string id)
        {
            int customerId = -1;
            int.TryParse(id, out customerId);
            if (customerId <= 0 || customerId > users.Count)
            {
                return new DTO { ErrorCode = -1, ErrorMessage = "User Does Not Exist", Users = null };
            }
            else
            {
                List<UserModel> specifiedUser = new List<UserModel>();
                foreach (UserModel user in users)
                {
                    if (user.Id == customerId)
                    {
                        specifiedUser.Add(user);
                        break;
                    }
                }
                return new DTO { ErrorCode = 0, ErrorMessage = "OK", Users = specifiedUser };
            }
        }

        public string SayHello()
        {
            return "Hello world from REST API";
        }
    }
}
