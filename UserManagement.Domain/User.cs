#region IncludedNamespaces
using System;
using System.Collections.Generic;
using System.Text;
#endregion IncludedNamespaces

namespace UserManagement.Domain
{
    #region User
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        #region Name
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        #endregion Name

        #region DateOfBirth
        /// <summary>
        /// DateOfBirth
        /// </summary>
        public string DateOfBirth { get; set; }
        #endregion DateOfBirth
    }
    #endregion User
}
