﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SAPBusiness.UserData
{
    public class UserPool
    {
        //public User GetUser()
        //{
        //    string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\UserDataAccess\users.json");
        //    return JsonConvert.DeserializeObject<User>(jsonResult);
        //}
        private static IList<User> _users;
        private UserPool()
        {
            string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\UserDataAccess\users.json");
            _users = JsonConvert.DeserializeObject<IList<User>>(jsonResult);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static User GetUser()
        {
            if (_users.Count.Equals(0))
            {
                throw new System.Exception("Not available users");
            }

            var user = _users.First();
            _users.Remove(user);

            return user;
        }
    }
}
