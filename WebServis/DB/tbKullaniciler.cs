namespace WebServis.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbKullaniciler")]
    public partial class tbKullaniciler
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Kullanici_Ad { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }
    }
}
