using projet1SoapWcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace projet1SoapWcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
       private VoitureDbContext db = new VoitureDbContext();
        public bool AjoutVoiture(Voiture v)
        {
            db.Voitures.Add(v);
            return db.SaveChanges() > 0;

        }

        public List<Voiture> GetVoitures()
        {
            return db.Voitures.ToList();
            
        }
    }
}
