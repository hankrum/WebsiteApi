using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Model
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
