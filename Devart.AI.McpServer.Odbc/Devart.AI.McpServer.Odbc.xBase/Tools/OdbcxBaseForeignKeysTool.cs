// --------------------------------------------------------------------------
// <copyright file="OdbcxBaseForeignKeysTool.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Devart.AI.McpServer.Tools;
using Devart.AI.McpServer.Interfaces;

namespace Devart.AI.McpServer.Odbc.xBase.Tools
{
  internal sealed class OdbcxBaseForeignKeysTool(McpConfiguration serverConfiguration) : ForeignKeysTool(serverConfiguration)
  {
    protected override async Task<DataTable> GetMetadataTable(
      DbConnection connection, 
      string schema, 
      string tableName, 
      IServiceProvider services, 
      CancellationToken cancellationToken)
    {
      var database = services.GetRequiredService<IDatabase>();
      var commandHelper = services.GetRequiredService<ICommandHelper>();

      DataTable resultTable = new(tableName) {
        Locale = System.Globalization.CultureInfo.InvariantCulture
      };

      resultTable.Columns.Add(OdbcConstants.ForeignKeyFkName, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyFkColumn, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyPkSchema, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyPkTable, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyPkColumn, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyUpdateRule, typeof(string));
      resultTable.Columns.Add(OdbcConstants.ForeignKeyDeleteRule, typeof(string));

      await using var reader = await database.ExecuteReaderAsync(
        connection,
        $"PRAGMA foreign_key_list([{tableName}])",
        null,
        cancellationToken
      ).ConfigureAwait(false);

      while (await reader.ReadAsync(cancellationToken))
      {
        resultTable.Rows.Add(
          $"FK_{tableName}_{reader.GetString(2)}",
          reader.GetString(3),
          connection.Database,
          reader.GetString(2),
          reader.GetString(4),
          reader.GetString(5),
          reader.GetString(6));
      }

      return resultTable;
    }
  }
}
