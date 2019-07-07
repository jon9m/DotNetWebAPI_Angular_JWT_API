using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PtcApi.Model {
    public class SecurityManager {
        private JwtSettings _settings = null;

        public SecurityManager (JwtSettings settings) {
            _settings = settings;
        }

        protected string BuildJwtToken (AppUserAuth authUser) {
            Microsoft.IdentityModel.Tokens.SymmetricSecurityKey key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes (_settings.Key));

            //Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim> ();
            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add (new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()));

            //Add custom claims
            jwtClaims.Add (new Claim ("isAuthenticated", authUser.IsAuthenticated.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canAccessProducts", authUser.CanAccessProducts.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canAddProduct", authUser.CanAddProduct.ToString ().ToLower ()));
            jwtClaims.Add (new Claim ("canSaveProduct", authUser.CanSaveProduct.ToString ().ToLower ()));

            var token = new JwtSecurityToken (
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes (_settings.MinutesToExpiration),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler ().WriteToken (token);
        }

        public AppUserAuth ValidateUser (AppUser user) {
            AppUserAuth ret = new AppUserAuth ();
            AppUser authUser = null;

            using (var db = new PtcDbContext ()) {
                authUser = db.Users.Where (
                        u => u.UserName.ToLower () == user.UserName.ToLower () && u.password == user.password)
                    .FirstOrDefault ();
            }

            if (authUser != null) {
                ret = BuildUserAuthObject (authUser);
            }

            return ret;
        }

        public List<AppUserClaim> GetUserClaims (AppUser authUser) {
            List<AppUserClaim> list = new List<AppUserClaim> ();

            try {
                using (var db = new PtcDbContext ()) {
                    list = db.Claims.Where (u => u.UserId == authUser.UserId).ToList ();
                }
            } catch (Exception ex) {
                throw new Exception ("Exception trying to retrieve user claims", ex);
            }

            return list;
        }

        public AppUserAuth BuildUserAuthObject (AppUser authUser) {
            AppUserAuth ret = new AppUserAuth ();
            List<AppUserClaim> claims = new List<AppUserClaim> ();

            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid ().ToString ();

            claims = GetUserClaims (authUser);

            foreach (AppUserClaim claim in claims) {
                try {
                    typeof (AppUserAuth).GetProperty (claim.ClaimType)
                        .SetValue (ret, Convert.ToBoolean (claim.ClaimValue), null);
                } catch (Exception ex) {

                }
            }

            ret.BearerToken = BuildJwtToken(ret);

            return ret;

        }
    }
}