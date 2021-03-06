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
using Intuit.Ipp.Security;
using Intuit.Ipp.Core;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Data;
using System.Linq;

namespace CheckIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuickBookController : ControllerBase
    {
        private readonly QuickRepository _qrepo;
        private readonly InvoiceRepository _irepo;
        private readonly AuthRepository _auth;

        public QuickBookController(QuickRepository qrepo, InvoiceRepository irepo, AuthRepository auth)
        {
            _qrepo = qrepo;
            _irepo = irepo;
            _auth = auth;
        }

        static string clientid = "L0DmejFFXUqcTekLnCsfYPhMOelKJ4NajoabbbEVsQZZXLtZ1C";
        static string clientsecret = "2fIgJ5b2SG4YJLgklJYfjZe2kKVvY7lhLtRyMEKI";
        static string redirectUrl = "http://localhost:4200/quickbooks/";
        static string appEnvironment = "sandbox";
        static string access_token = "";
        string idToken = "";
        string realmId = "";

        private static OAuth2Client auth2Client = new OAuth2Client(clientid, clientsecret, redirectUrl, appEnvironment);
        private static readonly HttpClient client = new HttpClient();

        [HttpGet("InitAuth")]
        public string InitiateAuth()
        {
            //Prepare scopes
            List<OidcScopes> scopes = new List<OidcScopes>();
            //scopes.Add(OidcScopes.Email);
            scopes.Add(OidcScopes.Accounting);
            //scopes.Add(OidcScopes.OpenId);

            //Get the authorization URL
            string authorizeUrl = auth2Client.GetAuthorizationURL(scopes);

            return authorizeUrl;
        }

        [HttpPost("ReturnAuth")]
        public async Task<string> ReturnFromAuth(StatePair pair)
        {
            System.Console.WriteLine("Code: " + pair.Code + "\n");
            System.Console.WriteLine("State: " + pair.State + "\n");
            System.Console.WriteLine("RealmId: " + pair.RealmId + "\n");

            var tokenResponse = await auth2Client.GetBearerTokenAsync(pair.Code);

            //retrieve access_token and refresh_token
            access_token = tokenResponse.AccessToken;
            idToken = tokenResponse.IdentityToken;

            var isTokenValid = await auth2Client.ValidateIDTokenAsync(idToken);

            await SetApiAuthToken(access_token, pair.RealmId);

            System.Console.WriteLine(isTokenValid);

            return redirectUrl;
        }

        [HttpPost("QuickAPICall")]
        public async Task<string> QuickCall(int InvoiceId)
        {
            string authToken = GetApiAuthToken().Result;
            string realmID = GetRealmID().Result;

            var invoiceToConvert = await _irepo.GetOneInvoice(InvoiceId);
            await _qrepo.SendInvoice(invoiceToConvert, authToken, realmID);

            return "lol";
        }

        [HttpGet("GetCurrentUser")]
        public async Task<CheckIT.API.Models.User> GetCurrentUser()
        {
            CheckIT.API.Models.User user = await _auth.GetUser(this.User.Identity.Name);

            return user;
        }

        [HttpGet("GetApiAuthToken")]
        public async Task<string> GetApiAuthToken()
        {
            CheckIT.API.Models.User user = await _auth.GetUser(this.User.Identity.Name);
            string token = user.ApiAuthToken;

            return token;
        }

        [HttpGet("GetRealmID")]
        public async Task<string> GetRealmID()
        {
            CheckIT.API.Models.User user = await _auth.GetUser(this.User.Identity.Name);
            string token = user.realmID;

            return token;
        }

        [HttpGet("SetApiAuthToken")]
        public async Task<IActionResult> SetApiAuthToken(string token, string realmID)
        {
            CheckIT.API.Models.User user = await _auth.GetUser(this.User.Identity.Name);
            
            if (await _auth.SetApiAuthToken(user.Id, token, realmID))
            {
                return StatusCode(201);
            }

            return BadRequest("Could not find User");
        }

    }
}