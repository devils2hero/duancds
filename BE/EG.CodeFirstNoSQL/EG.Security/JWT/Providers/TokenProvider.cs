using Microsoft.IdentityModel.Tokens;
using EG.Web.Core.Helpers;
using EG.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EG.Model.Models.Childev;

namespace EG.Security.JWT.Providers
{
    public static class TokenProvider
    {
        //public static string BuildToken(string Key, string Issuer, string System, UserCustomer user, DateTime Expried)
        //{
        //    try
        //    {
        //        List<Claim> claims = new List<Claim>() {
        //            new Claim("Customer", user._id.ToString()),
        //            new Claim("Name", user.Name),
        //            new Claim("CustomerGroup_id", user.CustomerGroup_id)
        //        };
        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(Issuer,
        //          System,
        //          claims,
        //          expires: Expried,
        //          signingCredentials: creds);
        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new System.ArgumentException(ex.ToString());
        //    }
        //}
        public static List<JWTClaimToken> GetInfoByJWTTokens(ClaimsPrincipal data)
        {
            List<JWTClaimToken> list = new List<JWTClaimToken>();
            foreach (var item in data.Claims)
            {
                list.Add(new JWTClaimToken { Key = item.Type, Value = item.Value });
            }
            return list;
        }
        //public static string RemoveToken(string Key, string Issuer, string System, User user, List<AM.Model.Models.Core.API> apis)
        //{
        //    List<Claim> claims = new List<Claim>() {
        //            new Claim("Name", user.Name),
        //            new Claim("SupperUser", user.SupperUser.ToString()),
        //            new Claim("Address", user.Address),
        //            new Claim("UserID", user.Id),
        //            new Claim("URL", apis.GetDataListAppendString()),
        //            new Claim(JwtRegisteredClaimNames.Jti, user.Id)
        //    };
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(Issuer,
        //      System,
        //      claims,
        //      expires: DateTime.Now.AddMinutes(-10),
        //      signingCredentials: creds);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
