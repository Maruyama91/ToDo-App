using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Web.Http;
using ToDoAPI.Controllers;
using ToDoAPI.Data;
using ToDoAPI.Data.EFCore;
using ToDoAPI.Models;
using System.Net.Http;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;

namespace ToDoAPI.Tests
{
    //TestFixture to mark the class for testing.
    [TestFixture]
    public class TodoTests
    {
        private HttpClient client;

        private HttpResponseMessage response;

        //Setup attribute use for setup the test.
        [SetUp]
        public void SetUP()
        {
            client = new HttpClient();

            var response = client.GetAsync("api/ToDoes").Result;
           
        }

        //Test method for ensure Response Status code is OK.
        [Test]
        public void GetResponseIsSuccess()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        //Test method for ensure output results in Json format.
        [Test]
        public void GetResponseIsJson()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);

        }
      
    }
}
