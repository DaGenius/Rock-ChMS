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

namespace Rock.Cms
{
    /// <summary>
    /// Data Transfer Object for SiteDomain object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class SiteDomainDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public bool IsSystem { get; set; }

        /// <summary />
        [DataMember]
        public int SiteId { get; set; }

        /// <summary />
        [DataMember]
        public string Domain { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public SiteDomainDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="siteDomain"></param>
        public SiteDomainDto ( SiteDomain siteDomain )
        {
            CopyFromModel( siteDomain );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "IsSystem", this.IsSystem );
            dictionary.Add( "SiteId", this.SiteId );
            dictionary.Add( "Domain", this.Domain );
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
            expando.IsSystem = this.IsSystem;
            expando.SiteId = this.SiteId;
            expando.Domain = this.Domain;
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
            if ( model is SiteDomain )
            {
                var siteDomain = (SiteDomain)model;
                this.IsSystem = siteDomain.IsSystem;
                this.SiteId = siteDomain.SiteId;
                this.Domain = siteDomain.Domain;
                this.Id = siteDomain.Id;
                this.Guid = siteDomain.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is SiteDomain )
            {
                var siteDomain = (SiteDomain)model;
                siteDomain.IsSystem = this.IsSystem;
                siteDomain.SiteId = this.SiteId;
                siteDomain.Domain = this.Domain;
                siteDomain.Id = this.Id;
                siteDomain.Guid = this.Guid;
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
    public static class SiteDomainDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static SiteDomain ToModel( this SiteDomainDto value )
        {
            SiteDomain result = new SiteDomain();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<SiteDomain> ToModel( this List<SiteDomainDto> value )
        {
            List<SiteDomain> result = new List<SiteDomain>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<SiteDomainDto> ToDto( this List<SiteDomain> value )
        {
            List<SiteDomainDto> result = new List<SiteDomainDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static SiteDomainDto ToDto( this SiteDomain value )
        {
            return new SiteDomainDto( value );
        }

    }
}