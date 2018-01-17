namespace Dot.Library.Database

{

 public class Address
 {
     public int Id { get; set; }
     public string Country { get; set; }
     public string City { get; set; }
     public string ZipCode {get; set;}
     public string Province {get; set;}
     public string Street {get; set;} 
     public int HouseNumber {get; set;}
     public int ApartmentNumber {get; set;}      
 }
}