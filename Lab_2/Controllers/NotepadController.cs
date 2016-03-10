using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Lab_2.Controllers
{
    public class NotepadController : ApiController
    {
        [HttpGet]
        public IEnumerable<dynamic> GetNotepads()
        {
            return LocalData.Notepads.Select(notepad => new { notepadName = notepad.Name });
        }

        [HttpGet]
        public string GetNotepadContent(string name)
        {
            return LocalData.GetContent(name);
        }

        [HttpPost]
        public void Create(JObject data)
        {
            var name = data.GetValue("NotepadName").ToString();

            if (!LocalData.AddNotepad(name))
            {
                // TODO: Что то сделать
            }
        }

        [HttpPost]
        public void Update(JObject data)
        {
            var name = data.GetValue("NotepadName").ToString();
            var content = data.GetValue("Content").ToString();

            if (!LocalData.UpdateContent(name, content))
            {
                // TODO: Что то сделать
            }
        }
    }
}
