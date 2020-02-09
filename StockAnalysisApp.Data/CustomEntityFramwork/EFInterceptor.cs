using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;


namespace StockAnalysisApp.Data.CustomEntityFramwork
{
    public class EFInterceptor : DbCommandInterceptor
    {
        private Exception WrapEntityFrameworkException(DbCommand command, Exception ex)
        {
            var newException = new Exception("EntityFramework command failed!", ex);
            AddParamsToException(command.Parameters, newException);
            return newException;
        }

        private void AddParamsToException(DbParameterCollection parameters, Exception exception)
        {
            foreach (DbParameter param in parameters)
            {
                exception.Data.Add(param.ParameterName, param.Value.ToString());
            }
        }
    }
}
