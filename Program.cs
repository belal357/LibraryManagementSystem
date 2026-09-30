 //  Console.WriteLine(AppContext.BaseDirectory); //  <<<"أعطني المسار الذي يوجد فيه التطبيق الذي يتم تشغيله حاليًا."    //   then  in termenal to find file path dotnet run
  //What is the application path? >>>>>   //    C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem\bin\Debug\net10.0\

 Library library = new Library ();

//  المطلوب يقول إن البرنامج يجب أن يثبت أن الكتب أُضيفت بنجاح، لذلك نستطيع لاحقًا أن نطبع:

//Book added successfully.  //   in termenal to find file path dotnet run

//            // new Book();Create a Book object   &   // library.Addbook() add it (Book) to _books اتذكرتها با   Library.cs
 /* library.AddBook(new Book(1,"Clean code","Robert Martin"));

library.AddBook(new Book(2,"C# in Depth ", "Jon Skeet"));

library.AddBook(new Book(3,"Design Patterns",  "Gang of Four"));

library.AddBook(new Book(4,"The Pragmatic Programmer "," Andrew Hunt"));

library.AddBook(new Book(5,"ASP.NET Core in Action "," Andrew Lock")); /  */ 
//وكل كتاب يبدأ:   >> IsAvailable = true;     >>>بسبب الـ constructor الموجود عندك في Book.


               // test 1 
 if (library.AddBook(new Book(1, "Clean Code", "Robert Martin")))
{
    Console.WriteLine("Book added successfully.");
}

if (library.AddBook(new Book(2, "C# in Depth", "Jon Skeet")))
{
    Console.WriteLine("Book added successfully.");
}

if (library.AddBook(new Book(3, "Design Patterns", "Gang of Four")))
{
    Console.WriteLine("Book added successfully.");
}

if (library.AddBook(new Book(4, "The Pragmatic Programmer", "Andrew Hunt")))
{
    Console.WriteLine("Book added successfully.");
}

if (library.AddBook(new Book(5, "ASP.NET Core in Action", "Andrew Lock")))
{
    Console.WriteLine("Book added successfully.");
}



              // Test 2 - Duplicate Book ( if there book with the same Id retrn false ( for no duplucation cant add it ))

//  checked in Library.cs  >> public bool AddBook(Book book)

bool result = library.AddBook(
    new Book(1, "Another Book", "Another Author")  //  yes can added if not with same Id book 
);

if (result == false)  // no cant add and print 
{
    Console.WriteLine("Book could not be added.");
    Console.WriteLine("Book ID already exists.");
}


    //    //   Test 3 - Display Available Books

    // retrn List< Book>        //   /  Program.cs → requests GetAvailableBooks()
List<Book> availableBooks = library.GetAvailableBooks();
// BOOK >نوع المتغير.  // book → اسم المتغير.
 foreach (Book book in availableBooks)  //مر على كل Book موجود داخل availableBooks واحدًا واحدًا.
{
    Console.WriteLine($"{book.Id} - {book.Title} - Available");       
}            // عنصرًا واحدًا من القائمة في كل دور >> book     
  /* availableBooks
├── Book 1 → Clean Code
├── Book 2 → C# in Depth
└── Book 3 → Design Patterns

الـ foreach يعمل هكذا:
الدورة 1 → book = Clean Code
الدورة 2 → book = C# in Depth
الدورة 3 → book = Design Patterns     */ 



//                         //ADD Members normal 
Member Omar = new Member(1,"Omar","Omar@test.com");
Member ahmad = new Member(2,"Ahmad","Ahmad@test.com");

library.AddUser(Omar);
library.AddUser(ahmad);


   
   Librarian sara = new Librarian (100,"sara"," sara@test.com"," EMP001");

    library.AddUser(sara);



 //             /             /      Test 4 - Borrow a Book (( omer )  Member 1 should >  borrow Book 1. )
       //? → يسمح للمتغير أن يكون null
   Book? book1 = library.FindBook(1);

    if (book1 != null && Omar.BorrowBook(book1))
    {
      Console.WriteLine("Book borrowed successfully.");
     }     // the  book should now state change to unavalable ( IsAvaliable = false)

