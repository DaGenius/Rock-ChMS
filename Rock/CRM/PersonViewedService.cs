//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
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
using System.Linq;

using Rock.Data;

namespace Rock.CRM
{
	/// <summary>
	/// Person Viewed POCO Service class
	/// </summary>
    public partial class PersonViewedService : Service<Rock.CRM.PersonViewed>
    {
		/// <summary>
		/// Gets Person Vieweds by Target Person Id
		/// </summary>
		/// <param name="targetPersonId">Target Person Id.</param>
		/// <returns>An enumerable list of PersonViewed objects.</returns>
	    public IEnumerable<Rock.CRM.PersonViewed> GetByTargetPersonId( int? targetPersonId )
        {
            return Repository.Find( t => ( t.TargetPersonId == targetPersonId || ( targetPersonId == null && t.TargetPersonId == null ) ) );
        }
		
		/// <summary>
		/// Gets Person Vieweds by Viewer Person Id
		/// </summary>
		/// <param name="viewerPersonId">Viewer Person Id.</param>
		/// <returns>An enumerable list of PersonViewed objects.</returns>
	    public IEnumerable<Rock.CRM.PersonViewed> GetByViewerPersonId( int? viewerPersonId )
        {
            return Repository.Find( t => ( t.ViewerPersonId == viewerPersonId || ( viewerPersonId == null && t.ViewerPersonId == null ) ) );
        }
		
    }
}