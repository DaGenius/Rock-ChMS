//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Web.UI.HtmlControls;
using Rock;
using Rock.Core;
using Rock.Web.UI;
using System.Text;

namespace RockWeb.Blocks.Core
{
    [ContextAware]
    [BlockProperty( 1, "Attribute Key", "Behavior", "The attribute key of the notes attribute to use (If it doesn't exist it will be created).", false, "Notes" )]
    public partial class Notes : RockBlock
    {
        private string contextTypeName = string.Empty;
        Rock.Data.IEntity contextEntity = null;

        private Rock.Core.Attribute noteAttribute;
        private List<Rock.Core.Attribute> subAttributes;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            foreach ( KeyValuePair<string, Rock.Data.IEntity> entry in ContextEntities )
            {
                contextTypeName = entry.Key;
                contextEntity = entry.Value;
                // Should only be one.
                break;
            }

            if ( !String.IsNullOrEmpty( contextTypeName ) && contextEntity != null )
            {
                ReadAttributes();
            }
        }

        void pnlNotes_PreRender( object sender, EventArgs e )
        {
            throw new NotImplementedException();
        }

        private void ReadAttributes()
        {
            using ( new Rock.Data.UnitOfWorkScope() )
            {
                var attributeService = new AttributeService();
                var attributeValueService = new AttributeValueService();

                // Note Attribute
                string attributeKey = AttributeValue( "AttributeKey" );
                var noteAttribute = attributeService.Queryable()
                    .Where( a =>
                        a.Entity == contextTypeName &&
                        a.Key == attributeKey )
                    .FirstOrDefault();

                // If an attribute with the specified key does not exist for the context entity type, create one
                if ( noteAttribute == null )
                {
                    noteAttribute = new Rock.Core.Attribute();
                    noteAttribute.IsSystem = false;
                    noteAttribute.Entity = contextTypeName;
                    noteAttribute.EntityQualifierColumn = string.Empty;
                    noteAttribute.EntityQualifierValue = string.Empty;
                    noteAttribute.Key = attributeKey;
                    noteAttribute.Name = attributeKey.SplitCase();
                    noteAttribute.Category = string.Empty;
                    noteAttribute.Description = attributeKey.SplitCase();
                    noteAttribute.FieldTypeId = FieldType.Read( Rock.SystemGuid.FieldType.TEXT ).Id;
                    noteAttribute.DefaultValue = string.Empty;
                    noteAttribute.IsMultiValue = true;
                    noteAttribute.IsRequired = false;
                    attributeService.Add( noteAttribute, CurrentPersonId );
                    attributeService.Save( noteAttribute, CurrentPersonId );
                }

                lTitle.Text = noteAttribute.Name;

                // Read any sub attributes of the note attribute
                string attributeId = noteAttribute.Id.ToString();
                var subAttributes = attributeService.Queryable()
                    .Where( a =>
                        a.Entity == "Rock.Core.AttributeValue" &&
                        a.EntityQualifierColumn == "AttributeId" &&
                        a.EntityQualifierValue == attributeId )
                    .ToList();

                // If an alert subattribute does not exist, create one
                if ( !subAttributes.Exists( a => a.Key == "Alert" ) )
                {
                    var alertAttribute = new Rock.Core.Attribute();
                    alertAttribute.IsSystem = false;
                    alertAttribute.Entity = "Rock.Core.AttributeValue";
                    alertAttribute.EntityQualifierColumn = "AttributeId";
                    alertAttribute.EntityQualifierValue = noteAttribute.Id.ToString();
                    alertAttribute.Key = "Alert";
                    alertAttribute.Name = "Alert";
                    alertAttribute.Category = string.Empty;
                    alertAttribute.Description = "Should note be flagged as an alert";
                    alertAttribute.FieldTypeId = FieldType.Read( Rock.SystemGuid.FieldType.BOOLEAN ).Id;
                    alertAttribute.DefaultValue = string.Empty;
                    alertAttribute.IsMultiValue = false;
                    alertAttribute.IsRequired = false;
                    attributeService.Add( alertAttribute, CurrentPersonId );
                    attributeService.Save( alertAttribute, CurrentPersonId );
                    subAttributes.Add( alertAttribute );
                }

                phNotes.Controls.Clear();

                var rootElement = new XElement( "notes" );

                foreach ( var note in attributeValueService.Queryable()
                    .Where( v =>
                        v.AttributeId == noteAttribute.Id &&
                        v.EntityId == contextEntity.Id ) )
                {
                    if ( note.IsAuthorized( "View", CurrentPerson ) )
                    {
                        AddNoteHtml( note );
                    }
                }
            }
        }

        private void AddNoteHtml( AttributeValue note )
        {
            var article = new HtmlGenericControl( "article" );
            phNotes.Controls.Add( article );
            article.AddCssClass( "group" );

            if ( note.AttributeValues.ContainsKey( "Alert" ) && note.AttributeValues["Alert"].Count == 1 )
            {
                bool alert = false;
                if ( Boolean.TryParse( note.AttributeValues["Alert"][0].Value, out alert ) && alert )
                {
                    article.AddCssClass( "alert" );
                }
            }

            if ( note.IsPrivate( "View", CurrentPerson ) )
            {
                article.AddCssClass( "personal" );
            }

            var icon = new HtmlGenericControl( "i" );
            article.Controls.Add( icon );

            string iconClassName = "icon-comment";
            if ( note.AttributeValues.ContainsKey( "Type" ) && note.AttributeValues["Type"].Count == 1 )
            {
                try {
                    int definedValueId = 0;
                    if (Int32.TryParse(note.AttributeValues["Type"][0].Value, out definedValueId))
                    {
                        var definedValue = Rock.Web.Cache.DefinedValueCache.Read(definedValueId);
                        if (definedValue.AttributeValues.ContainsKey("IconClass") && definedValue.AttributeValues["IconClass"].Count == 1)
                        {
                            iconClassName = definedValue.AttributeValues["IconClass"][0].Value;
                        }
                    }
                }
                catch
                {
                }
            }
            icon.AddCssClass(iconClassName);

            var div = new HtmlGenericControl( "div" );
            article.Controls.Add( div );
            div.AddCssClass( "details" );
            StringBuilder sb = new StringBuilder();

            if ( note.AttributeValues.ContainsKey( "Date" ) && note.AttributeValues["Date"].Count == 1 )
            {
                sb.Append( note.AttributeValues["Date"][0].Value );
            }

            if ( note.AttributeValues.ContainsKey( "Title" ) && note.AttributeValues["Title"].Count == 1 )
            {
                sb.AppendFormat( "{0}{1}", sb.Length > 0 ? " - " : "", note.AttributeValues["Title"][0].Value );
            }

            if ( sb.Length > 0 )
            {
                var heading = new HtmlGenericControl( "h5" );
                div.Controls.Add( heading );
                heading.Controls.Add( new LiteralControl( sb.ToString() ) );
            }

            div.Controls.Add( new LiteralControl( note.Value ) );
        }
    }
}