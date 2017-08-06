using System;
using System.Collections.Generic;
using RestSharp;

namespace UZticketsChecker
{
    public class RestApiClient
    {
        private List<String> parametersLines;

        public RestApiClient()
        {
            parametersLines = FileReader.GetParamtersList();
        }

        public IRestResponse GetResponse()
        {
            var client = new RestClient("http://booking.uz.gov.ua/en/purchase/search/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "b5735b4d-5d96-d2bc-517c-0b5e3fb23a83");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("cookie", "HTTPSERVERID=server1; _gv_sessid=ap3jdpk28cq2hs3mqpsfik8i40; _gat=1; _gv_lang=en; _ga=GA1.3.223974033.1501782744; _gid=GA1.3.1173519979.1501782744");
            request.AddHeader("accept-language", "en-US,en;q=0.8");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("referer", "http://booking.uz.gov.ua/en/");
            request.AddHeader("accept", "*/*");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("gv-referer", "http://booking.uz.gov.ua/en/");
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36");
            request.AddHeader("gv-screen", "1366x768");
            request.AddHeader("gv-ajax", "1");
            request.AddHeader("origin", "http://booking.uz.gov.ua");

            foreach (var parameterLine in parametersLines)
            {
                string[] parametersItems = parameterLine.Split(':');
                request.AddParameter(parametersItems[0], parametersItems[1]);


                Console.WriteLine("|" + parametersItems[0] + "|" + parametersItems[1] + "|");
               
            }



            //
        //            request.AddParameter("another_ec", "0");
        //            request.AddParameter("date_dep", "08.27.2017");
        //            request.AddParameter("search", "");
        //            request.AddParameter("station_from", "Odesa");
        //            request.AddParameter("station_id_from", "2208001");
        //            request.AddParameter("station_id_till", "2204001");
        //            request.AddParameter("station_till", "Kharkiv");
        //            request.AddParameter("time_dep", "00:00");
        //            request.AddParameter("time_dep_till", "");
        //

            return client.Execute(request);
        }
    }
}