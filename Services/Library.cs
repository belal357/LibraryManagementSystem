/* AddBook() ✅
AddUser() ✅
FindUser(int id) ✅
GetAvailableBooks() ✅
GetBorrowedBooks() ✅
DisplayUsers() ✅
FindBook(int id) ✅
FindBook(string title) ✅
Encapsulation باستخدام _books و_users + IReadOnlyList ✅
Polymorphism في DisplayUsers() ✅
Method Overloading في FindBook() ✅   */









/*    Books.Any(...)
  Users.Any(...) for  */

using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
            
public class Library
{
   // public List<Book> Books { get; set; }
   // the proplem is that set ; can make  object  like>>   library.Books = new List<Book>();
       //  Set can do also library.Books.Clear();  OR library.Books.Add(book);
      // public List<LibraryUser> Users { get; set; }
               
   // public Library()
    //{
     //   Books = new List<Book>();
     //   Users = new List<LibraryUser>();
    //}



private readonly List<Book> _books;
private readonly List<LibraryUser> _users;

// solve for privet & Encapsulation 
               // out can read only list  withot Add () Or Remove()
             public IReadOnlyList<Book> Books => _books;
              public IReadOnlyList<LibraryUser> Users => _users;
public Library()
{
    _books = new List<Book>();
    _users = new List<LibraryUser>();
}





    public bool AddBook(Book book)
    {          //Books  To _book 
        if (_books.Any(b => b.Id == book.Id))
        {
            return false;
        }

        _books.Add(book);
        return true;
    }

    public bool AddUser(LibraryUser user)
    {         //Users to _users
        if (_users.Any(u => u.Id == user.Id))
        {
            return false;
        }

        _users.Add(user);
        return true;
    }

             //       10   FindUser
      public LibraryUser? FindUser(int id)
{
    return _users.FirstOrDefault(u => u.Id == id);
}



        //       11    GetAvailable books
public List<Book> GetAvailableBooks()
{
    return _books.Where(b => b.IsAvailable).ToList();
}


           // 12. GetBorrowedBooks
public List<Book> GetBorrowedBooks()
{
    return _books.Where(b => !b.IsAvailable).ToList();
}



    // 13 display by foreach only ( withot if   else if) 
    
  // The method should loop through the LibraryUser collection and display each user's information.
// Use polymorphism.
 
         //    public List<LibraryUser> Users { get; set; }
             // فوق عشان هيك كتبتها 
            
//C# نفسها تختار الـ method المناسبة عن طريق الـ polymorphism
                                   //LibraryUser user عند 
                               

                                      //الـ polymorphism is foreach (LibraryUser user in Users)   //LibraryUser user

                                      //لأن Member و Librarian الاثنين يرثوا من LibraryUser.

        // foreach (Member member in Users)  Error we broke polymorphism ( Librarian.cs  لانه ضايل عناصر ال ) ما وصلتهلم وقتها 


                               

                                   //أتعامل مع Member و Librarian>>> كأنهم LibraryUser
                                   //GetUserType()>>> كل class ينفذ / بعمل  نسخته 
   public void DisplayUsers  ()  {      //نتعامل مع كل المستخدمين من خلال الأب LibraryUser. 
        foreach (LibraryUser user in _users)  //Users to _usres
        {
              Console.WriteLine(user.GetUserType()  );

                Console.WriteLine(user.ToString()  );
        }
        
    }


             //     14  FindBook by Id ( int) or by title (string) 
              //Book? return Book if foundedd if not null
                          // searsh by ( int Id)

            public  Book ?  FindBook(int Id)
    {                       //Books to _book                          // عنصر عنصر  واحد واحد  الفحص 
              Book ? book = _books.FirstOrDefault(b => b.Id == Id);
              return book;
             
              //FirstOrDefault() if found retrn int , if not found return by defalut for book ( null)
        }


                       // Method Overloading ( same name  FindBook BUT diffrent parameter )
                       //// searsh by ( string title)
                       /// 
                 public List<Book> FindBook(string title)
    {                                //عنصر عنصر  واحد واحد الفحص   
              //Books to _book                   //   toList >>>List<Book> 
        return _books.Where( b => b.Title == title ).ToList();
    
    
    }

}


