// --------------------------------------------------------------------------
// <copyright file="OdbcxBaseMetadata.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

namespace Devart.AI.McpServer.Odbc.xBase
{
  internal sealed class OdbcxBaseMetadata : OdbcMetadata
  {
    public override string DatabaseName(string database) => "";

    public override string SchemaName(string schema) => "";
  }
}