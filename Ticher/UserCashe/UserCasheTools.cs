using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticher.UserCashe
{
   static  class UserCasheTools
    {
       static private List<UserData> userlist;

       static UserCasheTools()
       {
           userlist = new List<UserData>();
       }

       public static UserData getNewUser()
       {
           UserData newUser = new UserData();
           Random ran = new Random();
           newUser.sid = ran.Next(int.MaxValue).ToString();
           newUser.quizSet = new List<Dictionary.Quiz>();

           userlist.Add(newUser); 

           return newUser;
       }

       public static UserData getUser(string sid)
       {
           List<UserData> sel = userlist.Where(x => (x.sid == sid)).ToList();
           return (sel.Count == 0) ? null : sel[0];
       }
    }
}