//            // Encapsulation 
// ا جعلناهم private>> ما بنقدر نقرأهم من Program.cs. 

// solve  proplrm  by add proparity for  Read only  from them 

      //public IReadOnlyList<Book> Books => _books;
         //       public IReadOnlyList<LibraryUser> Users => _users;

         // ouside can  read only  like >>  Library.Books

         // But OutSide Can't >>
         // X     library.Books.Add(book);  because  Books  it's tybe is  read only  > IReadOnlyList<Book> 
         // but you can Add by library.AddBook(book);

    // Update News 
   //Encapsulation does not mean that external code can only read the data.
   //  It means the class controls how the data can be accessed and modified.
   //  You can allow reading, adding, or modifying, but through methods with specific rules.




























 /*     // original code  

//  Books.Any(...)
 // Users.Any(...) for  
 

using System.Linq;

public class Library
{
    public List<Book> Books { get; set; }
    public List<LibraryUser> Users { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Users = new List<LibraryUser>();
    }


/*  
        Books:
Book ID 1
Book ID 2
Book ID 3           b  راح يوخض واحد وحد شكل فردي يفحصه
 *  * * /

 //Check whether a book with the same ID already exists ( old id = new id)   )
    public bool AddBook(Book book)  //خذ الـ b > =واعمل عليه الشرط الموجود بعد السهم.
    {     //Books.Any(z => z.Id == book.Id) عادي اسم موقت انا اختاره 
        if (Books.Any(b=>  b.Id == book.Id)  )
        { return false ; }

           // after exzamination if not founded ADD  (swtitch >>>> to TRUE  )
        Books.Add(book);
        {return true;}
        
    }
/* note مهمه** the method must accept both:
( Memberand Librarian  )
because both inherit from (LibraryUser. )   *  * /


        public bool AddUser(LibraryUser user)
          {
        if (Users.Any(u=>u.Id==user.Id))
         { return false ;}

         Users.Add(user);
         return true;

          }

    }



   /*
لانه الباريميترLibraryUser>>   public bool AddUser(LibraryUser user)

يمكن تمرير Memberand &  Librarian

لانه (LibraryUser user) parameter accept them pothBecause they are his children,    demonstrate polymorphism.  طبقنا هيك polymorphism

Member member = new Member(...);
Librarian librarian = new Librarian(...);

library.AddUser(member);
library.AddUser(librarian);   */


/*
whem we brooke Polymorphism ?                 طيب كيف ممكن نخرب الـ Polymorphism  

IF  we in parameter said  >>public bool AddUser(Member user)  here just accept only from member class || not accept from poth  from ( Member &  Librarian ) class
// وقتها بكون كسرنا مبدأ    Polymorphism               *    *  / 

                     original code                   */ 



                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        
                                        /*           //    try code the first 
                     
                     
                     
                     
                     using System.Collections.Generic   ;



//  بتلزمنا ممكن  عشان  ال  ممكنlist <   >     ممكن 
public class Library
{   
    public List<Book> Books { get ; set ; }

  public List <LibraryUser> Users   {get ; set ;}
 // الي فقو عطينتهم قيم داخل constractor 

// بزبط و صح  قيم  ابتدائي بدون   constractor  
 //public List<Book> Books { get; set; } = new List<Book>();  صح قيم  ابتدائي بدون  constractor 
 //او  public List<LibraryUser> Users { get; set; } = new List<LibraryUser>(); صح  


 /*  public List<Gas> Gases { get; set; }   *   * / 

    public Library()
    {
        Books = new List<Book>();

           
        Users = new List<LibraryUser> () ;  

          /*    Gases = new List<Gas>();   *   *  / 

    }


public void AddBook(Book book)
{
    Books.Add(book);
}

          //public void AddUsers (LibraryUser user)   بزبط
              // {   Users.Add(user); }   لكن الايميل طالب *AddUser*
      
       //library.AddUsers(member);لكن  وقتها بتعمل هيك 
public void AddUser (LibraryUser user)
    {
        
        Users.Add(user);
    }                      // library.AddUser(member); تعمل صح


/*
public void AddGas( Gas ga){
Gas.Add(ga); 
Gas.Add(gaaaz);  //normal its just parameter name }  *   *  /   


}         */       // end of firs try code 