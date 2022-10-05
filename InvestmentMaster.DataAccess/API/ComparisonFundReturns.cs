using InvestmentMaster.DataAccess.Helper;
using InvestmentMaster.Entities.Concrete;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.API
{
    public static class ComparisonFundReturns
    {
        private static FundsReturnResponse FundsList { get; set; }
        private static string response;

        static ComparisonFundReturns()
        {
            response = GetComparisonFundReturnsResponse();
            Console.WriteLine(response);
        }

        #region Public Methods
        public static List<Fund> GetFunds()
        {
            bool isResponseValid = ValidateJSON(response);

            if (isResponseValid)
            {
                FundsList = JToken.Parse(response).ToObject<FundsReturnResponse>();
                return FundsList.Data;
            }
            else
            {
                return new List<Fund>();
            }
        }

        #endregion

        #region Private Implementation
        private static string GetComparisonFundReturnsResponse()
        {
            string baslangicTarihi = LatestWeekDayHelper.GetLatestWeekDay();
            string bitisTarihi = LatestWeekDayHelper.GetLatestWeekDay();

            var client = new RestClient("https://www.tefas.gov.tr/api/DB/BindComparisonFundReturns");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Cookie", "_ga=GA1.3.2057127171.1659714538; ASP.NET_SessionId=0ryt5qocb05vxmpwfaefwj2l; _gid=GA1.3.1858337542.1659956086; TS01ec1a88=019fc7fc4d541b8b9958f7091b21813bc7b195045fb43b0ce9179f1f069ad495cd30a3fc81eb796ec11e026a8e08c671fc87cf3109de5d85cf69c20cd0c55a717d1e5338ed2956afbbdb15d9e6a25e1c85ecddf8ec951c75cab3efe82f1de7be73516c9f2c508afcd84976729a6a84527975c2e3df; TSb7d61442027=08ce165641ab2000c670384b879d1fdbc94614738feca4b844f5fbbf06bfe0ca86c8d42e575507f208884c42591130005d76197d2d4f31040e058744a79e8da5f530679b5a24755c4bb7cf690d03bb574c91d9dede5cda0d7b62c4912ebe4ef8");
            request.AddHeader("Origin", "https://www.tefas.gov.tr");
            request.AddHeader("Referer", "https://www.tefas.gov.tr/FonKarsilastirma.aspx");
            request.AddHeader("Sec-Fetch-Dest", "empty");
            request.AddHeader("Sec-Fetch-Mode", "cors");
            request.AddHeader("Sec-Fetch-Site", "same-origin");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"104\", \" Not A;Brand\";v=\"99\", \"Google Chrome\";v=\"104\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddCookie("TSb7d61442027", "08ce165641ab20003772f48c5e583e1a26f6048f40aa183c4369987301cd1e526d1418bd9b43cd95089394c23d11300010971c4fd05a5b804391204c37cb98976485ce549bf19fe11455b88c0aeeb552cd1a90e1a3454f535ce079723cff35ac");
            request.AddCookie("TS01ec1a88", "019fc7fc4d0af1b7a081b05321ed363f568aad65040856507943f7227d61893a1d3324bcd96d0e87c0be11bf5d1e5df1788dafffefb26eff3f71f0ee38713d8d7c92c881626a78a42b1b2c2db05215af873f3460b1909d9619dc62656d0cef45698a2d132f236268fa7b618048fceb48f4999d5e1a");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", $"calismatipi=2&fontip=YAT&sfontur=&kurucukod=&fongrup=&bastarih={baslangicTarihi}&bittarih={bitisTarihi}&fonturkod=&fonunvantip=&strperiod=1%2C1%2C1%2C1%2C1%2C1%2C1&islemdurum=1", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        private static bool ValidateJSON(this string str)
        {
            if ((str.StartsWith("{") && str.EndsWith("}")) || //For object
                (str.StartsWith("[") && str.EndsWith("]"))) //For array
            {
                try
                {
                    JToken.Parse(str).ToObject<FundsReturnResponse>();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO Instead of Console.WriteLine, implement Logging
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
