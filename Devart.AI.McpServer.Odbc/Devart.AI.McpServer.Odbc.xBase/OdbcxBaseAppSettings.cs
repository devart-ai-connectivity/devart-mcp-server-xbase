// --------------------------------------------------------------------------
// <copyright file="OdbcxBaseAppSettings.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

namespace Devart.AI.McpServer.Odbc.xBase
{
  internal sealed class OdbcxBaseAppSettings : McpAppSettings
  {
    public override string ServerName => $"Devart {Properties.ProductInfo.ProductFullName}";

    public override string SourceName => "xBase";

    public override bool OnPremise => true;
  }
}
