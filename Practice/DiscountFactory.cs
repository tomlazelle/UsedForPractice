using System.Collections.Generic;

namespace Practice
{
    public class DiscountFactory
    {


    }

    public interface IDiscountAdjustment
    {
        void Apply(ICartView cartView);
    }

    public interface ICartView
    {
        decimal Total { get; }
        decimal SubTotal { get; }
        decimal Tax { get; set; }
        int Id { get; set; }
        decimal ShippingAmount { get; set; }
        IEnumerable<ICartItemView> Items { get; set; }
        void AddItem(ICartItemView item);
    }

    public interface ICartItemView
    {
        int Id { get; set; }
        int Quantity { get; set; }
        decimal Amount { get; set; }
        int ProductId { get; set; }
    }
}