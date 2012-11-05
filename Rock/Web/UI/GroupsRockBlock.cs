using System;

namespace Rock.Web.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupsRockBlock : RockBlock
    {
        /// <summary>
        /// Gets a value indicating whether [group type specific].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [group type specific]; otherwise, <c>false</c>.
        /// </value>
        public bool GroupTypeSpecific {
            get
            {
                return ( GroupTypeGuid != null );
            }
        }

        /// <summary>
        /// Gets or sets the group type GUID.
        /// </summary>
        /// <value>
        /// The group type GUID.
        /// </value>
        public Guid? GroupTypeGuid { get; set;}
    }
}