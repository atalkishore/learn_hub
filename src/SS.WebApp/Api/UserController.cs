using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.BussinessLogic.Interface;
using SS.Models;

namespace SS.WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        public readonly IUserBusinessService userBusinessService;
        public UserController(IUserBusinessService _userBusinessService)
        {
            this.userBusinessService = _userBusinessService;
        }
        //List<UserModel> lst = new List<UserModel>();
        //public UserController()
        //{
        //    lst = new List<UserModel>()
        //    {
        //        new UserModel(){id=1,UserName="abc1",Name="dummy1a"  },
        //        new UserModel(){id=2,UserName="abc2",Name="dummy2a"  },
        //        new UserModel(){id=3,UserName="abc3",Name="dummy3a"  },
        //        new UserModel(){id=4,UserName="abc4",Name="dummy4a"  }

        //    };
        //}

        [Route("GetId/{userid}")]
        [HttpGet]
        public UserModel Get(int userid)
        {
            return userBusinessService.GetDetails(userid);
        }
        //[ApiAuthenticationFilter(true)]
        [Route("GetALL")]
        [HttpGet]
        public List<UserModel> Get()
        {
            return userBusinessService.GetALL();
        }
        [Route("GetMe/{userid}")]
        [HttpGet]
        public UserModel GetMe(int userid)
        {
            return userBusinessService.GetDetails(3);
        }
    }
}