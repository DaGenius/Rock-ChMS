﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.DirectoryServices.AccountManagement;

using Rock.Cms;
using Rock.Web.UI;

namespace Rock.Security.Authentication
{
    /// <summary>
    /// Authenticates a username using Active Directory
    /// </summary>
    [Description( "Active Directory Authentication Provider" )]
    [Export(typeof(AuthenticationComponent))]
    [ExportMetadata("ComponentName", "Active Directory")]
    [BlockProperty( 1, "Server", "Server", "The Active Directory server name", true, "" )]
    [BlockProperty( 2, "Domain", "Server", "The network domain that users belongs to", true, "" )]
    public class ActiveDirectory : AuthenticationComponent
    {
        /// <summary>
        /// Authenticates the specified user name and password
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public override bool Authenticate( User user, string password )
        {
            string username = user.UserName;
            if ( !String.IsNullOrWhiteSpace( AttributeValue( "Domain" ) ) )
                username = string.Format( @"{0}\{1}", AttributeValue( "Domain" ), user.UserName );

            var context = new PrincipalContext( ContextType.Domain, AttributeValue( "Server" ) );
            using ( context )
            {
                return context.ValidateCredentials( user.UserName, password );
            }
        }

        /// <summary>
        /// Encodes the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override string EncodePassword( User user, string password )
        {
            return null;
        }
    }
}