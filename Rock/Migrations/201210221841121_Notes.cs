//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class Notes : RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropForeignKey("coreDefinedValue", "DefinedTypeId", "coreDefinedType");
            DropIndex("coreDefinedValue", new[] { "DefinedTypeId" });
            AddForeignKey("dbo.coreDefinedValue", "DefinedTypeId", "dbo.coreDefinedType", "Id", cascadeDelete: true);
            CreateIndex("dbo.coreDefinedValue", "DefinedTypeId");

            // Delete the old note block
            DeleteBlockType( "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708" );

            // Create new note block type, block, and attributes
            AddBlockType( "Notes", "Context aware block for adding notes to an entity", "~/Blocks/Core/Notes.ascx", "599D274D-55C7-4DE6-BB2D-B334D4BD51BC" );
            AddBlockAttribute( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Context Entity Type", "Filter", "Context Entity Type", 0, "", "451D5A66-5FCA-4D73-9558-C0DEB077649A" );
            AddBlockAttribute( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Attribute Key", "Behavior", "The attribute key of the notes attribute to use (If it doesn't exist it will be created).", 1, "Notes", "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF" );
            AddBlock( "08DBD8A5-2C35-4146-B4A8-0F7652348B25", "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "Notes", "Notes", "CCEB85C0-45B4-4508-8331-DA59B7F573B6", 0 );
            AddBlockAttributeValue( "CCEB85C0-45B4-4508-8331-DA59B7F573B6", "451D5A66-5FCA-4D73-9558-C0DEB077649A", "Rock.Crm.Person" );
            AddBlockAttributeValue( "CCEB85C0-45B4-4508-8331-DA59B7F573B6", "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF", "Timeline" );

            // Add the person note attribute type
            Sql( @"
                DECLARE @Order int
                DECLARE @DefinedTypeId int
                DECLARE @TextFieldTypeId int
                DECLARE @BoolFieldTypeId int
                DECLARE @DateFieldTypeId int
                DECLARE @DefinedValueFieldTypeId int

                -- Add Defined Type for note type
                SELECT @Order = ISNULL(MAX([order])+1,0) FROM [coreDefinedType] WHERE [Category] = 'Profile';
                INSERT INTO [coreDefinedType] ([IsSystem],[Order],[Category],[Name],[Description],[Guid])
	                VALUES (1, @Order, 'Person', 'Profile Note Type', 'Types of notes on the Profile screen', '504BE755-2919-4738-952F-3EDF8B0F561A')
                SET @DefinedTypeId = SCOPE_IDENTITY()

                SELECT @TextFieldTypeId = [Id] FROM [coreFieldType] WHERE [Guid] = '9C204CD0-1233-41C5-818A-C5DA439445AA'
                SELECT @BoolFieldTypeId = [Id] FROM [coreFieldType] WHERE [Guid] = '1EDAFDED-DFE6-4334-B019-6EECBA89E05A'
                SELECT @DateFieldTypeId = [Id] FROM [coreFieldType] WHERE [Guid] = '6B6AA175-4758-453F-8D83-FCD8044B5F36'
                SELECT @DefinedValueFieldTypeId = [Id] FROM [coreFieldType] WHERE [Guid] = '59D5A94C-94A0-4630-B80A-BB25697D74C7'

                -- Add Notes attribute and sub attributes
                DECLARE @AttributeId int
                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
            	    VALUES (1, @TextFieldTypeId, 'Rock.Crm.Person', '', '', 'Timeline', 'Timeline', '', 'Notes displayed on the Person Profile page', 0, 0, '', 1, 0, '7E53487C-D650-4D85-97E2-350EB8332763')
                SET @AttributeId = SCOPE_IDENTITY()

                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
            	    VALUES (1, @BoolFieldTypeId, 'Rock.Core.AttributeValue', 'AttributeId', CAST(@AttributeId as varchar), 'Alert', 'Alert', '', 'Should note be flagged as an alert', 0, 0, '', 0, 0, '198DD22E-EA91-44DB-BBA1-4A91112BB887')
                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
            	    VALUES (1, @TextFieldTypeId, 'Rock.Core.AttributeValue', 'AttributeId', CAST(@AttributeId as varchar), 'Title', 'Title', '', 'Title of note', 0, 0, '', 0, 0, '5C90BE0E-D256-4D5B-9CFE-367A3F4708FF')
                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
            	    VALUES (1, @DateFieldTypeId, 'Rock.Core.AttributeValue', 'AttributeId', CAST(@AttributeId as varchar), 'Date', 'Date', '', 'Date note was created', 0, 0, '', 0, 0, 'B4AEC5B8-A7D3-423E-8795-80D65E6DAAC4')
                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
            	    VALUES (1, @DefinedValueFieldTypeId, 'Rock.Core.AttributeValue', 'AttributeId', CAST(@AttributeId as varchar), 'Type', 'Type', '', 'The type of note created', 0, 0, '', 0, 0, 'AA02511B-CB24-4A7E-B326-F4C67DA63D21')
                SET @AttributeId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeQualifier] ([IsSystem],[AttributeId],[Key],[Value],[Guid])
                    VALUES (1, CAST(@AttributeId as varchar), 'definedtype', CAST(@DefinedTypeId as varchar), NEWID())

                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
	                VALUES (1, @TextFieldTypeId, 'Rock.Core.DefinedValue', 'DefinedTypeId', CAST(@DefinedTypeId AS varchar), 'IconClass', 'Icon Class Name', '', 'The class name to use when rendering an icon for notes of this type', 0, 0, '', 0, 0, 'BABA5709-EAC1-4003-B48C-7ACA5E5BFB1C')
                SET @AttributeId = SCOPE_IDENTITY()

                DECLARE @DefinedValueId int
                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 0, 'Personal Note', 'Note manually entered by a logged-in user', NEWID())
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-comment', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 1, 'Event Registration', 'Note created when person registers for an event', NEWID())
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-calendar', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 2, 'Communication Note', 'Note created when person is emailed a communication', NEWID())
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-envelope', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 3, 'Phone Note', 'Note created when a phone call is made with person', NEWID())
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-phone', NEWID())
" );
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            Sql( @"
                -- Delete note attribute and sub attributes
                DELETE [coreAttribute] WHERE [Guid] = 'AA02511B-CB24-4A7E-B326-F4C67DA63D21'
                DELETE [coreAttribute] WHERE [Guid] = 'B4AEC5B8-A7D3-423E-8795-80D65E6DAAC4'
                DELETE [coreAttribute] WHERE [Guid] = '5C90BE0E-D256-4D5B-9CFE-367A3F4708FF'
                DELETE [coreAttribute] WHERE [Guid] = '198DD22E-EA91-44DB-BBA1-4A91112BB887'
                DELETE [coreAttribute] WHERE [Guid] = '7E53487C-D650-4D85-97E2-350EB8332763'

                -- Delete defined type and the icon attribute
                DELETE [coreAttribute] WHERE [Guid] = 'BABA5709-EAC1-4003-B48C-7ACA5E5BFB1C'
                DELETE [coreDefinedType] WHERE [Guid] = '504BE755-2919-4738-952F-3EDF8B0F561A'
" );

            // Remove the new note block type
            DeleteBlockType( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC" );
            DeleteBlockAttribute( "451D5A66-5FCA-4D73-9558-C0DEB077649A" );
            DeleteBlockAttribute( "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF" );

            // Add the old note block type, and block
            AddBlockType( "Person Notes", "Person notes (Person Detail Page)", "~/Blocks/Crm/PersonDetail/Notes.ascx", "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708" );
            AddBlock( "08DBD8A5-2C35-4146-B4A8-0F7652348B25", "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708", "Notes", "Notes", "CCEB85C0-45B4-4508-8331-DA59B7F573B6", 0 );

            DropIndex( "dbo.coreDefinedValue", new[] { "DefinedTypeId" } );
            DropForeignKey("dbo.coreDefinedValue", "DefinedTypeId", "dbo.coreDefinedType");
            CreateIndex("coreDefinedValue", "DefinedTypeId");
            AddForeignKey("coreDefinedValue", "DefinedTypeId", "coreDefinedType", "Id");
        }
    }
}
