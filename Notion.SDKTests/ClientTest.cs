using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notion.SDK;
using Notion.SDK.Model.Request;
using Notion.SDK.Model.Response;

namespace Notion.SDKTests
{
    [TestClass]
    public class ClientTest
    {
        private NotionClient? client;

        [TestInitialize]
        public void Init()
        {
            var token = "secret_SUSksrN3RXQGqyycqXqkMoyUKNb53HDnPHcFsDtsd7v";
            client = new NotionClient(token);
        }


        [TestMethod]
        public async Task AuthorizationCodeTest()
        {
            try
            {
                var auth = await new NotionClient("CLIENT_ID", "CLIENT_SECRET").AuthorizationCodeAsync("e202e8c9-0990-40af-855f-ff8f872b1ec6", "https://example.com/auth/notion/callback");
                Assert.IsNotNull(auth);
            }catch(Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public async Task SearchTest()
        {
            if (client == null)
            {
               Assert.Fail();
                return;
            }

            var request = new SearchContent() 
            {
                PageSize = 10
            };
            var response =await client.SearchAsync(request);
            Assert.AreEqual(typeof(SearchResponse), response?.GetType());
        }

        [TestMethod]
        public void QueryDatabaseTest(){

        }

       


        [TestMethod]
        public void CreateDatabaseTest(){

        }


        [TestMethod]
        public void UpdateDatabaseTest(){

        }


        [TestMethod]
        public void RetrieveDatabaseTest(){

        }

        


        [TestMethod]
        public void RetrievePageTest(){

        }


        [TestMethod]
        public void CreatePageTest(){

        }

        [TestMethod]
        public void UpdatePageTest(){

        }

        [TestMethod]
        public void RetrieveBlockTest(){

        }



        [TestMethod]
        public void UpdateBlockChildrenTest(){

        }


        [TestMethod]
        public void AppendBlockChildrenTest(){

        }


        [TestMethod]
        public void RetrieveUserTest(){

        }


        [TestMethod]
        public void ListAllUserTest(){

        }

    }
}
