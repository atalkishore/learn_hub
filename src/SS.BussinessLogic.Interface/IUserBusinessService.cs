using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Models;

namespace SS.BussinessLogic.Interface
{
    public interface IUserBusinessService
    {
        UserModel GetDetails(int userid);
        List<UserModel> GetALL();
        int Authenticate(string userName, string password);
    }
}
