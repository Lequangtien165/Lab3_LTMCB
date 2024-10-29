using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Lab03_23521572_LeQuangTien
{
    public static class FirebaseHelper
    {
        private static readonly IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "rbzdDnRIrKgQLHeSTCPgya1JgC2gLIfLsC9SxpSY",
            BasePath = "https://projectfire-321ab-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        public static IFirebaseClient GetFirebaseClient()
        {
            return new FireSharp.FirebaseClient(Config);
        }
    }
}
