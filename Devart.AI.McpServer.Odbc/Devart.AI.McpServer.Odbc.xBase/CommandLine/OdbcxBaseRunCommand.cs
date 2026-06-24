// --------------------------------------------------------------------------
// <copyright file="OdbcxBaseRunCommand.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Devart.AI.McpServer.Interfaces;
using Devart.AI.McpServer.Odbc.CommandLine;
using Devart.AI.McpServer.Odbc.xBase.Properties;

namespace Devart.AI.McpServer.Odbc.xBase.CommandLine
{
  internal sealed class OdbcxBaseRunCommand : OdbcRunCommand
  {
    protected override void RegisterTools(IMcpServerBuilder serverBuilder, McpConfiguration configuration)
      => serverBuilder.WithTools(OdbcxBaseTools.CreateTools(configuration));

    protected override string ProductFullName => ProductInfo.ProductFullName;

    protected override McpAppSettings CreateAppSettings() => new OdbcxBaseAppSettings();

    protected override void SetupMetadata(IHostApplicationBuilder builder)
    {
      builder.Services.AddSingleton<IMetadata, OdbcxBaseMetadata>();
    }

  }
}