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
using System.Linq;

using Rock.Data;

namespace Rock.Core
{
    /// <summary>
    /// DefinedType Service class
    /// </summary>
    public partial class DefinedTypeService : Service<DefinedType, DefinedTypeDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedTypeService"/> class
        /// </summary>
        public DefinedTypeService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedTypeService"/> class
        /// </summary>
        public DefinedTypeService(IRepository<DefinedType> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override DefinedType CreateNew()
        {
            return new DefinedType();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<DefinedTypeDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<DefinedTypeDto> QueryableDto( IQueryable<DefinedType> items )
        {
            return items.Select( m => new DefinedTypeDto()
                {
                    IsSystem = m.IsSystem,
                    FieldTypeId = m.FieldTypeId,
                    Order = m.Order,
                    Category = m.Category,
                    Name = m.Name,
                    Description = m.Description,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
