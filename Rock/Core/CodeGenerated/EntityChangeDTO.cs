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
    /// Data Transfer Object for EntityChange object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class EntityChangeDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public Guid ChangeSet { get; set; }

        /// <summary />
        [DataMember]
        public string ChangeType { get; set; }

        /// <summary />
        [DataMember]
        public int EntityTypeId { get; set; }

        /// <summary />
        [DataMember]
        public int EntityId { get; set; }

        /// <summary />
        [DataMember]
        public string Property { get; set; }

        /// <summary />
        [DataMember]
        public string OriginalValue { get; set; }

        /// <summary />
        [DataMember]
        public string CurrentValue { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public int? CreatedByPersonId { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public EntityChangeDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="entityChange"></param>
        public EntityChangeDto ( EntityChange entityChange )
        {
            CopyFromModel( entityChange );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "ChangeSet", this.ChangeSet );
            dictionary.Add( "ChangeType", this.ChangeType );
            dictionary.Add( "EntityTypeId", this.EntityTypeId );
            dictionary.Add( "EntityId", this.EntityId );
            dictionary.Add( "Property", this.Property );
            dictionary.Add( "OriginalValue", this.OriginalValue );
            dictionary.Add( "CurrentValue", this.CurrentValue );
            dictionary.Add( "CreatedDateTime", this.CreatedDateTime );
            dictionary.Add( "CreatedByPersonId", this.CreatedByPersonId );
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
            expando.ChangeSet = this.ChangeSet;
            expando.ChangeType = this.ChangeType;
            expando.EntityTypeId = this.EntityTypeId;
            expando.EntityId = this.EntityId;
            expando.Property = this.Property;
            expando.OriginalValue = this.OriginalValue;
            expando.CurrentValue = this.CurrentValue;
            expando.CreatedDateTime = this.CreatedDateTime;
            expando.CreatedByPersonId = this.CreatedByPersonId;
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
            if ( model is EntityChange )
            {
                var entityChange = (EntityChange)model;
                this.ChangeSet = entityChange.ChangeSet;
                this.ChangeType = entityChange.ChangeType;
                this.EntityTypeId = entityChange.EntityTypeId;
                this.EntityId = entityChange.EntityId;
                this.Property = entityChange.Property;
                this.OriginalValue = entityChange.OriginalValue;
                this.CurrentValue = entityChange.CurrentValue;
                this.CreatedDateTime = entityChange.CreatedDateTime;
                this.CreatedByPersonId = entityChange.CreatedByPersonId;
                this.Id = entityChange.Id;
                this.Guid = entityChange.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is EntityChange )
            {
                var entityChange = (EntityChange)model;
                entityChange.ChangeSet = this.ChangeSet;
                entityChange.ChangeType = this.ChangeType;
                entityChange.EntityTypeId = this.EntityTypeId;
                entityChange.EntityId = this.EntityId;
                entityChange.Property = this.Property;
                entityChange.OriginalValue = this.OriginalValue;
                entityChange.CurrentValue = this.CurrentValue;
                entityChange.CreatedDateTime = this.CreatedDateTime;
                entityChange.CreatedByPersonId = this.CreatedByPersonId;
                entityChange.Id = this.Id;
                entityChange.Guid = this.Guid;
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
    public static class EntityChangeDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static EntityChange ToModel( this EntityChangeDto value )
        {
            EntityChange result = new EntityChange();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<EntityChange> ToModel( this List<EntityChangeDto> value )
        {
            List<EntityChange> result = new List<EntityChange>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<EntityChangeDto> ToDto( this List<EntityChange> value )
        {
            List<EntityChangeDto> result = new List<EntityChangeDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static EntityChangeDto ToDto( this EntityChange value )
        {
            return new EntityChangeDto( value );
        }

    }
}