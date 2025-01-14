General defenation of srp goes llke this:
A class shoould only have one reponsibility 
A class should only change ofor one reason 
Or what you said:  things that change for the same reasons should live together and things that change for different reasons should live apart
Here i im not very sure what "responsibility" , "reason" what really mean? i- i did some reasarch and after a bit thinking here is what i came up with
In srp the classes can brodly of three types 
1) LogicHandler (The "How" Class)
Purpose: Contains the logic for specific functionalities, for single or multiple class. its for processing(logic) game mechanics.
Why SRP Applies: This class should only focus on the logic and nothing else.

2) Entity (The "What" Class)
Purpose: Represents objects or entities in the system, with properties and methods defining their behavior and delegating complex logic to "How" classes . 
Example: A Player, Boat, or Enemy class.
Why SRP Applies: This class focuses solely on the attributes and behaviors of that entity, delegating complex logic to other classes

3) SystemMangaer (The "Looping" Class)
Purpose: Manages multiple entities and manage their interactions.
Example: A GameManager that loops through all entities and applies game rules.
Why SRP applies: This class focuses only on managing the game loop, while each entity class handles its own behavior and state.

I'm not sure if this is the right way to think about it, but I want to make a few more points...

Sure, but I can't think of a reason why we’d have different strategies/approaches to player movement. So why make a separate class for it?

Of course, there are no hard rules for the definition I mentioned earlier, and as you pointed out, it might not be worth separating the Move method into a PlayerMovement class.
I agree with you if this was all the system I was building, but if you consider the Move method to be a bit more complex, like this for example:

public void Move(int x, int y)
{
    int BonusIncrement = 0;
    BonusPositionIncrementIfEven();

    void BonusPositionIncrementIfEven()
    {
        if (X % 2 == 0 && Y % 2 == 0)
        {
            BonusIncrement = 5;
        }
    }

    X = (x + BonusIncrement) + (3 * new Random().Next(5));
    Y = (y + BonusIncrement) + (3 * new Random().Next(5));

    Console.WriteLine($"New Position: X = {X}, Y = {Y} for player {Name}");
}
And there could be more other methods that have their own "logic" like PlayerTalk, PlayerDance, etc.

just to keep the example simple, I didn’t do that, but in reality, I would probably encapsulate X and Y by making them private setters. Then, if we actually need to modify them, we could do it through a separate SetPositionTo() method with x and y as parameters. 
This way, it’s far less likely to cause errors, and we can add checks before changing the original X and Y (like ensuring they cannot be negative, etc.)."

Here...
Is there more than one way to solve it?
If so, are you likely to change your mind about how you approach it?

For both of these questions, my answer is NO, but I still feel that separating "logic" into a separate class helps with one crucial thing: clean, readable code. 
My classes would be more understandable, like reading English, and the logic could be handled by other classes. 
I think I can still call it SRP, but the level of SRP might not be that high yet, since I’m not using interfaces for it.

    
I’d like to hear your views on this, as this is just my interpretation of the definition that makes sense to me.
Definitely, there’s a time and place for everything. For simple movement logic and other less-complex methods, I think handling it directly in the class might be betternmb


Also there could be one more good reason to make the code like this: 
Suppose there is a Seahorse class that needs the same logic for updating its positions like player has, Now here we can copy the logic and put in class but if i  change to change the design i have to do that in two places 
So instead i can make a commmon interface like this
{
   public int X { get;  }
   public int Y { get; }
   public void SetPoisition(int x, int y) { x = X; y = Y; } // dont have to write this in the implememted class 
   public void Move(int x , int y); 
}

both class can implement from it:
public class Seahorse : IPosition
// The move method can be like this 
 public void Move(int x , int y ){ Movement.Move(this , x, y);}

public class Player : IPosition
// The move method can be like this 
public void Move(int x , int y ){ Movement.Move(this , x, y);}

Make my Move method ( in some external class ) like this:
public static void Move(IPosition player, int x, int y){//Add logic here}}




    
Here i think ill use inheretence like this 
{
    public int X { get; } 
    public int Y { get; } 
    public abstract void SetPoisition(int x, int y){};
}

both class can inheret from it:
public class Seahorse : Animals
public class Player : Animals

Make my move method ( in some external class ) like this:
public static void Move(Animals player, int x, int y) // changes X and Y 

    


public interface IMovement
{
    int X { get; }
    int Y { get; }
    void SetPosition(int x, int y);
}
adds check to mae sure programming logic cant be violated outside the class 

public class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }
}

//
i dont know if its a good way to say its SRp , but i feel its a good way in general to achieve clean readable code as my classes itself would more be like english and the logic can handle by 
other classes 
//
in abstraction you hide complexity (simplefied wrapper around a complex code) ( dont have to understand the internal logic when using that method ) but how good is it in hiding complexicity in code makes the quality of abstraction?
  simplified wrapper method around a complex code  
  You hide the complexity of the code from the user, making it easier for them to use the system.

    A class itself can be an abstraction if it encapsulates the complexity of data and behavior. For example, a Car class abstracts away the details of how the engine works or how the wheels rotate, offering simpler methods like Drive() or Stop().

      You can call Drive() on any class that implements IDriveable, and it will work."
      
      "user" refers to anyone who interacts with the system but doesn't need to understand or deal with its complex internal workings. This could be a programmer using a library, an end-user using a software application, or another system interacting with your code

      a Car class might expose methods like Drive() or Stop(), but the user of the class doesn't need to understand how the car's engine works, how braking is implemented, or how fuel consumption is managed
      dosent need to know how these behaviours work you just use it 
      You don’t have to know how those behaviors are implemented inside the class; you just use them.
        higher level of abstraction you dont need to know ABOUT SYSTEM 
      an IDriveable interface might have methods like StartEngine() and StopEngine(). Both a Car and a Boat might implement IDriveable, but the user can interact with both objects in the same way, without knowing whether it's a car or a boat doing the driving.


        I can use base class and provide nessary subclass and use its functionas without needing to know how they work
       the quality of abstraction typically does not affect user interaction directly. The user will interact with the system in the same way, regardless of whether the abstraction is high-quality or low-quality.
  
