// See https://aka.ms/new-console-template for more information
using System.Text.Json;

class Info
{
    public int id { get; set; }
    public string? description { get; set; }
    public string? category { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Info> jsondata = new List<Info>();

        using (StreamReader r = new StreamReader("data.json"))
        {
            string json = r.ReadToEnd();
            jsondata = JsonSerializer.Deserialize<List<Info>>(json)!;
        }

        Dictionary<string, List<Info>> categoryList = new Dictionary<string, List<Info>>();

        foreach (Info element in jsondata)
        {
            if (element.category != null)
            {
                List<Info> temp = new List<Info>();
                if (categoryList.ContainsKey(element.category))
                {
                    temp = categoryList[element.category];
                    temp.Add(element);
                    categoryList[element.category] = temp;
                }
                else
                {
                    temp.Add(element);
                    categoryList.Add(element.category, temp);
                }
            }
        }

        Console.WriteLine("Distinct Categories:");

        foreach (KeyValuePair<string, List<Info>> result in categoryList)
        {
            Console.WriteLine(result.Key);
        }
    }
}