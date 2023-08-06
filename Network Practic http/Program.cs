using System.Net;
using static System.Net.WebRequestMethods;


var listnr = new HttpListener();

listnr.Prefixes.Add(@"http://localhost:27001/");

listnr.Start();

Console.WriteLine("Listening...");

while (true)
{
    var context = listnr.GetContext();
    var rq = context.Request;
    var rp = context.Response;


    if (rq.HttpMethod == "POST")
    {
        StreamWriter streamWriter = new StreamWriter(rp.OutputStream);

        streamWriter.WriteLine($"<h1>salam {rq.QueryString["Name"]}</h1>");
        streamWriter.Close();
    }
    else if (rq.HttpMethod == "PUT")
    {
        StreamWriter streamWriter = new StreamWriter(rp.OutputStream);
    }
}




List<User> users = new List<User>
{
    new User { Id = 1, Name = "Nerbala", Surname = "Xaladennikov" },
    new User { Id = 2, Name = "name1", Surname = "surname1" }
};

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}