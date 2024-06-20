using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiKey = "aa5a32a2477b66cfcab494204d91e508";
        string city = "Moscow"; // Город, для которого нужно получить погоду

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("Ошибка при получении данных. Код ошибки: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
