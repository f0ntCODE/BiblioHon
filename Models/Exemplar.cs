using System;

namespace LibraryDesktopSystem.Models;

public class Exemplar
{

    private long? _id {get; set;}
    private long? _bookId {get; set;}
    private string _convervationStatus {get; set;} = String.Empty;
    private string _disponibility {get; set;} = String.Empty;
    private DateOnly _cadastrationDate {get; set;}


}
