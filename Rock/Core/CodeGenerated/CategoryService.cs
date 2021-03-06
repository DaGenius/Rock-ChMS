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
    /// Category Service class
    /// </summary>
    public partial class CategoryService : Service<Category, CategoryDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class
        /// </summary>
        public CategoryService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class
        /// </summary>
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Category CreateNew()
        {
            return new Category();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<CategoryDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<CategoryDto> QueryableDto( IQueryable<Category> items )
        {
            return items.Select( m => new CategoryDto()
                {
                    IsSystem = m.IsSystem,
                    ParentCategoryId = m.ParentCategoryId,
                    EntityTypeId = m.EntityTypeId,
                    EntityTypeQualifierColumn = m.EntityTypeQualifierColumn,
                    EntityTypeQualifierValue = m.EntityTypeQualifierValue,
                    Name = m.Name,
                    FileId = m.FileId,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
