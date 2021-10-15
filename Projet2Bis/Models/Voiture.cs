using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet2Bis.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Model { get; set; }
        public int Annee { get; set; }
    }
}