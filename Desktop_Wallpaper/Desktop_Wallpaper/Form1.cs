using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Wallpaper
{
    public partial class Form1 : Form
    {
        int numClicks = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // SOURCES:
        // https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient


        static async Task<APOD> ProcessRepositoriesAsync(HttpClient client, string date)
        {
            string url = $"https://api.nasa.gov/planetary/apod?concept_tags=True&date={date}" +
                         $"&api_key=Ec8ixequm0WkHlnG8R8ylMsaxW6tyRFip0Ws7Cir";

            await using Stream stream = await client.GetStreamAsync(url);
            var apodObj = await JsonSerializer.DeserializeAsync<APOD>(stream);
            return apodObj ?? new("blank", "blank", "blank", new Uri("blank"));
        }


        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            DateTime today = DateTime.Now;
            string date = today.AddDays(-numClicks).ToString("yyyy-MM-dd");            

            var apod = await ProcessRepositoriesAsync(client, date);


            if(apod.MediaType != "image")
            {
                date = DateTime.Parse(date).AddDays(-numClicks-1).ToString("yyyy-MM-dd");
                apod = await ProcessRepositoriesAsync(client, date);
            }

            Wallpaper.Set(apod.Url, Wallpaper.Style.Stretched);

            numClicks++;
        }
    }
}
