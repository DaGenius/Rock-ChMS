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
    /// Batch Service class
    /// </summary>
    public partial class BatchService : Service<Batch, BatchDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchService"/> class
        /// </summary>
        public BatchService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchService"/> class
        /// </summary>
        public BatchService(IRepository<Batch> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Batch CreateNew()
        {
            return new Batch();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<BatchDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<BatchDto> QueryableDto( IQueryable<Batch> items )
        {
            return items.Select( m => new BatchDto()
                {
                    Name = m.Name,
                    BatchDate = m.BatchDate,
                    IsClosed = m.IsClosed,
                    CampusId = m.CampusId,
                    Entity = m.Entity,
                    EntityId = m.EntityId,
                    ForeignReference = m.ForeignReference,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
