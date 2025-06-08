/// <summary>
/// Reprezentuje promocje
/// </summary>
public class Promotion
{
    /// <summary>
    /// Stosuje promocję 2+1 (najtańsza pizza gratis)
    /// </summary>
    /// <param name="order">The order.</param>
    /// <exception cref="System.Exception">nie powinno tak się stać</exception>
    public void ApplyPromo2Plus1(Order order)
    {
        int liczbapizz = order.pizzas.Count;
        if(liczbapizz == 3)
        {
            double cena1 = order.pizzas[0].GetPrice();
            double cena2 = order.pizzas[1].GetPrice();
            double cena3 = order.pizzas[2].GetPrice();
            if(cena1 <= cena2 && cena1 <= cena3)
            {
                if(cena1 == cena2)
                {
                    order.orderPrice -= cena1;
                }
                else if (cena1 == cena3)
                {
                    order.orderPrice -= cena1;
                }
                else if(cena1 == cena2 && cena1 == cena3)
                {
                    order.orderPrice -= cena1;
                }
            }
            else if (cena2 <= cena1 && cena2 <= cena3)
            {
                order.orderPrice -= cena2;
            }
            else if (cena3 <= cena1 && cena3 <= cena2)
            {
                order.orderPrice -= cena3;
            }
            else
            {
                throw new Exception("Coś poszło nie tak");
            }
        }
    }
}