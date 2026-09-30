
public class Member : LibraryUser, INotifiable    //The class must also implement the INotifiable interface described later.
//later 
{
   public  List<Book> BorrowedBooks { get ; set ;}

 public int MaxBooks  {get ; set ; } = 3;


    public Member ( int Id ,string Name ,String Email  )     //Eroor  between parameters ; X
   {            
     this.Id=Id;
     
     this.Name = Name;

        this.Email = Email;       //مهم  this 
   
   BorrowedBooks = new List<Book> ();
   //using System.Collections.Generic;   لازم هاي عشانها 
   //The constructor must initialize BorrowedBooks.   صح 

    } 


 public override string GetUserType()    //It must return:  Member
    {
        return "Member" ;
    }
                                            // لانه بعدنا ما عملنا Book عادي 
         
         
          public bool BorrowBook(Book book)   //اعملنا method book  +(Book book) نستقبل book as a parameter
    {
        if (book.IsAvailable && BorrowedBooks.Count < MaxBooks)
        {
            BorrowedBooks.Add(book);
            book.Borrow();

            return true;   
        }

        return false;

    }
       //MaxBooks = 3;    //count < 3 True ( SO 0 ,1 ,2)
                           // count 3 or more > false برجع 
    public bool ReturnBook(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            BorrowedBooks.Remove(book);
            book.ReturnBook();     //avalable for somone Else book  ||  ( Change the book status to available. )

            return true;
        }

        return false;
    }



    public override string ToString( ) 
                               //( Id , Name , Email ,Tybe ) X
    { return $"ID : {Id}    | Name : {Name}    | Emil : {Email}    | Type :{GetUserType()} ";

        // return base.ToString(); 
        //        return this.Id, this.Name , this.Email , this.Type ;

    }

/*
    // هاي مش مطلوبة في الاميل لكن 
  Member must also implement the INotifiable interface described later  */ 

         public void SendNotification(string message)
          { Console.WriteLine("Notification is " + message);  
            }

                  }//end                                