// in Test 4 we made Omer Borrow a book so>   IsAvailable == false>

//  here in  Test 5  we will try to borrow  the same booke in test 4 , its a Borrowed book  (UnAvalable) 
// > will return false  Because Book UNAVALABLE  !!!




//          //   Test 5 - Borrow an Unavailable Book

    // ! ( not vs valuo )                 //  2 ! .>> can be null /  but nut cant leve it empty must valuo
if (!Omar.BorrowBook(book1!))            //BorrowBook = true  → !true = false → no entry for if
                                       //BorrowBook = false → !false = true → يدخل if
{                
    Console.WriteLine("Book is not available.");
}



// we  need to Display the books Omar has borrowed; the  Book 1 should print book 1 Title 

//                   // Test 6 - Display Borrowed Books ()

Console.WriteLine("Omar's Borrowed Books:");

foreach (Book book in Omar.BorrowedBooks)
{      // list Beacuse in Member.cs ( public List<Book> BorrowedBooks { get; set; }   ) there many books can Borrow 
    Console.WriteLine(book.Title);
}



// Test 7 - Maximum Books 

//( make shure not more than 3 books  ,3 maximum  , 4 False Error)
Book? book2 = library.FindBook(2);     
Book? book3 = library.FindBook(3);              //والـ ? يعني أن النتيجة ممكن تكون null إذا الكتاب غير موجود.
Book? book4 = library.FindBook(4);

Omar.BorrowBook(book2!);
Omar.BorrowBook(book3!);


if (!Omar.BorrowBook(book4!))
{
    Console.WriteLine("Member cannot borrow more than 3 books.");
}


       // Test 8  Return a Book

if (Omar.ReturnBook(book1!))    // Nullable   (   !  )
{
    Console.WriteLine("Book returned successfully.");
}

         //                                               Member.cs   
           /*     public bool ReturnBook(Book book)
{
    if (BorrowedBooks.Contains(book))
    {
        BorrowedBooks.Remove(book);
        book.ReturnBook();
        return true;
    }

    return false;
}         

            public List<Book> BorrowedBooks { get; set; }

هاي القائمة معناها: ما هي الكتب التي Omar مستعيرها حاليًا

لما Omar يستعير >Book 1 في BorrowBook():                //لازم نتاكد انه موجود ولا لا ( Book 1 )
                                       Omar.BorrowedBooks

                   Book 1 - Clean Code
                         Book 2 - C# in Depth
                                          Book 3 - Design Patterns        هل Book 1 موجود ضمن الكتب التي استعارها Omar؟?

                                   مدامه موجود احذفه        BorrowedBooks.Remove(book); 

then           book.ReturnBook();        cgange book states to     Avalable    >IsAvailable = true
   */ 


                    
//                  /      Test 9 - Invalid Return
// the same book 1 هون بس عكس  رقم 8 ,           wheen book 1 not here any moore
 //  I know this value is not null, so don't give me a nullable warning.
if (!Omar.ReturnBook(book1!))
{                                //     (  !false → true  ) 
    Console.WriteLine("Member did not borrow this book.");
}                 



//  /        Test 10 - Interface      (Test 10 shows  the Interface requirement: Member implements INotifiable and provides the actual behavior for SendNotification().)

Omar.SendNotification("Your book is due tomorrow.");

//                                             Omar is a Member>>  and Member implements the INotifiable interface; 
 //                   public class Member : LibraryUser, INotifiable





//           Test 11  Polymorphism
  //           the list's type is the parent class LibraryUser  >> List<LibraryUser>
   // /                      But inside the list, you put two different child objects:        users
   //                                                                                            ├── Omar  → Member
   //                                                                                             ── Sara  → Librarian
