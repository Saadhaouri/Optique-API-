namespace Optique_Domaine.Entities;

public class Visite
{
    public Guid Id { get; set; }

    public string Fullname  { get; set; }
    

    public string Telephone { get; set; }
    public DateTime DateVisite { get; set; }

    public string OD_Sphere { get; set; }
    public string OD_Cylinder { get; set; }
    public int? OD_Axis { get; set; }

    public string OS_Sphere { get; set; }
    public string OS_Cylinder { get; set; }
    public int? OS_Axis { get; set; }

    public decimal? Add { get; set; }
    public string PD { get; set; }

    public string VerreOD { get; set; }    
    public string VerreOS { get; set; }   

    public decimal PriceOD { get; set; }   
    public decimal PriceOS { get; set; }

    public decimal Prixmonture { get; set; }
    public decimal Total { get; set; }
    public decimal Avance { get; set; }
    public decimal Reste { get; set; }
    public decimal? Remise { get; set; }

    public string? Doctor { get; set; }    // Name of the
                                           
}
