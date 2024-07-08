using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Web;

namespace BlazorServer.Data.Helpers
{
    public class CookiesManager
    {
        private readonly IJSRuntime _jsRuntime;

        public CookiesManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public async Task SetCookie<T>(T obj,string key)
        {
            await DeleteCookie(key);
            var json = JsonConvert.SerializeObject(obj);
            await _jsRuntime.InvokeVoidAsync("cookieFunctions.setCookie", key , json, 7);
        }

        public async Task<T?> GetCookie<T>(string key)
        {
            var cookieValue = await _jsRuntime.InvokeAsync<string>("cookieFunctions.getCookie", key);
            if (cookieValue != null)
            {
                return JsonConvert.DeserializeObject<T>(cookieValue);
            }
            else
            {
                return default(T);
            }
        }

        public async Task DeleteCookie(string key)
        {
            await _jsRuntime.InvokeVoidAsync("cookieFunctions.deleteCookie", key);
            Console.WriteLine("Cookie deleted.");
        }
    }
}
