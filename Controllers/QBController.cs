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
using System.Net;
using System.Net.Http;

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
        static string redirectUrl = "http://localhost:4200/quickbooks/";
        static string appEnvironment = "sandbox";
        static string access_token = "";
        static string realmId = "193514879130364";
        static string baseUrl = "https://quickbooks.api.intuit.com/v3/company/193514879130364/invoice?minorversion=4";

        private static OAuth2Client auth2Client = new OAuth2Client(clientid, clientsecret, redirectUrl, appEnvironment);
        private static readonly HttpClient client = new HttpClient();

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
        public async Task<string> ReturnFromAuth(StatePair pair)
        {
            var tokenResponse = await auth2Client.GetBearerTokenAsync(pair.Code);
            //retrieve access_token and refresh_token
            access_token = tokenResponse.AccessToken;
            var idToken = tokenResponse.IdentityToken;

            System.Console.WriteLine(idToken);

            var isTokenValid = await auth2Client.ValidateIDTokenAsync(idToken);

            System.Console.WriteLine(isTokenValid);

            return redirectUrl;
        }
    }
}