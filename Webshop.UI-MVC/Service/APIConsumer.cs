using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC
{
    internal static class APIConsumer<T> where T : class
    {
        internal static IEnumerable<T> GetAPI(string path)
        {
            IEnumerable<T> objects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = client.GetAsync(path);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    objects = JSserializer.Deserialize<IEnumerable<T>>(readJob.Result);
                }

                return objects;
            }
        }

        internal static T GetObject(string path, string id)
        {
            T objects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                var responseTask = client.GetAsync(path + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    objects = JSserializer.Deserialize<T>(readJob.Result);
                }

                return objects;
            }
        }

        internal static void AddObject(string path, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");

                var postTask = client.PostAsJsonAsync<T>(path, t);
                postTask.Wait();
            }
        }

        internal static void EditObject(string path, string id, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");

                var putTask = client.PutAsJsonAsync<T>(path, t);
                putTask.Wait();
            }
        }

        internal static void DeleteObject(string path, string id, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/api/");
                string url = client.BaseAddress + path + "/" + id;
                var deleteTask = client.DeleteAsync(url);
                deleteTask.Wait();
            }
        }
    }
}