﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class Address
{
    public int Id { get; set; }

    public string Street1 { get; set; }

    public string Street2 { get; set; }

    public string City { get; set; }

    public int StateId { get; set; }

    public int CountryId { get; set; }

    public int PostalCode { get; set; }

    public int AddressTypeId { get; set; }

    public virtual AddressType AddressType { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual State State { get; set; }
}