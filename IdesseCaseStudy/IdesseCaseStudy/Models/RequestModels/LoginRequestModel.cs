using System;
using System.Collections.Generic;
using System.Text;

namespace IdesseCaseStudy.Models.RequestModels
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerificationCode  { get; set; }

        public LoginRequestModel()
        {

        }

        public LoginRequestModel(string username, string password)
        {
            Username = username;
            Password = password;
            VerificationCode = "";
        }

        public LoginRequestModel(string username, string password, string verificationCode)
        {
            Username = username;
            Password = password;
            VerificationCode = verificationCode;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
