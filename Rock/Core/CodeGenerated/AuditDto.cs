//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Core
{
    /// <summary>
    /// Data Transfer Object for Audit object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class AuditDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public int EntityTypeId { get; set; }

        /// <summary />
        [DataMember]
        public int EntityId { get; set; }

        /// <summary />
        [DataMember]
        public string Title { get; set; }

        /// <summary />
        [DataMember]
        public AuditType AuditType { get; set; }

        /// <summary />
        [DataMember]
        public string Properties { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? DateTime { get; set; }

        /// <summary />
        [DataMember]
        public int? PersonId { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public AuditDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="audit"></param>
        public AuditDto ( Audit audit )
        {
            CopyFromModel( audit );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "EntityTypeId", this.EntityTypeId );
            dictionary.Add( "EntityId", this.EntityId );
            dictionary.Add( "Title", this.Title );
            dictionary.Add( "AuditType", this.AuditType );
            dictionary.Add( "Properties", this.Properties );
            dictionary.Add( "DateTime", this.DateTime );
            dictionary.Add( "PersonId", this.PersonId );
            dictionary.Add( "Id", this.Id );
            dictionary.Add( "Guid", this.Guid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToDynamic()
        {
            dynamic expando = new ExpandoObject();
            expando.EntityTypeId = this.EntityTypeId;
            expando.EntityId = this.EntityId;
            expando.Title = this.Title;
            expando.AuditType = this.AuditType;
            expando.Properties = this.Properties;
            expando.DateTime = this.DateTime;
            expando.PersonId = this.PersonId;
            expando.Id = this.Id;
            expando.Guid = this.Guid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyFromModel( IEntity model )
        {
            if ( model is Audit )
            {
                var audit = (Audit)model;
                this.EntityTypeId = audit.EntityTypeId;
                this.EntityId = audit.EntityId;
                this.Title = audit.Title;
                this.AuditType = audit.AuditType;
                this.Properties = audit.Properties;
                this.DateTime = audit.DateTime;
                this.PersonId = audit.PersonId;
                this.Id = audit.Id;
                this.Guid = audit.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is Audit )
            {
                var audit = (Audit)model;
                audit.EntityTypeId = this.EntityTypeId;
                audit.EntityId = this.EntityId;
                audit.Title = this.Title;
                audit.AuditType = this.AuditType;
                audit.Properties = this.Properties;
                audit.DateTime = this.DateTime;
                audit.PersonId = this.PersonId;
                audit.Id = this.Id;
                audit.Guid = this.Guid;
            }
        }

        /// <summary>
        /// Converts to liquidizable object for dotLiquid templating
        /// </summary>
        /// <returns></returns>
        public object ToLiquid()
        {
            return this.ToDictionary();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class AuditDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Audit ToModel( this AuditDto value )
        {
            Audit result = new Audit();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<Audit> ToModel( this List<AuditDto> value )
        {
            List<Audit> result = new List<Audit>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<AuditDto> ToDto( this List<Audit> value )
        {
            List<AuditDto> result = new List<AuditDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static AuditDto ToDto( this Audit value )
        {
            return new AuditDto( value );
        }

    }
}