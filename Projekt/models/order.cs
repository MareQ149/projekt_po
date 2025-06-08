public class Order
{
    public int id { get; private set;}
    public string orderName { get; private set; }
    public OrderStatus status { get; private set; }
    public List<Pizza> pizzas { get; private set; }
    public double orderPrice { get; private set; }
    public TimeOnly OrderTime { get; private set; }
    public TimeOnly OrderDeliveryExpected { get; private set; }
    public Order(int id, string orderName, OrderStatus status, List<Pizza> pizzas, double orderPrice, TimeOnly OrderTime, TimeOnly OrderDeliveryExpected)
    {
        this.id = id;
        this.orderName = orderName;
        this.status = status;
        this.pizzas = pizzas;
        this.orderPrice = orderPrice;
        this.OrderTime = OrderTime;
        this.OrderDeliveryExpected = OrderDeliveryExpected;
    }
    public void UpdateStatus(OrderStatus)
    {

    }
    public void CancelOrder()
    {

    }
}