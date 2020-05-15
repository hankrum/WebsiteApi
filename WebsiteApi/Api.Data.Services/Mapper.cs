using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dbo = Api.Data.Model;
using Dto = Api.Data.Services.DtoModels;

namespace Api.Data.Services
{
    public static class Mapper
    {

        // can be with IMapper - no extention methods
        public static Dto.WebSite Map(this Dbo.WebSite webSite)
        {
            if(webSite == null)
            {
                return null;
            }
 
            return new Dto.WebSite()
            {
                Id = webSite.Id,
                Name = webSite.Name,
                Category = webSite.Category.Map(),
                Url = webSite.Url,
                SnapshotUrl = webSite.SnapshotUrl,
                LoginEmail = webSite.LoginEmail,
                LoginPassword = webSite.LoginPassword
            };
        }

        public static Dto.Category Map(this Dbo.Category category)
        {
            if (category == null)
            {
                return null;
            }

            return new Dto.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Dbo.WebSite Map(this Dto.WebSite webSite)
        {
            if (webSite == null)
            {
                return null;
            }

            return new Dbo.WebSite()
            {
                Id = webSite.Id,
                Name = webSite.Name,
                CategoryId = webSite.Category.Id,
                // Category = webSite.Category.Map(),
                Url = webSite.Url,
                SnapshotUrl = webSite.SnapshotUrl,
                LoginEmail = webSite.LoginEmail,
                LoginPassword = webSite.LoginPassword
            };
        }

        public static Dbo.Category Map(this Dto.Category category)
        {
            if (category == null)
            {
                return null;
            }

            return new Dbo.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static IEnumerable<Dto.WebSite> Map(this List<Dbo.WebSite> websites)
        {
            if (websites == null)
            {
                return null;
            }

            return websites.Select(website => website.Map());
        }
    }
}
