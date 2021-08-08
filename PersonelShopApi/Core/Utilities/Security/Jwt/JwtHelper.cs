using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration;
        TokenOptions _tokenOptions;
        DateTime _accesTokenExpiration;
        public JwtHelper()
        {
            Configuration = ConfigurationResolver.GetConfiguration();
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpitation);
        }
        public AccessToken CreateToken(User user, Role role)
        {
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, role);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpiration
            };
        }

        JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials, Role role)
        {
            JwtSecurityToken jwt = new JwtSecurityToken
            (
                issuer : tokenOptions.Issuer,
                audience : tokenOptions.Audience,
                expires : _accesTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,role),
                signingCredentials:signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, Role role)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name} {user.SurName}");
            claims.AddRole(role.Name);
            return claims;
        }
    }
}
