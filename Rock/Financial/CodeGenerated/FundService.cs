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

namespace Rock.Financial
{
    /// <summary>
    /// Fund Service class
    /// </summary>
    public partial class FundService : Service<Fund, FundDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundService"/> class
        /// </summary>
        public FundService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FundService"/> class
        /// </summary>
        public FundService(IRepository<Fund> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Fund CreateNew()
        {
            return new Fund();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<FundDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<FundDto> QueryableDto( IQueryable<Fund> items )
        {
            return items.Select( m => new FundDto()
                {
                    Name = m.Name,
                    PublicName = m.PublicName,
                    Description = m.Description,
                    ParentFundId = m.ParentFundId,
                    IsTaxDeductible = m.IsTaxDeductible,
                    Order = m.Order,
                    IsActive = m.IsActive,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    IsPledgable = m.IsPledgable,
                    GlCode = m.GlCode,
                    FundTypeId = m.FundTypeId,
                    Entity = m.Entity,
                    EntityId = m.EntityId,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
