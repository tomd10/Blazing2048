using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Text;

namespace Blazing2048
{
    public static class AuxMethods
    {
        public static List<int> RemoveZeroes(List<int> list)
        {
            list.RemoveAll(x => x == 0);
            return list;
        }

        public async static Task<string> Upload(IBrowserFile f)
        {
            if (f != null && f.Size > 0)
            {
                Stream s = f.OpenReadStream();
                StreamReader sr = new StreamReader(s);

                string ret = await sr.ReadToEndAsync();
                sr.Close();
                s.Close();

                return ret;
            }
            return null;
        }

        public static async void Download(IJSRuntime JS, string filename, string content)
        {
            MemoryStream fs = new MemoryStream(Encoding.UTF8.GetBytes(content));
            using var streamRef = new DotNetStreamReference(fs);

            await JS.InvokeVoidAsync("downloadFileFromStream", filename, streamRef);
        }

        public static void StoreString(IJSRuntime JS, string key, string text)
        {
            JS.InvokeVoidAsync("localStorage.setItem", key, text);
        }

        public static async Task<string> LoadString(IJSRuntime JS, string key)
        {
            return await JS.InvokeAsync<string>("localStorage.getItem", key);

        }
    }
}
