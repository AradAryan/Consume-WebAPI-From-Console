using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using System.IO;

namespace Consume_WebAPI_From_Console
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static HttpContent content;

        public static void Get()
        {
            var message = client.GetStringAsync("get");
            Console.WriteLine(message.Result);
        }
        public static void Get(string word)
        {
            var message = client.GetStringAsync($"get?value={word}");
            Console.WriteLine(message.Result);
        }
        public static void Post(string word, string meaning)
        {
            var message = client.PostAsync($"post?inputWord={word}&meaning={meaning}", content);
        }
        public static void Put(string inputWord, string meaning, string value)
        {
            var message = client.PutAsync($"put?inputWord={inputWord}&meaning={meaning}&value={value}", content);
        }
        public static void Delete(string inputWord)
        {
            var message = client.DeleteAsync($"delete?inputWord={inputWord}");
        }
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:51158/api/values/");

            Get();
            Post("اقتدار", "بزرگی");
            Get("اقتدار");
            Put("Arad", " is ok", "آراد");
            Get("Arad");
            Delete("Arad");
            Get("Arad");

            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}
