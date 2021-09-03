using System;
using System.Collections.Generic;

namespace MostriVsEroi.BusinessLayer
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }

        public Utente(string username, string password)
        {
            Username = username;
            Password = password;
            IsAuthenticated = false;
            IsAdmin = false;
        }



    }
}