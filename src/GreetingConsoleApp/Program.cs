using Akka.Actor;

var actorSystem = ActorSystem.Create("the-universe");

var greeter = actorSystem.ActorOf<GreetingActor>("greeter");

greeter.Tell(new Greet("John"));

Thread.Sleep(5000);

actorSystem.Stop(greeter);

Console.ReadLine();


public class Greet 
{
    public Greet(string who)  => Who = who;
    public string Who { get; }
}

public class GreetingActor : ReceiveActor 
{
    public GreetingActor() 
    {
        Receive<Greet>(greet => Console.WriteLine($"Hello {greet.Who}")); 
    }

    protected override void PreStart() =>
        Console.WriteLine("Good morning, we are awake!", ConsoleColor.Green);

    protected override void PostStop() =>
    Console.WriteLine("Good night, going to bed!", ConsoleColor.Red);

}
