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

namespace Rock.Financial
{
    /// <summary>
    /// Data Transfer Object for Gateway object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class GatewayDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public string Name { get; set; }

        /// <summary />
        [DataMember]
        public string Description { get; set; }

        /// <summary />
        [DataMember]
        public string ApiUrl { get; set; }

        /// <summary />
        [DataMember]
        public string ApiKey { get; set; }

        /// <summary />
        [DataMember]
        public string ApiSecret { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public GatewayDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="gateway"></param>
        public GatewayDto ( Gateway gateway )
        {
            CopyFromModel( gateway );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "Name", this.Name );
            dictionary.Add( "Description", this.Description );
            dictionary.Add( "ApiUrl", this.ApiUrl );
            dictionary.Add( "ApiKey", this.ApiKey );
            dictionary.Add( "ApiSecret", this.ApiSecret );
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
            expando.Name = this.Name;
            expando.Description = this.Description;
            expando.ApiUrl = this.ApiUrl;
            expando.ApiKey = this.ApiKey;
            expando.ApiSecret = this.ApiSecret;
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
            if ( model is Gateway )
            {
                var gateway = (Gateway)model;
                this.Name = gateway.Name;
                this.Description = gateway.Description;
                this.ApiUrl = gateway.ApiUrl;
                this.ApiKey = gateway.ApiKey;
                this.ApiSecret = gateway.ApiSecret;
                this.Id = gateway.Id;
                this.Guid = gateway.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is Gateway )
            {
                var gateway = (Gateway)model;
                gateway.Name = this.Name;
                gateway.Description = this.Description;
                gateway.ApiUrl = this.ApiUrl;
                gateway.ApiKey = this.ApiKey;
                gateway.ApiSecret = this.ApiSecret;
                gateway.Id = this.Id;
                gateway.Guid = this.Guid;
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
    public static class GatewayDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Gateway ToModel( this GatewayDto value )
        {
            Gateway result = new Gateway();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<Gateway> ToModel( this List<GatewayDto> value )
        {
            List<Gateway> result = new List<Gateway>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<GatewayDto> ToDto( this List<Gateway> value )
        {
            List<GatewayDto> result = new List<GatewayDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static GatewayDto ToDto( this Gateway value )
        {
            return new GatewayDto( value );
        }

    }
}