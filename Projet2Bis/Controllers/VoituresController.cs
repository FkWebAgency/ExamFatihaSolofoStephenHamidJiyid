using Projet2Bis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet2Bis.Controllers
{
    public class VoituresController : ApiController
    {
        private VoitureDbContext db = new VoitureDbContext();

        [HttpPost]
        public HttpStatusCode AjoutVoiture(Voiture voiture)
        {
            // On fait l'ajout uniquement si l'état du model est valide (ModeState)
            // Si l'ensemble des contraintes (annotation sont répétéés

            if (ModelState.IsValid)
            {
                db.Voitures.Add(voiture);
                int i = db.SaveChanges();

                if (i > 0)
                {
                    return HttpStatusCode.OK;
                }
                return HttpStatusCode.InternalServerError;
            }
            return HttpStatusCode.BadRequest;
        }


        //supression
        [HttpDelete]
        [Route("voiture/supp/{id}")]

        public HttpStatusCode SuppVoiture(int id)
        {
            try
            {
                Voiture SuppVoiture = db.Voitures.FirstOrDefault(x => x.Id == id);
                // 2ème méthode :
                //Stagiaire stagiaireASupp = db.Stagiaires.Find(id);

                if (SuppVoiture == null) return HttpStatusCode.NotFound;
                db.Voitures.Remove(SuppVoiture);

                db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {

                return HttpStatusCode.InternalServerError;
            }

;
        }


        // Modification
        [HttpPut]
        [Route("voiture/modif")]

        public HttpStatusCode VoitureAModif(Voiture voiture)
        {
            try
            {
                Voiture VoitureAModif = db.Voitures.FirstOrDefault(x => x.Id == voiture.Id);
                if (VoitureAModif == null) return HttpStatusCode.NotFound;
                VoitureAModif.Marque = voiture.Marque;
                VoitureAModif.Model = voiture.Model;
                VoitureAModif.Annee = voiture.Annee;

                db.SaveChanges();
                return HttpStatusCode.OK;

            }
            catch (Exception)
            {

                return HttpStatusCode.InternalServerError;
            }
        }

    }


}
