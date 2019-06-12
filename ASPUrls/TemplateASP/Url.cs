using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateASP
{
    public class Url
    {
        public int id { get; }
        public string url { get; }
        public string owner { get; }
        public string sharingUsers { get; }

        public Url(int id, string url, string owner, string sharingUsers)
        {
            this.id = id;
            this.url = url;
            this.owner = owner;
            this.sharingUsers = sharingUsers;
        }
    }
}