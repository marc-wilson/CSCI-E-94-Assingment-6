using System.Security.Claims;

namespace HW6MovieSharing.Models
{
	/// <summary>
	/// Claims Extension Method Helpers
	/// </summary>
	public static class ClaimsExtensions
	{
		/// <summary>
		/// Get First Name
		/// </summary>
		/// <param name="claims"></param>
		/// <returns></returns>
		public static string FirstName(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value ?? string.Empty;
		}

		/// <summary>
		/// Get Last Name
		/// </summary>
		/// <param name="claims"></param>
		/// <returns></returns>
		public static string LastName(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value ?? string.Empty;
		}

		/// <summary>
		/// Get Email Address
		/// </summary>
		/// <param name="claims"></param>
		/// <returns></returns>
		public static string EmailAddress(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? string.Empty;
		}

		/// <summary>
		/// Get the Object Identifier
		/// </summary>
		/// <param name="claims"></param>
		/// <returns></returns>
		public static string ObjectIdentifier(this ClaimsPrincipal claims)
		{
			return claims.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ?? string.Empty;
		}
	}
	/// <summary>
	/// Claims Accessor
	/// </summary>
	public class DecodedClaims
	{
		/// <summary>
		/// Claims Principal of the authenticated user
		/// </summary>
		private readonly ClaimsPrincipal _claimsPrincipal;
		/// <summary>
		/// Decoded Claims initializer
		/// </summary>
		/// <param name="claims"></param>
		public DecodedClaims(ClaimsPrincipal claims)
		{
			_claimsPrincipal = claims;
		}
		/// <summary>
		/// Gets the first name
		/// </summary>
		public string FirstName
		{
			get
			{
				return _claimsPrincipal.FirstName();
			}
		}
		/// <summary>
		/// Gets the last name
		/// </summary>
		public string LastName
		{
			get
			{
				return _claimsPrincipal.LastName();
			}
		}
		/// <summary>
		/// Gets the email address
		/// </summary>
		public string EmailAddress
		{
			get
			{
				return _claimsPrincipal.EmailAddress();
			}
		}
		/// <summary>
		/// Gets the object identifier
		/// </summary>
		public string ObjectIdentifier
		{
			get
			{
				return _claimsPrincipal.ObjectIdentifier();
			}
		}
	}
}
