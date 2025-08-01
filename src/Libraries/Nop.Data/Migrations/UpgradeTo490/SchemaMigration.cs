using System.Data;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.UpgradeTo490;

[NopSchemaMigration("2025-01-01 00:00:00", "SchemaMigration for 4.90.0")]
public class SchemaMigration : ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        // Add IsPremium column to Product table
        var productTableName = nameof(Product);
        var isPremiumColumnName = nameof(Product.IsPremium);
        
        if (!Schema.Table(productTableName).Column(isPremiumColumnName).Exists())
        {
            Alter.Table(productTableName)
                .AddColumn(isPremiumColumnName)
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);
        }
    }
}