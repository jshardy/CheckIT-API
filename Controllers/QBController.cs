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
        static string redirectUrl = "https://developer.intuit.com/v2/OAuth2Playground/RedirectUrl";
        static string appEnvironment = "sandbox";

        public static OAuth2Client auth2Client = new OAuth2Client(clientid, clientsecret, redirectUrl, appEnvironment);

        [HttpGet("InitAuth")]
        public IActionResult InitiateAuth()
        {
            //Prepare scopes
            List<OidcScopes> scopes = new List<OidcScopes>();
            scopes.Add(OidcScopes.OpenId);
            scopes.Add(OidcScopes.Email);

            //Get the authorization URL
            string authorizeUrl = auth2Client.GetAuthorizationURL(scopes);

            return Redirect(authorizeUrl);
        }
    }
}