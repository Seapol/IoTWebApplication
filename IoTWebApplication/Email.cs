using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoTWebApplication
{
    public class Email
    {
        public Email()
        {

        }

        private string from_address;

        public string From_address
        {
            get { return from_address; }
            set { from_address = value; }
        }

        private string to_address;

        public string To_address
        {
            get { return to_address; }
            set { to_address = value; }
        }


    }
}