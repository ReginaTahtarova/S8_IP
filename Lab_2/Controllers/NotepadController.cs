using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Lab_2.Controllers
{
    public class NotepadController : ApiController
    {
        [HttpPost]
        public void Create(JObject data)
        {
            var name = data.GetValue("NotepadName").ToString();

            if (!LocalData.AddFile(name))
            {
                // TODO: Что то сделать
            }
        }
    }
}
