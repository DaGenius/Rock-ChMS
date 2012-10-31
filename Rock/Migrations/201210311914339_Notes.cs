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
            DropForeignKey( "coreDefinedValue", "DefinedTypeId", "coreDefinedType" );
            DropIndex( "coreDefinedValue", new[] { "DefinedTypeId" } );
            CreateTable(
                "dbo.coreNote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSystem = c.Boolean(nullable: false),
                        NoteTypeId = c.Int(nullable: false),
                        EntityId = c.Int(),
                        SourceTypeValueId = c.Int(),
                        Caption = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        IsAlert = c.Boolean(),
                        Text = c.String(),
                        Guid = c.Guid(nullable: false),
                        NoteType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.coreNoteType", t => t.NoteType_Id)
                .ForeignKey("dbo.coreNoteType", t => t.NoteTypeId, cascadeDelete: true)
                .ForeignKey("dbo.coreDefinedValue", t => t.SourceTypeValueId)
                .Index(t => t.NoteType_Id)
                .Index(t => t.NoteTypeId)
                .Index(t => t.SourceTypeValueId);
            
            CreateIndex( "dbo.coreNote", "Guid", true );
            CreateTable(
                "dbo.coreNoteType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSystem = c.Boolean(nullable: false),
                        EntityTypeId = c.Int(nullable: false),
                        EntityTypeQualifierColumn = c.String(maxLength: 50),
                        EntityTypeQualifierValue = c.String(maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 100),
                        SourcesTypeId = c.Int(),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.coreEntityType", t => t.EntityTypeId)
                .ForeignKey("dbo.coreDefinedType", t => t.SourcesTypeId)
                .Index(t => t.EntityTypeId)
                .Index(t => t.SourcesTypeId);
            
            CreateIndex( "dbo.coreNoteType", "Guid", true );
            AddForeignKey("dbo.coreDefinedValue", "DefinedTypeId", "dbo.coreDefinedType", "Id", cascadeDelete: true);
            CreateIndex("dbo.coreDefinedValue", "DefinedTypeId");

            CreateIndex( "dbo.coreNoteType", new[] { "EntityTypeId", "Name" }, true );

            // Delete the old note block
            DeleteBlockType( "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708" );

            // Create new note block type, block, and attributes
            AddBlockType( "Notes", "Context aware block for adding notes to an entity", "~/Blocks/Core/Notes.ascx", "599D274D-55C7-4DE6-BB2D-B334D4BD51BC" );
            AddBlockAttribute( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Context Entity Type", "Filter", "Context Entity Type", 0, "", "451D5A66-5FCA-4D73-9558-C0DEB077649A" );
            AddBlockAttribute( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Note Type", "Behavior", "The note type name associated with the context entity to use (If it doesn't exist it will be created).", 1, "Notes", "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF" );
            AddBlock( "08DBD8A5-2C35-4146-B4A8-0F7652348B25", "599D274D-55C7-4DE6-BB2D-B334D4BD51BC", "Notes", "Notes", "CCEB85C0-45B4-4508-8331-DA59B7F573B6", 0 );
            AddBlockAttributeValue( "CCEB85C0-45B4-4508-8331-DA59B7F573B6", "451D5A66-5FCA-4D73-9558-C0DEB077649A", "Rock.Crm.Person" );
            AddBlockAttributeValue( "CCEB85C0-45B4-4508-8331-DA59B7F573B6", "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF", "Timeline" );

            Sql( @"
                DECLARE @Order int
                DECLARE @DefinedTypeId int

                -- Add Defined Type for note sourcetype
                SELECT @Order = ISNULL(MAX([order])+1,0) FROM [coreDefinedType] WHERE [Category] = 'Person';
                INSERT INTO [coreDefinedType] ([IsSystem],[Order],[Category],[Name],[Description],[Guid])
	                VALUES (1, @Order, 'Person', 'Timeline Sources', 'Sources of notes on person timeline', '504BE755-2919-4738-952F-3EDF8B0F561A')
                SET @DefinedTypeId = SCOPE_IDENTITY()

                -- Add IconClass attribute to the defined type
                DECLARE @TextFieldTypeId int
                SELECT @TextFieldTypeId = [Id] FROM [coreFieldType] WHERE [Guid] = '9C204CD0-1233-41C5-818A-C5DA439445AA'
                DECLARE @AttributeId int
                INSERT INTO [coreAttribute] ([IsSystem],[FieldTypeId],[Entity],[EntityQualifierColumn],[EntityQualifierValue],[Key],[Name],[Category],[Description],[Order],[IsGridColumn],[DefaultValue],[IsMultiValue],[IsRequired],[Guid])
	                VALUES (1, @TextFieldTypeId, 'Rock.Core.DefinedValue', 'DefinedTypeId', CAST(@DefinedTypeId AS varchar), 'IconClass', 'Icon Class Name', '', 'The class name to use when rendering an icon for notes of this type', 0, 0, '', 0, 0, 'BABA5709-EAC1-4003-B48C-7ACA5E5BFB1C')
                SET @AttributeId = SCOPE_IDENTITY()

                -- Add note source defined values
                DECLARE @DefinedValueId int
                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 0, 'Personal Note', 'Note manually entered by a logged-in user', '4318E9AC-B669-4AF7-AF88-EF580FC43C6A')
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-comment', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 1, 'Event Registration', 'Note created when person registers for an event', 'BBADA8EF-23FC-4B46-B7A7-0F6D31F8C045')
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-calendar', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 2, 'Communication Note', 'Note created when person is emailed a communication', '87BACB34-DB87-45E0-AB60-BFABF7CEECDB')
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-envelope', NEWID())

                INSERT INTO [coreDefinedValue] ([IsSystem],[DefinedTypeId],[Order],[Name],[Description],[Guid])
	                VALUES (1, @DefinedTypeId, 3, 'Phone Note', 'Note created when a phone call is made with person', 'B54F9D90-9AF3-4E8A-8F33-9338C7C1287F')
                SET @DefinedValueId = SCOPE_IDENTITY()
                INSERT INTO [coreAttributeValue] ([IsSystem],[AttributeId],[EntityId],[Order],[Value],[Guid])
	                VALUES (1, @AttributeId, @DefinedValueId, 0, 'icon-phone', NEWID())

                -- Get the entitytype for corePerson
                DECLARE @EntityTypeId int
                SELECT @EntityTypeId = [Id] FROM [coreEntityType] WHERE [Name] = 'Rock.Crm.Person'
                IF @EntityTypeId IS NULL
                BEGIN
                    INSERT INTO [coreEntityType] ([Name], [Guid])
                    VALUES ('Rock.Crm.Person', NEWID())
                    SET @EntityTypeId = SCOPE_IDENTITY()
                END

                -- Add Note Type for person timeline
                DECLARE @NoteTypeId int
                INSERT INTO [coreNoteType] ([IsSystem],[EntityTypeId],[EntityTypeQualifierColumn],[EntityTypeQualifierValue],[Name],[SourcesTypeId],[Guid])
            	    VALUES (1, @EntityTypeId, '', '', 'Timeline', @DefinedTypeId, '7E53487C-D650-4D85-97E2-350EB8332763')
                SET @NoteTypeId = SCOPE_IDENTITY()
" );
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            Sql( @"
                -- Delete defined type and the icon attribute
                DELETE [coreAttribute] WHERE [Guid] = 'BABA5709-EAC1-4003-B48C-7ACA5E5BFB1C'
                DELETE [coreDefinedType] WHERE [Guid] = '504BE755-2919-4738-952F-3EDF8B0F561A'

                -- Delete the note type
                DELETE [coreNoteType] WHERE [Guid] = '7E53487C-D650-4D85-97E2-350EB8332763'
" );

            // Remove the new note block type
            DeleteBlockType( "599D274D-55C7-4DE6-BB2D-B334D4BD51BC" );
            DeleteBlockAttribute( "451D5A66-5FCA-4D73-9558-C0DEB077649A" );
            DeleteBlockAttribute( "998EB1EA-DE7A-4372-8D5D-2613F1AA40AF" );

            // Add the old note block type, and block
            AddBlockType( "Person Notes", "Person notes (Person Detail Page)", "~/Blocks/Crm/PersonDetail/Notes.ascx", "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708" );
            AddBlock( "08DBD8A5-2C35-4146-B4A8-0F7652348B25", "6A0B3ED6-C6CA-40D4-91E0-B7B2823CC708", "Notes", "Notes", "CCEB85C0-45B4-4508-8331-DA59B7F573B6", 0 );

            DropIndex( "dbo.coreNoteType", new[] { "EntityTypeId", "Name" } );

            DropIndex( "dbo.coreNoteType", new[] { "SourcesTypeId" } );
            DropIndex("dbo.coreNoteType", new[] { "EntityTypeId" });
            DropIndex("dbo.coreNote", new[] { "SourceTypeValueId" });
            DropIndex("dbo.coreNote", new[] { "NoteTypeId" });
            DropIndex("dbo.coreNote", new[] { "NoteType_Id" });
            DropIndex("dbo.coreDefinedValue", new[] { "DefinedTypeId" });
            DropForeignKey("dbo.coreNoteType", "SourcesTypeId", "dbo.coreDefinedType");
            DropForeignKey("dbo.coreNoteType", "EntityTypeId", "dbo.coreEntityType");
            DropForeignKey("dbo.coreNote", "SourceTypeValueId", "dbo.coreDefinedValue");
            DropForeignKey("dbo.coreNote", "NoteTypeId", "dbo.coreNoteType");
            DropForeignKey("dbo.coreNote", "NoteType_Id", "dbo.coreNoteType");
            DropForeignKey("dbo.coreDefinedValue", "DefinedTypeId", "dbo.coreDefinedType");
            DropTable("dbo.coreNoteType");
            DropTable("dbo.coreNote");
            CreateIndex( "coreDefinedValue", "DefinedTypeId" );
            AddForeignKey( "coreDefinedValue", "DefinedTypeId", "coreDefinedType", "Id" );
        }
    }
}
