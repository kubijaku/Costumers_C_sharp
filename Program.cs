using System.Security.Cryptography;
// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;


List<Costumer> costumers_list = new List<Costumer>();

Costumer cost1 = new Costumer("Ala", 123, DateTime.Now, "Warsaw","Krotka", "32-342", 1, 5);
Costumer cost2 = new Costumer("Karol", 123, DateTime.Now, "Warsaw","Warszawska", "32-342", 1);

try
{
    Costumer cost3 = new Costumer("Stefan", 123, DateTime.Now, "Warsaw","Jakas", "3233-323", 1, 5); //on purpose incorrect postcode - program throw exception
    costumers_list.Add(cost3);
}
catch(Exception e)
{
    Console.WriteLine(e);
}


Address ad1 = new Address("Krakow","Wielopole", "31-072", 1);
Costumer cost4 = new Costumer("Esatto", 123, DateTime.Now, ad1);

costumers_list.Add(cost1);
costumers_list.Add(cost2);
costumers_list.Add(cost4);

foreach( var cost in costumers_list)
{
    Console.WriteLine("That's our Costumer: " + cost.ToString());
}


class Costumer{
    public String name;
    public int vat_id_number;
    public DateTime creation_date;
    public Address address;

    // Constructor with all neccessary parameters 
    public Costumer(String name, int vat_id_number, DateTime creation_date, String city,String street, String postcode, int build_number, int flat_number){
        this.name = name;
        this.vat_id_number = vat_id_number;
        this.creation_date = creation_date;
        Address ad1 = new Address(city, street, postcode, build_number, flat_number);
        this.address = ad1;
    }

    // Constructor without 'flat_number' parameter
    public Costumer(String name, int vat_id_number, DateTime creation_date, String city,String street, String postcode, int build_number){
        this.name = name;
        this.vat_id_number = vat_id_number;
        this.creation_date = creation_date;
        Address ad1 = new Address(city, street, postcode, build_number);
        this.address = ad1;
    }

    // Constructor with the given 'address' instance of class Address
    public Costumer(String name, int vat_id_number, DateTime creation_date, Address address){
        this.name = name;
        this.vat_id_number = vat_id_number;
        this.creation_date = creation_date;
        this.address = address;
    }

    override public String ToString()
    {
        return this.name + " " + this.vat_id_number + " " + this.creation_date.ToString() + " " + this.address.ToString();
    } 

}

class Address{
    public String city;
    public String street;
    public String postcode;
    public int build_number;
    public int? flat_number = null;

    // Constructor with all parameters
    public Address(String city, String street,  String postcode, int build_number, int flat_number)
    {
        this.city = city;
        this.street = street;

        string pattern = @"^[0-9]{2}-[0-9]{3}$";
        if(Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase) )
        {
            this.postcode = postcode;   
        }
        else
        {
            throw new Exception( "Incorrect postcode");
        }
        
        
        this.build_number = build_number;
        this.flat_number = flat_number;
    }

    // Constructor without 'flat_number' parameter
    public Address(String city, String street, String postcode, int build_number)
    {
        this.city = city;
        this.street = street;

        string pattern = @"^[0-9]{2}-[0-9]{3}$";
        if(Regex.IsMatch(postcode, pattern, RegexOptions.IgnoreCase) )
        {
            this.postcode = postcode;   
        }
        else
        {
            throw new Exception( "Incorrect postcode");
        }

        this.build_number = build_number;
    }

    public override string ToString()
    {
        return this.city + " " + this.street + " " + this.postcode + " " + build_number.ToString() + " " + flat_number.ToString();
    }

}