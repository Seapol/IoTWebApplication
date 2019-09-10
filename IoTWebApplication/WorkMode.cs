using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace IoTWebApplication
{
    public enum WorkMode
    {
        New,
        Modify,
        Review,
        Admin
    }
}