
public class Librarian  : LibraryUser
{
     public string EmployeeNumber {get; set ;}
    

      public  Librarian ( int Id,  string Name ,string Email ,string EmployeeNumber)
    {
         this.Id = Id ; 

         this.Name = Name ;

         this.Email = Email;

          this.EmployeeNumber = EmployeeNumber;

    }


    public override string GetUserType()
    {                             // correct with "  " 
        return "  Librarian  " ; // return Librarian; اسم كلاس عادي هيك غلط
    }

public override  string ToString()
    {
     return $"ID : {Id} | Name : {Name} | Email :{Email} | Type :{GetUserType()} | EmployeeNumber :{EmployeeNumber}" ;

    } 

}