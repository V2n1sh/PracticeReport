//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace knightApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tournaments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tournaments()
        {
            this.AthletesInTheTournaments = new HashSet<AthletesInTheTournaments>();
            this.AthletesInTheTournaments1 = new HashSet<AthletesInTheTournaments>();
            this.Teams = new HashSet<Teams>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> street_id { get; set; }
        public Nullable<int> city_id { get; set; }
        public Nullable<System.DateTime> tournament_start { get; set; }
        public Nullable<System.DateTime> tournament_end { get; set; }
        public Nullable<int> sort_of_sport_od { get; set; }
        public int home_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AthletesInTheTournaments> AthletesInTheTournaments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AthletesInTheTournaments> AthletesInTheTournaments1 { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual SortsOfSports SortsOfSports { get; set; }
        public virtual Streets Streets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
