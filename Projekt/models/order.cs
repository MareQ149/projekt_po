/// <summary>
/// Reprezentuje zamówienia z id zamówienia, nazwę, status, liste zamówionych pizz, cenę, czas złożonego zamówienia i przewidywany czas dostawy
/// </summary>
public class Order
{
    /// <summary>
    /// id zamówienia
    /// </summary>
    public int id { get; private set;}
    /// <summary>
    /// nazwa zamówienia
    /// </summary>
    public string orderName { get; private set; }
    /// <summary>
    /// status zamówienia
    /// </summary>
    public OrderStatus status { get; private set; }
    /// <summary>
    /// lista zamówionych pizz
    /// </summary>
    public List<Pizza> pizzas { get; private set; }
    /// <summary>
    /// cena zamówienia
    /// </summary>
    public double orderPrice { get; set; }
    /// <summary>
    /// podaje czas złożenia zamówienia
    /// </summary>
    public TimeOnly OrderTime { get; private set; }
    /// <summary>
    /// kiedy możemy spodziewać się pizzy
    /// </summary>
    public TimeOnly OrderDeliveryExpected { get; private set; }
    /// <summary>
    /// Tworzy instancję klasy <see cref="Order"/>.
    /// </summary>
    /// <param name="id">id zamówienia</param>
    /// <param name="orderName">nazwa zamówienia</param>
    /// <param name="pizzas">lista zamówionych pizz</param>
    
    public Order(int id, string orderName, List<Pizza> pizzas)
    {
        
        orderPrice = 0;
        foreach (var item in pizzas)
        {
            orderPrice += item.GetPrice();
        }
        if(orderPrice < 100)
        {
            orderPrice += 10;
        }
        this.id = id;
        this.orderName = orderName;
        status = OrderStatus.ORDERED;
        this.pizzas = pizzas;
        OrderTime = TimeOnly.FromDateTime(DateTime.Now);
        OrderDeliveryExpected = OrderTime.AddMinutes(40);
    }
    /// <summary>
    /// aktualizuje status zamówienia
    /// </summary>
    /// <param name="NewStatus">zaktualizowany status zamówienia</param>
    public void UpdateStatus(OrderStatus NewStatus)
    {
        status = NewStatus;
    }
    /// <summary>
    /// anuluje zamówienie
    /// </summary>
    public void CancelOrder()
    {
        status = OrderStatus.CANCELLED;
    }
}