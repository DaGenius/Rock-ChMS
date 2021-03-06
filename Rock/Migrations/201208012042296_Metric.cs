namespace Rock.Migrations
{
    using System.Data.Entity.Migrations;
#pragma warning disable 1591
    public partial class Metric : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.coreMetricValue",
                c => new
                {
                    Id = c.Int( nullable: false, identity: true ),
                    IsSystem = c.Boolean( nullable: false ),
                    MetricId = c.Int( nullable: false ),
                    Value = c.String( nullable: false, maxLength: 100 ),
                    Description = c.String(),
                    xValue = c.Int( nullable: false ),
                    isDateBased = c.Boolean( nullable: false ),
                    Label = c.String(),
                    Order = c.Int( nullable: false ),
                    CreatedDateTime = c.DateTime(),
                    ModifiedDateTime = c.DateTime(),
                    CreatedByPersonId = c.Int(),
                    ModifiedByPersonId = c.Int(),
                    Guid = c.Guid( nullable: false ),
                } )
                .PrimaryKey( t => t.Id );

            CreateTable(
                "dbo.coreMetric",
                c => new
                {
                    Id = c.Int( nullable: false, identity: true ),
                    IsSystem = c.Boolean( nullable: false ),
                    Type = c.Boolean( nullable: false ),
                    Category = c.String( maxLength: 100 ),
                    Title = c.String( nullable: false, maxLength: 100 ),
                    Subtitle = c.String( maxLength: 100 ),
                    Description = c.String(),
                    MinValue = c.Int( nullable: false ),
                    MaxValue = c.Int( nullable: false ),
                    CollectionFrequency = c.Int( nullable: false ),
                    LastCollected = c.DateTime( nullable: false ),
                    Source = c.String( maxLength: 100 ),
                    SourceSQL = c.String(),
                    Order = c.Int( nullable: false ),
                    CreatedDateTime = c.DateTime(),
                    ModifiedDateTime = c.DateTime(),
                    CreatedByPersonId = c.Int(),
                    ModifiedByPersonId = c.Int(),
                    Guid = c.Guid( nullable: false ),
                } )
                .PrimaryKey( t => t.Id );

            CreateIndex( "coreMetricValue", "ModifiedByPersonId" );
            CreateIndex( "coreMetricValue", "CreatedByPersonId" );
            CreateIndex( "coreMetricValue", "MetricId" );
            CreateIndex( "coreMetric", "ModifiedByPersonId" );
            CreateIndex( "coreMetric", "CreatedByPersonId" );
            AddForeignKey( "dbo.coreMetricValue", "ModifiedByPersonId", "crmPerson", "Id" );
            AddForeignKey( "dbo.coreMetricValue", "CreatedByPersonId", "crmPerson", "Id" );
            AddForeignKey( "dbo.coreMetricValue", "MetricId", "coreMetric", "Id", cascadeDelete: true );
            AddForeignKey( "dbo.coreMetric", "ModifiedByPersonId", "crmPerson", "Id" );
            AddForeignKey( "dbo.coreMetric", "CreatedByPersonId", "crmPerson", "Id" );
        }

        public override void Down()
        {
            DropForeignKey( "dbo.coreMetric", "CreatedByPersonId", "crmPerson" );
            DropForeignKey( "dbo.coreMetric", "ModifiedByPersonId", "crmPerson" );
            DropForeignKey( "dbo.coreMetricValue", "MetricId", "coreMetric" );
            DropForeignKey( "dbo.coreMetricValue", "CreatedByPersonId", "crmPerson" );
            DropForeignKey( "dbo.coreMetricValue", "ModifiedByPersonId", "crmPerson" );
            DropIndex( "coreMetric", new[] { "CreatedByPersonId" } );
            DropIndex( "coreMetric", new[] { "ModifiedByPersonId" } );
            DropIndex( "coreMetricValue", new[] { "MetricId" } );
            DropIndex( "coreMetricValue", new[] { "CreatedByPersonId" } );
            DropIndex( "coreMetricValue", new[] { "ModifiedByPersonId" } );
            DropTable( "dbo.coreMetric" );
            DropTable( "dbo.coreMetricValue" );
        }
    }
}
