using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoProject.Common
{
    public class HttpClientapi
    {
        /// <summary>
        /// HTTP get request to get the data
        /// </summary>
        /// <typeparam name="T">Object type to get</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>Returns generic object</returns>
        public T Get<T>(string url)
        {
            Type type = typeof(T);

            using (var handler = new HttpClientHandler())
            {
                //if (selfSignedCertificate)
                //    handler.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient httpClient =  new HttpClient(handler))
                {
                    //
                    url = "http://localhost:55192/"+url;
                    Uri apiUri = new Uri(url);

                    HttpResponseMessage response = httpClient.GetAsync(apiUri).Result;

                    // If get request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        ////throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    // If generic type is string, it returns string otherwise object
                    //return type != typeof(string) ? response.Content.ReadAsAsync<T>().Result : (T)Convert.ChangeType(response.Content.ReadAsStringAsync().Result, typeof(T), CultureInfo.CurrentCulture);
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(responseData);

                }
            }
        }
        

        /// <summary>
        /// HTTP asynchronous get request to get the data
        /// </summary>
        /// <typeparam name="T">Object type to get</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>Returns generic object</returns>0
        public async Task<T> GetAsync<T>(string url)
        {
            Type type = typeof(T);
            using (var handler = new HttpClientHandler())
            {
              
                using (HttpClient httpClient = new HttpClient(handler))
                {
                   
                    Uri apiUri = new Uri(url);

                    HttpResponseMessage response = await httpClient.GetAsync(apiUri);

                    // If get request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    // If generic type is string, it returns string otherwise object
                    return type != typeof(string) ? response.Content.ReadAsAsync<T>().Result : (T)Convert.ChangeType(response.Content.ReadAsStringAsync().Result, typeof(T));
                }
            }
        }

        /// <summary>
        /// HTTP post request to add the data
        /// </summary>
        /// <typeparam name="T">Object type to add</typeparam>
        /// <param name="url">Request URL</param>
        /// <param name="model">Model to add</param>
        /// <returns>Returns generic object</returns>
        public T Post<T>(string url, T model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                   
                    Uri apiUri = new Uri(url);
                    HttpResponseMessage response = httpClient.PostAsJsonAsync(apiUri, model).Result;

                    // If post request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http asynchronous post request to add the data
        /// </summary>
        /// <typeparam name="T">Object type to add</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="model">Model to add</param>
        /// <returns>Returns generic object</returns>
        public async Task<T> PostAsync<T>(string url, T model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                   
                    Uri apiUri = new Uri(url);
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUri, model);

                    // If post request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http post request to add the data
        /// </summary>
        /// <typeparam name="T">Object type to add</typeparam>
        /// <typeparam name="TData">Object type Post</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="model">Model to add</param>        
        /// <returns>Returns generic object</returns>
        public T Post<T, TData>(string url, TData model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                   
                    Uri apiUri = new Uri(url);
                    HttpResponseMessage response = httpClient.PostAsJsonAsync(apiUri, model).Result;

                    // If post request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http asynchronous post request to add the data
        /// </summary>
        /// <typeparam name="T">Object type to add</typeparam>
        /// <typeparam name="TData">Object type Post</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="model">Model to add</param>
        /// <returns>Returns generic object</returns>
        public async Task<T> PostAsync<T, TData>(string url, TData model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(url);
                   
                    HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUri, model);

                    // If post request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http asynchronous post request to add the data
        /// </summary>        
        /// <typeparam name="T">Object type Post</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="model">Model to add</param>
        /// <returns>Returns generic object</returns>
        public byte[] PostAsyncStream<T>(string url, T model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(url);
                   
                    HttpResponseMessage response = httpClient.PostAsJsonAsync(apiUri, model).Result;

                    // If post request is not success
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsByteArrayAsync().Result;
                }
            }
        }

        /// <summary>
        /// Http put request to update the data
        /// </summary>
        /// <typeparam name="T">Object type to update</typeparam>
        /// <param name="resource">Request url</param>
        /// <param name="model">Model to update</param>
        /// <returns>Returns generic object</returns>
        public T Put<T>(string resource, T model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(resource);
                   
                    HttpResponseMessage response = httpClient.PutAsJsonAsync(apiUri, model).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http asynchronous put request to update the data
        /// </summary>
        /// <typeparam name="T">Objects to update data</typeparam>
        /// <param name="url">Request url</param>
        /// <param name="model">Model to update</param>
        /// <returns>Returns generic object</returns>
        public async Task<T> PutAsync<T>(string url, T model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(url);
                   
                    HttpResponseMessage response = await httpClient.PutAsJsonAsync(apiUri, model);

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }


        /// <summary>
        /// Http put request to update the data
        /// </summary>
        /// <typeparam name="T">Object type to update</typeparam>
        /// /// <typeparam name="TData">Object type put</typeparam>
        /// <param name="resource">Request url</param>
        /// <param name="model">Model to update</param>
        /// <returns>Returns generic object</returns>
        public T Put<T, TData>(string resource, TData model)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(resource);
                   
                    HttpResponseMessage response = httpClient.PutAsJsonAsync(apiUri, model).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// Http delete request to delete data
        /// </summary>
        /// <typeparam name="T">Object type to delete</typeparam>
        /// <param name="url">Request url</param>
        /// <returns>Returns generic object</returns>
        public T Delete<T>(string url)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(url);
                   
                    HttpResponseMessage response = httpClient.DeleteAsync(apiUri).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        /// <summary>
        /// HTTP asynchronous delete request to delete data
        /// </summary>
        /// <typeparam name="T">Object type to delete</typeparam>
        /// <param name="url">Request URL</param>
        /// <returns>Returns generic object</returns>
        public async Task<T> DeleteAsync<T>(string url)
        {
            using (var handler = new HttpClientHandler())
            {

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    Uri apiUri = new Uri(url);
                   
                    HttpResponseMessage response = await httpClient.DeleteAsync(apiUri);

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //throw new HttpException((int)response.StatusCode, responseBody);
                    }

                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

    }
}
