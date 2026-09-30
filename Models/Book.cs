public class Book
{
    public int Id{get ; set ;}

    public string Title {get ; set ;}

    public string  Author{get ; set ;}

    public bool IsAvailable { get ; set ;}

public Book (int Id , string Title , string Author )
    {
        this.Id=Id ;
        this.Title=Title;
        this.Author= Author;
    
             IsAvailable = true; 
    }



 // Borrow
    public bool Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            return true;
        }

        return false;
    }



// ReturnBook
    public bool ReturnBook()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
            return true;
        }

        return false;
    }




public override string ToString ()
    {
        return $"ID : {Id}  | Title :{Title }  | Author : {Author}  | Available: {(IsAvailable ? "Yes" : "No") }   ";

    }



}