using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using allegroWebApi.pl.allegro.webapi;
using System.Security.Cryptography;

namespace allegroWebApi.Class
{
    public class LoginTo
    {
        //Constant data
        private string userLogin = "";
        //private string userPassword = "";
        private byte[] passwordHash;
        private string encodedPassword;

        private int countryCode = 1;
        private string webapiKey = "3a1800de";
        private long localVersion = 0;
        
        //Date from server
        private long userId = 0;
        private long serverTime = 0;
        private string sessionHandle = "";
        AllegroWebApiService service;

        public LoginTo(string userLogin, string userPassword)
        {   
                this.userLogin = userLogin;
                //Encrypting password
                SHA256 sha256 = new SHA256Managed();
                passwordHash = sha256.ComputeHash(StrToByteArray(userPassword));
                encodedPassword = Convert.ToBase64String(passwordHash);
                
                service = new AllegroWebApiService();                
                string appVer = service.doQuerySysStatus(1, countryCode, webapiKey, out localVersion);

                sessionHandle = service.doLoginEnc(
                    userLogin,
                    encodedPassword,
                    countryCode,
                    webapiKey,
                    localVersion,
                    out userId,
                    out serverTime
                    );
                SaveDataToUserRegistry();                      
        }
        public string ReturnSessionHandle()
        {
            return sessionHandle;
        }
        public long ReturnUserId()
        {
            return userId;
        }
        public long ReturnServerTime()
        {
            return serverTime;
        }
        private void SaveDataToUserRegistry()
        {
            Microsoft.Win32.RegistryKey key;            
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("AllegroChaosBuster");
            key.SetValue("sessionHandle", sessionHandle);
            key.SetValue("userId", userId);
            key.Close();
        }
        private static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
}
