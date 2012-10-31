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

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            btnAddNote.Click += btnAddNote_Click;
        }

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
                if ( !Page.IsPostBack )
                    ShowNotes();
            }
        }

        void btnAddNote_Click( object sender, EventArgs e )
        {
            var attributeValueService = new AttributeValueService();

            int? order = attributeValueService.Queryable()
                .Where( v => 
                    v.AttributeId == noteAttribute.Id &&
                    v.EntityId == contextEntity.Id
                )
                .Select( v => ( int? )v.Order ).Max();

            var attributeValue = new AttributeValue();
            attributeValue.IsSystem = false;
            attributeValue.AttributeId = noteAttribute.Id;
            attributeValue.EntityId = contextEntity.Id;
            attributeValue.Order = order.HasValue ? order.Value + 1 : 0;
            attributeValue.Value = tbNewNote.Text;
            attributeValueService.Add( attributeValue, CurrentPersonId );
            attributeValueService.Save( attributeValue, CurrentPersonId);

            if ( cbPrivate.Checked )
            {
                attributeValue.MakePrivate( "View", CurrentPerson, CurrentPersonId );
            }

            if ( subAttributes.Exists( a => a.Key == "Alert") )
            {
                var alertAttributeValue = new AttributeValue();
                alertAttributeValue.IsSystem = false;
                alertAttributeValue.AttributeId = subAttributes.Where( a => a.Key == "Alert" ).Select( a => a.Id ).First();
                alertAttributeValue.EntityId = attributeValue.Id;
                alertAttributeValue.Order = 0;
                alertAttributeValue.Value = cbAlert.Checked.ToTrueFalse();
                attributeValueService.Add( alertAttributeValue, CurrentPersonId );
                attributeValueService.Save( alertAttributeValue, CurrentPersonId );
            }

            if ( subAttributes.Exists( a => a.Key == "Date" ) )
            {
                var dateAttributeValue = new AttributeValue();
                dateAttributeValue.IsSystem = false;
                dateAttributeValue.AttributeId = subAttributes.Where( a => a.Key == "Date" ).Select( a => a.Id ).First();
                dateAttributeValue.EntityId = attributeValue.Id;
                dateAttributeValue.Order = 0;
                dateAttributeValue.Value = DateTime.Now.ToString();
                attributeValueService.Add( dateAttributeValue, CurrentPersonId );
                attributeValueService.Save( dateAttributeValue, CurrentPersonId );
            }

            if ( subAttributes.Exists( a => a.Key == "Title" ) )
            {
                var titleAttributeValue = new AttributeValue();
                titleAttributeValue.IsSystem = false;
                titleAttributeValue.AttributeId = subAttributes.Where( a => a.Key == "Title" ).Select( a => a.Id ).First();
                titleAttributeValue.EntityId = attributeValue.Id;
                titleAttributeValue.Order = 0;
                titleAttributeValue.Value = CurrentPerson.FullName;
                attributeValueService.Add( titleAttributeValue, CurrentPersonId );
                attributeValueService.Save( titleAttributeValue, CurrentPersonId );
            }

            if ( subAttributes.Exists( a => a.Key == "Type" ) )
            {
                var titleAttributeValue = new AttributeValue();
                titleAttributeValue.IsSystem = false;
                titleAttributeValue.AttributeId = subAttributes.Where( a => a.Key == "Type" ).Select( a => a.Id ).First();
                titleAttributeValue.EntityId = attributeValue.Id;
                titleAttributeValue.Order = 0;
                titleAttributeValue.Value = DefinedValue.Read( Rock.SystemGuid.DefinedValue.NOTE_TYPE_MANUAL_NOTE ).Id.ToString();
                attributeValueService.Add( titleAttributeValue, CurrentPersonId );
                attributeValueService.Save( titleAttributeValue, CurrentPersonId );
            }

            ShowNotes();
        }

        private void ReadAttributes()
        {
            var attributeService = new AttributeService();

            // Note Attribute
            string attributeKey = AttributeValue( "AttributeKey" );
            noteAttribute = attributeService.Queryable()
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
            subAttributes = attributeService.Queryable()
                .Where( a =>
                    a.Entity == "Rock.Core.AttributeValue" &&
                    a.EntityQualifierColumn == "AttributeId" &&
                    a.EntityQualifierValue == attributeId )
                .ToList();

            VerifySubAttribute( "Alert", "Alert", "Should note be flagged as an alert", Rock.SystemGuid.FieldType.BOOLEAN, attributeService );
            VerifySubAttribute( "Title", "Title", "Title of note", Rock.SystemGuid.FieldType.TEXT, attributeService );
            VerifySubAttribute( "Date", "Date", "Date note was created", Rock.SystemGuid.FieldType.DATE, attributeService );
            VerifySubAttribute( "Type", "Type", "The type of note created", Rock.SystemGuid.FieldType.DEFINEDVALUE, attributeService );

            phNotes.Controls.Clear();

            var rootElement = new XElement( "notes" );
        }

        private void ShowNotes()
        {
            var service = new AttributeValueService();

            foreach ( var note in service.Queryable()
                .Where( v =>
                    v.AttributeId == noteAttribute.Id &&
                    v.EntityId == contextEntity.Id )
                .OrderByDescending( v => v.Order ) ) 
            {
                if ( note.IsAuthorized( "View", CurrentPerson ) )
                {
                    AddNoteHtml( note );
                }
            }
        }

        private void VerifySubAttribute( string key, string name, string description, Guid fieldType, AttributeService service )
        {
            if ( !subAttributes.Exists( a => a.Key == key ) )
            {
                var attribute = new Rock.Core.Attribute();
                attribute.IsSystem = false;
                attribute.Entity = "Rock.Core.AttributeValue";
                attribute.EntityQualifierColumn = "AttributeId";
                attribute.EntityQualifierValue = noteAttribute.Id.ToString();
                attribute.Key = key;
                attribute.Name = name;
                attribute.Category = string.Empty;
                attribute.Description = description;
                attribute.FieldTypeId = FieldType.Read( fieldType ).Id;
                attribute.DefaultValue = string.Empty;
                attribute.IsMultiValue = false;
                attribute.IsRequired = false;
                service.Add( attribute, CurrentPersonId );
                service.Save( attribute, CurrentPersonId );
                subAttributes.Add( attribute );
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