using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Cakeryz.Models
{
    public static class Gvar
    {
        public static string CurrentUser { get; set; }
        //Session["user"] = UserManager.GetUserId(User)

        //public static string user
        //{

        //    get { return Session["Gvar_User"]; }
        //    set { Session["Gvar_User"] = value; }

        //}
    }
}
