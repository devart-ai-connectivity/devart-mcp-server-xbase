// --------------------------------------------------------------------------
// <copyright file="OdbcxBaseTools.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System.Collections.Generic;
using ModelContextProtocol.Server;
using Devart.AI.McpServer.Odbc.xBase.Tools;

namespace Devart.AI.McpServer.Odbc.xBase
{
  internal static class OdbcxBaseTools
  {
    public static List<McpServerTool> CreateTools(McpConfiguration configuration)
      => OdbcTools.CreateBuilder(configuration)
        .Add(new OdbcxBasePrimaryKeysTool(configuration))
        .Add(new OdbcxBaseForeignKeysTool(configuration))
        .Build();
  }
}
