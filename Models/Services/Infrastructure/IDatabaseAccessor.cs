using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace People.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
         DataSet Query(FormattableString query);
    }
}