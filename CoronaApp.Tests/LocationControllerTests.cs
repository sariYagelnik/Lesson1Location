using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit; 

namespace CoronaApp.Tests
{
    public class LocationControllerTests : IClassFixture<WebApplicationFactory<Locations.Api.Startup>>
    {

        private readonly WebApplicationFactory<Locations.Api.Startup> _factory;

        public LocationControllerTests(WebApplicationFactory<Locations.Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetLocations_ByCity_ReturnLocations()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/Location/city/Jerusalem");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void AddLocations_ById_Added()
        {
            List<CoronaApp.Services.Models.Location> locationsToAdd = new List<CoronaApp.Services.Models.Location>(new CoronaApp.Services.Models.Location[] {
                new CoronaApp.Services.Models.Location { City = "aaaaaaaaa", StartDate = DateTime.Now, EndDate = DateTime.Now, LocationDescription = "Leumi Park" },
                new CoronaApp.Services.Models.Location { City = "aaaaaaa", StartDate = DateTime.Now, EndDate = DateTime.Now, LocationDescription = "Leumi Park" },
                new CoronaApp.Services.Models.Location { City = "aaaaa", StartDate = DateTime.Now, EndDate = DateTime.Now, LocationDescription = "Leumi Park" },
            });

            var request = new
            {
                Uri = "/api/Location/1",
                Body = locationsToAdd
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync(request.Uri, ContentHelper.GetStringContent(request.Body));
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void AddWrongLocations_ById_NotAdded()
        {
            List<CoronaApp.Services.Models.Location> locationsToAdd = new List<CoronaApp.Services.Models.Location>(new CoronaApp.Services.Models.Location[] {
                new CoronaApp.Services.Models.Location { StartDate = DateTime.Now, EndDate = DateTime.Now, LocationDescription = "Leumi Park" },
                new CoronaApp.Services.Models.Location { City = "Ramat Gan", StartDate = DateTime.Now, EndDate = DateTime.Now, LocationDescription = "Leumi Park" },
                new CoronaApp.Services.Models.Location { City = "Ramat Gan", EndDate = DateTime.Now, LocationDescription = "" },
            });

            var request = new
            {
                Uri = "/api/Location/1",
                Body = locationsToAdd
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync(request.Uri, ContentHelper.GetStringContent(request.Body));
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
