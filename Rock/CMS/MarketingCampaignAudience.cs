﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;
using Rock.Data;

namespace Rock.Cms
{
    /// <summary>
    /// MarketingCampaignAudience POCO Entity
    /// </summary>
    [Table( "cmsMarketingCampaignAudience" )]
    public partial class MarketingCampaignAudience : Model<MarketingCampaignAudience>, IExportable
    {
        /// <summary>
        /// Gets or sets the marketing campaign id.
        /// </summary>
        /// <value>
        /// The marketing campaign id.
        /// </value>
        [DataMember]
        public int MarketingCampaignId { get; set; }

        /// <summary>
        /// Gets or sets the audience type id.
        /// </summary>
        /// <value>
        /// The audience type id.
        /// </value>
        [DataMember]
        public int AudienceTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is primary.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is primary; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Reads the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static MarketingCampaignAudience Read( int id )
        {
            return Read<MarketingCampaignAudience>( id );
        }

        /// <summary>
        /// Gets or sets the marketing campaign.
        /// </summary>
        /// <value>
        /// The marketing campaign.
        /// </value>
        public virtual MarketingCampaign MarketingCampaign { get; set; }

        /// <summary>
        /// Gets or sets the audience type value.
        /// </summary>
        /// <value>
        /// The audience type value.
        /// </value>
        public virtual Core.DefinedValue AudienceTypeValue { get; set; }

        /// <summary>
        /// Exports the object as JSON.
        /// </summary>
        /// <returns></returns>
        public string ExportJson()
        {
            return ExportObject().ToJSON();
        }

        /// <summary>
        /// Exports the object.
        /// </summary>
        /// <returns></returns>
        public object ExportObject()
        {
            return this.ToDynamic();
        }

        /// <summary>
        /// Imports the object from JSON.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ImportJson( string data )
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class MarketingCampaignAudienceConfiguration : EntityTypeConfiguration<MarketingCampaignAudience>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketingCampaignAudienceConfiguration" /> class.
        /// </summary>
        public MarketingCampaignAudienceConfiguration()
        {
            this.HasRequired( p => p.MarketingCampaign ).WithMany().HasForeignKey( p => p.MarketingCampaignId ).WillCascadeOnDelete( true );
            this.HasRequired( p => p.AudienceTypeValue ).WithMany().HasForeignKey( p => p.AudienceTypeValueId ).WillCascadeOnDelete( true );
        }
    }
}