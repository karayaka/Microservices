using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Microservice.Order.Domain.Enums
{
	public enum Status
	{
        [Display(Name = "Aktif")]
        Active = 1,

        [Display(Name = "Pasif")]
        Pasive = 0,
    }
}

