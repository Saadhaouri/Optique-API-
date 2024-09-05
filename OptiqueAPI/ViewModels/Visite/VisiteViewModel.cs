namespace OptiqueAPI.ViewModels.Visite
{
    public class VisiteViewModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; } // Full name of the client
        public string Telephone { get; set; } // Client's phone number
        public DateTime DateVisite { get; set; }

        public string OD_Sphere { get; set; }
        public string OD_Cylinder { get; set; }
        public int? OD_Axis { get; set; }

        public string OS_Sphere { get; set; }
        public string OS_Cylinder { get; set; }
        public int? OS_Axis { get; set; }

        public decimal? Add { get; set; }
        public string PD { get; set; }

        public string VerreOD { get; set; }  // Verre for the right eye
        public string VerreOS { get; set; }  // Verre for the left eye

        public decimal PriceOD { get; set; }  // Price for the right eye
        public decimal PriceOS { get; set; }  // Price for the left eye

        public decimal Prixmonture { get; set; }
        public decimal Total { get; set; }
        public decimal Avance { get; set; }
        public decimal Reste { get; set; }
        public decimal? Remise { get; set; }

        public string? Doctor { get; set; }    // Name of the doctor
    }
}
