using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace FirstMVC.Helpers
{
    public sealed class Helper
    {
        #region Singleton
        private static readonly Lazy<Helper> lazy = new Lazy<Helper>(() => new Helper());

        public static Helper Instance { get { return lazy.Value; } }

        private Helper()
        {
        } 
        #endregion

        public string UserId
        {
            get
            {
                var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    // the principal identity is a claims identity.
                    // now we need to find the NameIdentifier claim
                    var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        return userIdClaim.Value;
                    }
                }

                return null;
            }
        }
    }
}