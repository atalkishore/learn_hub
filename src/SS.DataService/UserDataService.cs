using SS.DataService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Models;

namespace SS.DataService
{
   public class UserDataService : IUserDataService
    {
        List<UserModel> lst = new List<UserModel>();
        public UserDataService()
        {
            lst = new List<UserModel>()
            {
                new UserModel(){id=1,UserName="abc1",Name="dummy1a"  },
                new UserModel(){id=2,UserName="abc2",Name="dummy2a"  },
                new UserModel(){id=3,UserName="abc3",Name="dummy3a"  },
                new UserModel(){id=4,UserName="abc4",Name="dummy4a"  }

            };
        }
        public UserModel GetDetails(int userid)
        {
            // User u1 = new User() {UserName="sdf" };

            return lst.Where(x => x.id == userid).First();
        }
        public List<UserModel> GetALL()
        {
            // User u1 = new User() {UserName="sdf" };

            return lst;
        }

    }
}
