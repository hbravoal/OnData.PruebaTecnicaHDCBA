﻿//using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnData.PruebaTecnicaHDCBA.Models
{
    public class containers_categories
    {
        [Key]
        public int id { get; set; }


        public int category_id { get; set; }
        //public virtual categories category { get; set; }
        public int container_id { get; set; }
        //public virtual containers container { get; set; }


    }
 
}