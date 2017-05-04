using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure.Interception;

namespace ProjB.DAL
{
    public class EventConfiguration : DbConfiguration
    {

        public EventConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new EventInterceptorTransientErrors());
            DbInterception.Add(new EventInterceptorLogging());
        }
    }
}