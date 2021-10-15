using projet2AspDont.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace projet2AspDont.Controllers
{
    public class VoitureController : ApiController
    {
        private VoitureDBContext db = new VoitureDBContext();

        [HttpPost]
        public HttpStatusCode AjoutVoiture(Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Voiture.Add(voiture);
            }
        }
    }
}
