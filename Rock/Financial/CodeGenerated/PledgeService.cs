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
    /// Pledge Service class
    /// </summary>
    public partial class PledgeService : Service<Pledge, PledgeDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PledgeService"/> class
        /// </summary>
        public PledgeService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PledgeService"/> class
        /// </summary>
        public PledgeService(IRepository<Pledge> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Pledge CreateNew()
        {
            return new Pledge();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<PledgeDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<PledgeDto> QueryableDto( IQueryable<Pledge> items )
        {
            return items.Select( m => new PledgeDto()
                {
                    PersonId = m.PersonId,
                    FundId = m.FundId,
                    Amount = m.Amount,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    FrequencyTypeId = m.FrequencyTypeId,
                    FrequencyAmount = m.FrequencyAmount,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
