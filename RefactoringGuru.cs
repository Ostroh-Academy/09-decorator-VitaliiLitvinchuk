namespace RefactoringGuru
{
    internal class Program
    {
        public abstract class Component
        {
            public abstract string Operation();
        }

        class ConcreteComponent : Component
        {
            public override string Operation() => "ConcreteComponent";
        }

        abstract class Decorator(Component component) : Component
        {
            protected Component _component = component;

            public void SetComponent(Component component)
            {
                _component = component;
            }

            public override string Operation()
            {
                if (_component != null)
                    return _component.Operation();
                return string.Empty;
            }
        }

        class ConcreteDecoratorA(Component comp) : Decorator(comp)
        {

            public override string Operation() => $"ConcreteDecoratorA({base.Operation()})";
        }

        class ConcreteDecoratorB(Component comp) : Decorator(comp)
        {
            public override string Operation() => $"ConcreteDecoratorB({base.Operation()})";
        }

        public class Client
        {
            public void ClientCode(Component component) => Console.WriteLine("RESULT: " + component.Operation());
        }

        public static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }
    }
}
