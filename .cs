in Srp the defination 
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
  
