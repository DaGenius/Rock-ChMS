//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// 
    /// </summary>
    public partial class GroupTypeSpecificGroups : RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddBlockType( "Security Role Groups", "Configure Security Role Groups", "~/Blocks/Crm/GroupSecurityRole.ascx", "D9E8C558-4FA1-4E09-912B-CB7B2981DA41" );
            AddPage( "91CCB1C9-5F9F-44F5-8BE2-9EC3A3CFD46F", "Security Role Groups", "Manage Security Role Groups", "F6E2C27F-97B8-4DE9-902C-A50F9014EE8A" );
            AddBlock( "F6E2C27F-97B8-4DE9-902C-A50F9014EE8A", "D9E8C558-4FA1-4E09-912B-CB7B2981DA41", "Security Role Group", "Content", "2406B5B2-6F4E-4816-A095-B4CCF7A35C23" );
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DeleteBlock( "2406B5B2-6F4E-4816-A095-B4CCF7A35C23" );
            DeletePage( "F6E2C27F-97B8-4DE9-902C-A50F9014EE8A" );
            DeleteBlockType( "D9E8C558-4FA1-4E09-912B-CB7B2981DA41" );
        }
    }
}
