using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Dto
{
    public class FournisseurDTO
    {
        public Guid Id { get; set; }
        public required string Nom { get; set; }
        public  required string Adresse { get; set; }
        public required string Telephone { get; set; }

    }
}
