using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HW6MovieSharing.Models
{
	public static class ClaimsExtensions
	{
		public static string FirstName(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value ?? string.Empty;
		}
	}
	public class DecodedClaims
	{
		private readonly ClaimsPrincipal _claimsPrincipal;
		public DecodedClaims(ClaimsPrincipal claims)
		{
			_claimsPrincipal = claims;
		}

		public string FirstName
		{
			get
			{
				return _claimsPrincipal.FirstName();
			}
		}
	}
}
