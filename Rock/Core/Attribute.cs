//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Rock.Data;

namespace Rock.Core
{
    /// <summary>
    /// Attribute POCO Entity.
    /// </summary>
    [Table( "coreAttribute" )]
    public partial class Attribute : Model<Attribute>, IOrdered
    {
        /// <summary>
        /// Gets or sets the System.
        /// </summary>
        /// <value>
        /// System.
        /// </value>
        [Required]
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// Gets or sets the Field Type Id.
        /// </summary>
        /// <value>
        /// Field Type Id.
        /// </value>
        [Required]
        public int FieldTypeId { get; set; }

        /// <summary>
        /// Gets or sets the entity type id.
        /// </summary>
        /// <value>
        /// The entity type id.
        /// </value>
        public int? EntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public virtual Core.EntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets the Entity Qualifier Column.
        /// </summary>
        /// <value>
        /// Entity Qualifier Column.
        /// </value>
        [MaxLength( 50 )]
        public string EntityTypeQualifierColumn { get; set; }
        
        /// <summary>
        /// Gets or sets the Entity Qualifier Value.
        /// </summary>
        /// <value>
        /// Entity Qualifier Value.
        /// </value>
        [MaxLength( 200 )]
        public string EntityTypeQualifierValue { get; set; }
        
        /// <summary>
        /// Gets or sets the Key.
        /// </summary>
        /// <value>
        /// Key.
        /// </value>
        [Required]
        [MaxLength( 50 )]
        public string Key { get; set; }
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [Required]
        [MaxLength( 100 )]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// Category.
        /// </value>
        [MaxLength( 100 )]
        public string Category { get; set; }
        
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// Description.
        /// </value>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// Order.
        /// </value>
        [Required]
        public int Order { get; set; }
        
        /// <summary>
        /// Gets or sets the Grid Column.
        /// </summary>
        /// <value>
        /// Grid Column.
        /// </value>
        [Required]
        public bool IsGridColumn { get; set; }
        
        /// <summary>
        /// Gets or sets the Default Value.
        /// </summary>
        /// <value>
        /// Default Value.
        /// </value>
        public string DefaultValue { get; set; }
        
        /// <summary>
        /// Gets or sets the Multi Value.
        /// </summary>
        /// <value>
        /// Multi Value.
        /// </value>
        [Required]
        public bool IsMultiValue { get; set; }
        
        /// <summary>
        /// Gets or sets the Required.
        /// </summary>
        /// <value>
        /// Required.
        /// </value>
        [Required]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <returns></returns>
        public override IDto Dto
        {
            get { return this.ToDto(); }
        }

        /// <summary>
        /// Static Method to return an object based on the id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public static Attribute Read( int id )
        {
            return Read<Attribute>( id );
        }
                
        /// <summary>
        /// Gets or sets the Attribute Qualifiers.
        /// </summary>
        /// <value>
        /// Collection of Attribute Qualifiers.
        /// </value>
        public virtual ICollection<AttributeQualifier> AttributeQualifiers { get; set; }
        
        /// <summary>
        /// Gets or sets the Field Type.
        /// </summary>
        /// <value>
        /// A <see cref="FieldType"/> object.
        /// </value>
        public virtual FieldType FieldType { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Key;
        }
}

    /// <summary>
    /// Attribute Configuration class.
    /// </summary>
    public partial class AttributeConfiguration : EntityTypeConfiguration<Attribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeConfiguration"/> class.
        /// </summary>
        public AttributeConfiguration()
        {
            this.HasRequired( p => p.FieldType ).WithMany( ).HasForeignKey( p => p.FieldTypeId ).WillCascadeOnDelete( false );
            this.HasOptional( p => p.EntityType ).WithMany().HasForeignKey( p => p.EntityTypeId ).WillCascadeOnDelete( false );
        }
    }
}
