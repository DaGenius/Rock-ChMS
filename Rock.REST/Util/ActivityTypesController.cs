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

using Rock.Util;

namespace Rock.Rest.Util
{
    /// <summary>
    /// ActivityTypes REST API
    /// </summary>
    public partial class ActivityTypesController : Rock.Rest.ApiController<Rock.Util.ActivityType, Rock.Util.ActivityTypeDto>
    {
        public ActivityTypesController() : base( new Rock.Util.ActivityTypeService() ) { } 
    }
}
