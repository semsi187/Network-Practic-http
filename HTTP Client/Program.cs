using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net;
using System.Text;
using System;

using(var client = new HttpClient())
{
    string link = "http://ocalhost:27001/";
    string mesg = "POST";

    var content = new StringContent(mesg, Encoding.UTF8, "text/plain");
    var response = await client.PostAsync(link, content);


    if (response.IsSuccessStatusCode)
    {
        string responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
    else
    {
        Console.WriteLine("error");
    }

}



class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