List<LibraryUser> users = new List<LibraryUser>();

users.Add(Omar); 
users.Add(sara);

foreach (LibraryUser user in users)
{
    Console.WriteLine(user.GetUserType());
}  

 //The important idea: one List<LibraryUser> can hold objects of different child classes (Member and Librarian),
  //and the correct overridden method is selected at runtime. That is polymorphism.



/* هل أقدر أعمل AddBook بدون    >>> Library library = new Library(); ??   NO لا 
أAddBook() عندك instance method داخل  >> Library.cs   (لازم يكون عندك object From  Library< so you can call iT)
public bool AddBook(Book book)  هاد 

ممكن تقنيًا تكتب:
new Library().AddBook(new Book(...));

لكن هذا غير مفيد هنا   >>
لأنك أنشأت Librar( موقته 
  ولن تحتفظ بها لتستخدمها لاحقًا.

//   Member.cs با  >> constructor >> public Member(int Id, string Name, String Email) means that  1 → Id   " Omar "   >> Name   >>>> "omar@test.com"  >>>Email

// then library.AddUser(omar);  send member For in  (Library .cs )  

لانه إحنا بنستدعي AddUser() من Library، >>>>  مش من Member.
 public bool AddUser(LibraryUser user)  // omer يعني LibraryUser user
    {         //Users to _users
        if (_users.Any(u => u.Id == user.Id))
        {
            return false;
        }

        _users.Add(user);
        return true;
    }  
    //library.AddUser(omar);  accectable because >> omar من نوع  >Member،  
    و                                          //Member>  هو أصلًا نوع فرعي من LibraryUser /    */


    






/* 16. Program.cs
Create a Program.cs that demonstrates the complete system.
Add Books
Create at least 5 books:
1 - Clean Code - Robert Martin
2 - C# in Depth - Jon Skeet
3 - Design Patterns - Gang of Four
4 - The Pragmatic Programmer - Andrew Hunt
5 - ASP.NET Core in Action - Andrew Lock
Add Members
Create at least 2 members:
1 - Omar - omar@test.com
2 - Ahmad - ahmad@test.com
Add Librarian
Create:
100 - Sara - sara@test.com - EMP001 */

