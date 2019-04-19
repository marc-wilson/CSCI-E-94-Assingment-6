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

		public static string LastName(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value ?? string.Empty;
		}

		public static string EmailAddress(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? string.Empty;
		}

		public static string ObjectIdentifier(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ?? string.Empty;
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
		public string LastName
		{
			get
			{
				return _claimsPrincipal.LastName();
			}
		}
		public string EmailAddress
		{
			get
			{
				return _claimsPrincipal.EmailAddress();
			}
		}
		public string ObjectIdentifier
		{
			get
			{
				return _claimsPrincipal.ObjectIdentifier();
			}
		}
	}
}
