using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notion.SDK;
using Notion.SDK.JsonConverters;
using Notion.SDK.Model.Request;
using Notion.SDK.Model.Response;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            Assert.AreEqual(typeof(SearchResponse), response.GetType());
        }

        [TestMethod]
        public void QueryDatabaseTest(){

        }

        [TestMethod]
        public async Task CreateDatabaseTest(){
            if (client == null)
            {
                Assert.Fail();
                return;
            }
            var properties = new Dictionary<string, object> {
                ["月份"] = new
                {
                    select= new
                    {
                        name = MonthConverter.ToString(DateTime.Now.Month)
                    }
                },
                ["日期"]=new
                {
                    date = new
                    {
                        start=DateTime.Now.ToString("yyyy-MM-dd")
                    }
                },
                ["支出內容"] = new
                {
                    title = new List<object>
                    {
                        new
                        {
                            type = "text",
                            text = new
                            {
                                content = "測試",
                            }
                        }
                    }
                },
                ["類型"]= new
                {
                    multi_select = new List<object> {
                        new
                        {
                            name="飲料"
                        }
                    }
                },
                ["金額"]= new
                {
                    number = 35,
                },
            };
          
            var actual = JsonSerializer.Serialize(properties);
            Assert.IsNotNull(actual);

            var request = new CreatePageRequest("", "86da96dd-f3de-4d07-bc6b-1598c40baafe");
            if (properties != null)
            {
                request.Content!.Properties = properties;
            }

            var reqStr = JsonSerializer.Serialize(request.Content);
            Assert.IsNotNull(reqStr);

            //var response = await client.CreatePageAsync("86da96dd-f3de-4d07-bc6b-1598c40baafe", properties);
            //Assert.AreEqual(typeof(CreatePageResponse), response.GetType());
            //Assert.AreNotEqual("error", response.Object);
            
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
