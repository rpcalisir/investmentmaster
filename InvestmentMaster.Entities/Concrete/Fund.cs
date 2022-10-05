﻿using InvestmentMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.Entities.Concrete
{
    public class Fund: IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FONKODU { get; set; }
        public string? FONUNVAN { get; set; }
        public string? FONTURACIKLAMA { get; set; }
        public double? GETIRI1A { get; set; }
        public double? GETIRI3A { get; set; }
        public double? GETIRI6A { get; set; }
        public double? GETIRI1Y { get; set; }
        public double? GETIRIYB { get; set; }
        public double? GETIRI3Y { get; set; }
        public double? GETIRI5Y { get; set; }
    }
}