/*                  
                17. Required Tests

The program must demonstrate the following scenarios.

Test 1 — Add Books

Add all 5 books.

Expected result:

Book added successfully.




Test 2 — Duplicate Book

Try to add another book with:

Id = 1


Expected:

Book could not be added.
Book ID already exists.


AddBook() must return:

false




Test 3 — Display Available Books

Display all available books.

Expected:

1 - Clean Code - Available
2 - C# in Depth - Available
3 - Design Patterns - Available
4 - The Pragmatic Programmer - Available
5 - ASP.NET Core in Action - Available






Test 4 — Borrow a Book

Member 1 should borrow Book 1.

Expected:

Book borrowed successfully.


The book must now have:

IsAvailable == false


Test 5 — Borrow an Unavailable Book

Try to borrow Book 1 again.

Expected:

Book is not available.


BorrowBook() must return:

false


Test 6 — Display Borrowed Books

Display the books borrowed by Member 1.

Expected:

Omar's Borrowed Books:

Clean Code


Test 7 — Maximum Books

Member 1 should borrow :
Book 1
Book 2
Book 3   
( the maxium is 3 remmber )
Then try to borrow:
Book 4


Expected:

Member cannot borrow more than 3 books.

BorrowBook() must return:

false



Test 8 — Return a Book

Member 1 returns Book 1.

Expected:

Book returned successfully.


The book must now have:

IsAvailable == true


Test 9 — Invalid Return

Try to return a book that the member has not borrowed.

Expected:

Member did not borrow this book.


ReturnBook() must return:

false


Test 10 — Interface

Test the notification functionality:

member.SendNotification("Your book is due tomorrow.");


Expected:

Notification: Your book is due tomorrow.


Test 11 — Polymorphism

Create:

List<LibraryUser> users = new List<LibraryUser>();


Add:

Member


and:

Librarian


to the same collection.

Then:

foreach (LibraryUser user in users)
{
    Console.WriteLine(user.GetUserType());
}


Expected:

Member
Librarian

/            This demonstrates polymorphism.






18. Expected Class Structure

The final project should approximately contain:

LibraryManagementSystem
│
├── Models
│   ├── Book.cs
│   ├── LibraryUser.cs
│   ├── Member.cs
│   └── Librarian.cs
│
├── Interfaces
│   └── INotifiable.cs
│
├── Services
│   └── Library.cs
│
└── Program.cs


19. OOP Requirements Checklist

The trainee must demonstrate all of the following:

Class & Object

Use classes such as:

Book
Member
Librarian
Library


Create objects using:

new Book(...)
new Member(...)


Encapsulation

Protect internal data and control modifications through methods.

Constructor

Every model class should have an appropriate constructor.

Inheritance

Use:

Member : LibraryUser


and:

Librarian : LibraryUser


Abstraction

Use:

abstract class LibraryUser


and:

public abstract string GetUserType();


Method Overriding

Override:

GetUserType()


in both Member and Librarian.

Also override:

ToString()


where appropriate.

Interface

Create:

INotifiable


and implement it in Member.

Polymorphism

Use:

List<LibraryUser>


containing both:

Member
Librarian


Method Overloading

Implement:

FindBook(int id)


and:

FindBook(string title)


Collections

Use:

List<Book>
List<LibraryUser>


Validation

Handle:

Duplicate book IDs.
Duplicate user IDs.
Borrowing unavailable books.
Returning books that were not borrowed.
Maximum 3 books per member.


//    /  the output is in termenal after press run without debuggeing  >>>>>>>

/*
PS C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem>  & 'c:\Users\MenaITech.LENOVO-THINKBOO.000\.vscode\extensions\ms-dotnettools.csharp-2.160.4-win32-x64\.debugger\x86_64\vsdbg.exe' '--interpreter=vscode' '--connection=ea51be484b094b918908962b77b422cb' 
C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem\bin\Debug\net10.0\
Book added successfully.
Book added successfully.
Book added successfully.
Book added successfully.
Book added successfully.
Book could not be added.
Book ID already exists.
1 - Clean Code - Available
2 - C# in Depth - Available
3 - Design Patterns - Available
4 - The Pragmatic Programmer - Available
5 - ASP.NET Core in Action - Available
Book borrowed successfully.
Book is not available.
Omar's Borrowed Books:
Clean Code
Member cannot borrow more than 3 books.
Book returned successfully.
Member did not borrow this book.
Notification is Your book is due tomorrow.
Member
  Librarian  
PS C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem> 
                                                                           ^C
PS C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem> 
PS C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem>  & 'c:\Users\MenaITech.LENOVO-THINKBOO.000\.vscode\extensions\ms-dotnettools.csharp-2.160.4-win32-x64\.debugger\x86_64\vsdbg.exe' '--interpreter=vscode' '--connection=bc5e79fe9649461dae4b942a22215249' 
Book added successfully.
Book added successfully.
Book added successfully.
Book added successfully.
Book added successfully.
Book could not be added.
Book ID already exists.
1 - Clean Code - Available
2 - C# in Depth - Available
3 - Design Patterns - Available
4 - The Pragmatic Programmer - Available
5 - ASP.NET Core in Action - Available
Book borrowed successfully.
Book is not available.
Omar's Borrowed Books:
Clean Code
Member cannot borrow more than 3 books.
Book returned successfully.
Member did not borrow this book.
Notification is Your book is due tomorrow.
Member
  Librarian  
PS C:\Users\MenaITech.LENOVO-THINKBOO.000\Desktop\LibraryManagementSystem>   *   /


     */ 