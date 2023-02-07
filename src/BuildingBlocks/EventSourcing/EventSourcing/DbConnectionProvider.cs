// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace EventSourcing;

public class DbConnectionProvider: IDbConnectionProvider
{
	public DbConnectionProviderOptions DbConnectionProviderOptions { get; set; }

	public DbConnectionProvider(IOptions<DbConnectionProviderOptions> dbConnectionProviderOptionsAccessor)
	{
		DbConnectionProviderOptions = dbConnectionProviderOptionsAccessor.Value;
	}

	public IDbConnection Get()
	{
		return new SqlConnection(DbConnectionProviderOptions.ConnectionString);
	}
}

