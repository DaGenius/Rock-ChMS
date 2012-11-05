using System;
using Rock.Web.UI;

/// <summary>
/// 
/// </summary>
public partial class GroupsSecurityRole : GroupsRockBlock
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load( object sender, EventArgs e )
    {
        GroupsRockBlock groupsBase = this.LoadControl( "~/Blocks/Crm/Groups.ascx" ) as GroupsRockBlock;
        groupsBase.GroupTypeGuid = Rock.SystemGuid.GroupType.GROUPTYPE_SECURITY_ROLE;
        groupsBase.CurrentPage = this.CurrentPage;
        groupsBase.CurrentBlock = this.CurrentBlock;
        this.Controls.Add( groupsBase );
    }
}