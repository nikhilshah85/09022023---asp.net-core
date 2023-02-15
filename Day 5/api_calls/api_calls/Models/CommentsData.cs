namespace api_calls.Models
{
    public class CommentsData
    {
        public int id { get; set; }
        public int postId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

        List<CommentsData> commentList = new List<CommentsData>();

        public  List<CommentsData> GetComments()
        {
            string url = "https://jsonplaceholder.typicode.com/comments";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear(); //clear the default format of calling environment
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var make_call = client.GetAsync(url).Result; // make a call

            //check if call is getting successful, before reading the data

            if (make_call.IsSuccessStatusCode)
            {
                var data = make_call.Content.ReadAsAsync<List<CommentsData>>();
                data.Wait();
                commentList = data.Result;
                return commentList;
            }
            else
            {
                throw new Exception("Something went wrong, please contact admin");
            }

            
        }
    }
}






