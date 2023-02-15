using System.Net;

namespace api_calls.Models
{
    public class WorkToDo
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

        List<WorkToDo> workList = new List<WorkToDo>();

        public List<WorkToDo> GetWorkToBeDone()
        {
            string url = "https://jsonplaceholder.typicode.com/todos";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var make_call = client.GetAsync(url).Result;

            if (make_call.IsSuccessStatusCode)
            {
                var data = make_call.Content.ReadAsAsync<List<WorkToDo>>();
                data.Wait();
                workList = data.Result;
                return workList;
            }
            else
            {
                throw new Exception("Something went wrong, please contact admin");
            }


        }
    }
}





