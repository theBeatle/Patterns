using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Composite
{

    interface IDocumentComponent
    {
        string GatherData(); //CRUD Read
        void AddComponent(IDocumentComponent documentComponent); // Create
    }

    class CustomerDocumentComponent : IDocumentComponent
    {
        private int CustomerIdToGatherData { get; set; }
        public CustomerDocumentComponent(int customerIdToGatherData)
        {
            CustomerIdToGatherData = customerIdToGatherData;
        }
        public string GatherData()
        {
            string customerData;
            switch (CustomerIdToGatherData)
            {
                case 41:
                    customerData = "Andriy Buday";
                    break;
                case 67:
                    customerData = "Oleh Knyaz";
                    break;
                default:
                    customerData = "Someone else";
                    break;
            }
            return $"<Customer>\n{customerData}\n</Customer>";
        }
        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }

    class DocumentComponent : IDocumentComponent
    {
        public string Name { get; private set; }
        public List<IDocumentComponent> DocumentComponents { get; private set; }
        public DocumentComponent(string name)
        {
            Name = name;
            DocumentComponents = new List<IDocumentComponent>();
        }
        public string GatherData()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<{Name}>");
            foreach (var documentComponent in DocumentComponents)
            {
                //documentComponent.GatherData();
                stringBuilder.AppendLine(documentComponent.GatherData());
            }
            stringBuilder.AppendLine($"</{Name}>");
            return stringBuilder.ToString();
        }
        public void AddComponent(IDocumentComponent documentComponent)
        {
            DocumentComponents.Add(documentComponent);
        }
    }

    class OrderDocumentComponent : IDocumentComponent
    {
        private int OrderIdToGatherData { get; set; }

        public OrderDocumentComponent(int orderIdToGatherData)
        {
            OrderIdToGatherData = orderIdToGatherData;
        }

        public string GatherData()
        {
            string orderData;
            switch (OrderIdToGatherData)
            {
                case 0:
                    orderData = "Kindle;Book1;Book2";
                    break;
                default:
                    orderData = "Phone;Cable;Headset";
                    break;
            }

            return $"<Order>\n{orderData}\n</Order>";
        }

        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }

    class HeaderDocumentComponent : IDocumentComponent
    {
        public string GatherData()
        {
            return $"<Header>\n<MessageTime>\n{DateTime.Now.ToShortTimeString()}\n</MessageTime>\n</Header>";
        }
        public void AddComponent(IDocumentComponent documentComponent)
        {
            Console.WriteLine("Cannot add to leaf...");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var document = new DocumentComponent("ComposableDocument");

            var headerDocumentSection = new HeaderDocumentComponent();
            document.AddComponent(headerDocumentSection);

            var body = new DocumentComponent("Body");   
            document.AddComponent(body);

            var customerDocumentSection = new CustomerDocumentComponent(67);
            body.AddComponent(customerDocumentSection);

            var orders = new DocumentComponent("Orders");
            var order0 = new OrderDocumentComponent(0);
            var order1 = new OrderDocumentComponent(1);
            orders.AddComponent(order0);
            orders.AddComponent(order1);
            body.AddComponent(orders);

            string gatheredData = document.GatherData();
            Console.WriteLine(gatheredData);

        }
    }
}
