 public abstract class LibraryUser
{
     public int Id { get ;set ;}
     public string Name {get ; set;}

     public string Email {get ; set ; } 

 public abstract  string GetUserType();


}