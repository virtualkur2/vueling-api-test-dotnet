using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

public class Data : IData
{
  private readonly IHostingEnvironment _hostingEnvironment;
  private string fileName = "datos.json";
  private string data = "";


  // public Data(IHostingEnvironment hostingEnvironment)
  // {
  //   _hostingEnvironment = hostingEnvironment;
  // }

  public string Persist
  {
    get
    {
      // string appRoot = AppContext.BaseDirectory.Substring(0,AppContext.BaseDirectory.LastIndexOf("/bin"));
      // appRoot = appRoot.Substring(0,appRoot.LastIndexOf("/")+1);
      string contentRootPath = _hostingEnvironment.ContentRootPath;
      
      Task<string> persistedData = readFile(fileName);
      return persistedData.Result;
    }
    set
    {
      data = value;
      Task<bool> isPersisted = writeFile(fileName, data);
      if(isPersisted.Result)
      {
        Console.WriteLine("Data has been persisted succesfully");
      } else {
        Console.WriteLine("Data hasn't been persisted");
      }
    }
  }

  static async Task<bool> writeFile(string fileName, string data)
  {
    using (StreamWriter writer = new StreamWriter(fileName, false))
    {
      try
      {
        await writer.WriteLineAsync(data);
        writer.Close();
        return true;
      }
      catch (IOException exception)
      {
        Console.WriteLine(
        "{0}: The write operation could not " +
        "be performed." +
        "\n" +
        "Message: {1}",
        exception.GetType().Name,
        exception.Message);
        return false;
      }
    }

  }

  private async Task<string> readFile(string fileName)
  {
    using (StreamReader reader = new StreamReader(fileName))
    {
      try
      {
        string data = await reader.ReadLineAsync();
        reader.Close();
        return data;
      }
      catch (IOException exception)
      {
        Console.WriteLine(
        "{0}: The read operation could not " +
        "be performed." +
        "\n" +
        "Message: {1}",
        exception.GetType().Name,
        exception.Message);
        return null;
      }
    }
  }
}
