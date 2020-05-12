using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Services.DtoModels
{
    public class WebSite 
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public Category Category { get; set; }

        public string SnapshotUrl { get; set; }

        public string LoginEmail { get; set; }

        public string LoginPassword { get; set; }
    }
}
