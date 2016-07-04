using SS.BussinessLogic.Interface;
using SS.DataService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Models;

namespace SS.BussinessLogic
{
    public class UserBussinessService : IUserBusinessService
    {
        private readonly IUserDataService userDataService;

        public UserBussinessService(IUserDataService _userDataService)
        {
            this.userDataService = _userDataService;
        }

        public int Authenticate(string userName, string password)
        {
            UserModel user = userDataService.GetDetails(1);
            if (user != null && user.id > 0)
            {
                return user.id;
            }
            return 0;
        }

        public List<UserModel> GetALL()
        {
            return userDataService.GetALL();
        }

        public UserModel GetDetails(int userid)
        {
          return userDataService.GetDetails(userid);
        }
                
    }
}
