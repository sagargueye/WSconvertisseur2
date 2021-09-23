using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSconvertisseur2.Models
{
   
    public class Devise : IEquatable<Devise>
    {
        public int Id { get; set; }
        [Required]
        public String Nom { get; set; }
        public Double Taux { get; set; }

        public Devise()
        { }

        public Devise(int id, string nom, double taux)
        {
            Id = id;
            Nom = nom;
            Taux = taux;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Devise);
        }

        public bool Equals(Devise other)
        {
            return other != null &&
                   Id == other.Id &&
                   Nom == other.Nom &&
                   Taux == other.Taux;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nom, Taux);
        }

        public static bool operator ==(Devise left, Devise right)
        {
            return EqualityComparer<Devise>.Default.Equals(left, right);
        }

        public static bool operator !=(Devise left, Devise right)
        {
            return !(left == right);
        }
    }
}
