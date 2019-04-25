using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Intuit.Ipp.OAuth2PlatformClient;
using Newtonsoft.Json;

namespace CheckIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuickBookController : ControllerBase
    {
        private readonly QuickRepository _repo;

        static string clientid = "L0DmejFFXUqcTekLnCsfYPhMOelKJ4NajoabbbEVsQZZXLtZ1C";
        static string clientsecret = "2fIgJ5b2SG4YJLgklJYfjZe2kKVvY7lhLtRyMEKI";
        static string redirectUrl = "http://localhost:4200/";
        static string appEnvironment = "sandbox";

        public static OAuth2Client auth2Client = new OAuth2Client(clientid, clientsecret, redirectUrl, appEnvironment);

        [HttpGet("InitAuth")]
        public string InitiateAuth()
        {
            //Prepare scopes
            List<OidcScopes> scopes = new List<OidcScopes>();
            scopes.Add(OidcScopes.OpenId);
            scopes.Add(OidcScopes.Email);

            //Get the authorization URL
            string authorizeUrl = auth2Client.GetAuthorizationURL(scopes);

            return authorizeUrl;
        }

        [HttpPost("ReturnAuth")]
        public async Task<IActionResult> ReturnFromAuth(string state, string code)
        {
            var tokenResponse = await auth2Client.GetBearerTokenAsync(code);
            //retrieve access_token and refresh_token
            var temp1 = tokenResponse.AccessToken;
            var temp2 = tokenResponse.RefreshToken;
            var idToken = tokenResponse.IdentityToken;

            var isTokenValid = await auth2Client.ValidateIDTokenAsync(idToken);

            return Ok(isTokenValid);
        }
    }
}