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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.Api.Groups
{
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class GroupRoleService : IGroupRoleService
    {
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Models.Groups.GroupRole Get( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Groups.GroupRoleService GroupRoleService = new Rock.Services.Groups.GroupRoleService();
                Rock.Models.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
                if ( GroupRole.Authorized( "View", currentUser ) )
                    return GroupRole;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateGroupRole( string id, Rock.Models.Groups.GroupRole GroupRole )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupRoleService GroupRoleService = new Rock.Services.Groups.GroupRoleService();
                Rock.Models.Groups.GroupRole existingGroupRole = GroupRoleService.Get( int.Parse( id ) );
                if ( existingGroupRole.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingGroupRole).CurrentValues.SetValues(GroupRole);
                    GroupRoleService.Save( existingGroupRole, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateGroupRole( Rock.Models.Groups.GroupRole GroupRole )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupRoleService GroupRoleService = new Rock.Services.Groups.GroupRoleService();
                GroupRoleService.Add( GroupRole );
                GroupRoleService.Save( GroupRole, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteGroupRole( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Groups.GroupRoleService GroupRoleService = new Rock.Services.Groups.GroupRoleService();
                Rock.Models.Groups.GroupRole GroupRole = GroupRoleService.Get( int.Parse( id ) );
                if ( GroupRole.Authorized( "Edit", currentUser ) )
                {
                    GroupRoleService.Delete( GroupRole );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}