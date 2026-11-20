using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BiblioHon.Models;

public class Copy
{

    public long? Id {get; set;}
    public string ConvervationStatus {get; set;} = String.Empty;
    public string Disponibility {get; set;} = String.Empty;
    public DateOnly CadastrationDate {get; set;}

    //relationship
    public long? BookId {get; set;}
    public Book Book {get; set;}

    public Copy(long? id,
                    string convervationStatus,
                    string disponibility,
                    DateOnly cadastrationDate)
    {
        this.Id = id;
        this.ConvervationStatus = convervationStatus;
        this.Disponibility = disponibility;
        this.CadastrationDate = cadastrationDate;
    }


}
